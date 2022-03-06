using DIPLOMA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIPLOMA.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        public DbSet<DIPLOMA.Models.DonateMsg> DonateMsg { get; set; }
        public DbSet<DIPLOMA.Models.MsgWidget> MsgWidget { get; set; }
        public DbSet<DIPLOMA.Models.MsgWidgetContent> MsgWidgetContent { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity => 
            {
                entity.HasIndex(e => e.NickName).IsUnique();
            });

            modelBuilder.Entity<DonateMsg>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.Amount).
                HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DonateMsg)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonateMsg_UserID");
            });

            modelBuilder.Entity<MsgWidgetContent>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.HasOne(d => d.Sound)
                    .WithMany(p => p.MsgWidgetContentSound)
                    .HasForeignKey(d => d.SoundFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Animation)
                    .WithMany(p => p.MsgWidgetContentAnimation)
                    .HasForeignKey(d => d.AnimationFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            
            modelBuilder.Entity<MsgWidget>(entity =>
            {
                //entity.Property(e => e.ID).
                //UseIdentityColumn();

                entity.Property(e => e.MaxAmt).
                HasColumnType("decimal(18, 4)")
                .HasDefaultValue(1000m);

                entity.Property(e => e.MinAmt).
                HasColumnType("decimal(18, 4)")
                .HasDefaultValue(10m);

                entity.Property(e => e.MaxSymbols)
                .HasDefaultValue(50);

                entity.Property(e => e.DisplayTimeSec)
                .HasDefaultValue(5);

                entity.Property(e => e.ReadHeader)
                .HasDefaultValue(false);
                entity.Property(e => e.ReadMessage)
               .HasDefaultValue(true);
                entity.Property(e => e.RandomContent)
               .HasDefaultValue(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MsgWidgets)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MsgWidget_UserID");

                entity.HasMany<MsgWidgetContent>(e => e.MsgWidgetContent).
                    WithOne(e => e.MsgWidget).
                    HasForeignKey(e => e.MsgWidgetID).
                    OnDelete(DeleteBehavior.Cascade);
            });
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseModel)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
