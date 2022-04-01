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

        public ApplicationDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KUHCIOB;Database=DIPLOMA;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<DIPLOMA.Models.DonateMsg> DonateMsg { get; set; }
        public DbSet<DIPLOMA.Models.MsgWidget> MsgWidget { get; set; }
        public DbSet<DIPLOMA.Models.MsgWidgetContent> MsgWidgetContent { get; set; }
        public DbSet<DIPLOMA.Models.UploadFile> UploadFile { get; set; }
        public DbSet<DIPLOMA.Models.StatWidgetDisplayModeType> StatWidgetDisplayModeType { get; set; }
        public DbSet<DIPLOMA.Models.StatWidgetType> StatWidgetType { get; set; }
        public DbSet<DIPLOMA.Models.StatWidgetTimeIntervalType> StatWidgetTimeIntervalType { get; set; }
        public DbSet<DIPLOMA.Models.StatWidgetDirectionType> StatWidgetDirectionType { get; set; }

        public DbSet<DIPLOMA.Models.StatisticWidget> StatisticWidget { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity => 
            {
                entity.HasIndex(e => e.NickName).IsUnique();
            });


            modelBuilder.Entity<StatWidgetDisplayModeType>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.CD).
                HasMaxLength(2);

                entity.Property(e => e.Description).
                HasMaxLength(100);
                
                int i = 1;
                entity.HasData(
                    new Models.StatWidgetDisplayModeType() {
                        ID = i++,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDisplayModeConstants.List, 
                        Description = SWDisplayModeDscrConstants.ListDscr
                    },
                    new Models.StatWidgetDisplayModeType() {
                        ID = i++,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDisplayModeConstants.СreepingLine, 
                        Description = SWDisplayModeDscrConstants.СreepingLineDscr
                    },
                    new Models.StatWidgetDisplayModeType()
                    {
                        ID = i++,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDisplayModeConstants.Slider,
                        Description = SWDisplayModeDscrConstants.SliderDscr
                    });
            });
            modelBuilder.Entity<StatWidgetType>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.Description).
                HasMaxLength(100);

                entity.Property(e => e.CD).
                HasMaxLength(2);

                entity.HasData(
                    new Models.StatWidgetType()
                    {
                        ID = 1,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTypeConstants.Top,
                        Description = SWTypeDscrConstants.TopDscr
                    },
                    new Models.StatWidgetType()
                    {
                        ID = 2,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTypeConstants.LastDonater,
                        Description = SWTypeDscrConstants.LastDonaterDscr
                    },
                    new Models.StatWidgetType()
                    {
                        ID = 3,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTypeConstants.CollectedAmt,
                        Description = SWTypeDscrConstants.CollectedAmtDscr
                    }
                     );
            });          
            modelBuilder.Entity<StatWidgetTimeIntervalType>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.CD).
                HasMaxLength(2);

                entity.Property(e => e.Description).
                HasMaxLength(100);

                entity.HasData(
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 1,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.Today,
                        Description = SWTimeIntervalDscrConstants.TodayDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 2,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.AllTime,
                        Description = SWTimeIntervalDscrConstants.AllTimeDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 3,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.ThisWeek,
                        Description = SWTimeIntervalDscrConstants.ThisWeekDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 4,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.Last7Days,
                        Description = SWTimeIntervalDscrConstants.Last7DaysDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 5,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.ThisMonth,
                        Description = SWTimeIntervalDscrConstants.ThisMonthDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 6,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.Last30Days,
                        Description = SWTimeIntervalDscrConstants.Last30DaysDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 7,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.ThisYear,
                        Description = SWTimeIntervalDscrConstants.ThisYearDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 8,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.LastYear,
                        Description = SWTimeIntervalDscrConstants.LastYearDscr
                    },
                    new Models.StatWidgetTimeIntervalType()
                    {
                        ID = 9,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWTimeIntervalCDConstants.Last24,
                        Description = SWTimeIntervalDscrConstants.Last24Dscr
                    }
                     );
            });
            modelBuilder.Entity<StatWidgetDirectionType>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.CD).
                HasMaxLength(2);

                entity.Property(e => e.Description).
                HasMaxLength(100);

                entity.HasData(
                    new Models.StatWidgetDirectionType()
                    {
                        ID = 1,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDirectionConstants.RightLeft,
                        Description = SWDirectionDsrcConstants.RightLeftDscr,
                        Value = SWDirectionValueConstants.RightLeft
                    },
                    new Models.StatWidgetDirectionType()
                    {
                        ID = 2,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDirectionConstants.LeftRight,
                        Description = SWDirectionDsrcConstants.LeftRightDscr,
                        Value = SWDirectionValueConstants.LeftRight

                    },
                    new Models.StatWidgetDirectionType()
                    {
                        ID = 3,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDirectionConstants.TopBottom,
                        Description = SWDirectionDsrcConstants.TopBottomDscr,
                        Value = SWDirectionValueConstants.TopBottom

                    },
                    new Models.StatWidgetDirectionType()
                    {
                        ID = 4,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        CD = SWDirectionConstants.BottomTop,
                        Description = SWDirectionDsrcConstants.BottomTopDscr,
                        Value = SWDirectionValueConstants.BottomTop

                    }
                     );
            });

            modelBuilder.Entity<DonateMsg>(entity =>
            {
                entity.Property(e => e.ID).
                UseIdentityColumn();

                entity.Property(e => e.Amount).
                HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DonateMsgs)
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

            modelBuilder.Entity<StatisticWidget>(entity =>
            {
                entity.Property(e => e.ElementsCount)
               .HasDefaultValue(5);

                entity.HasOne(d => d.WidgetType)
                    .WithMany(x => x.StatisticWidgets)
                    .HasForeignKey(d => d.WidgetTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DisplayMode)
                   .WithMany(x => x.StatisticWidgets)
                   .HasForeignKey(d => d.DisplayModeID)
                   .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Direction)
                   .WithMany(x => x.StatisticWidgets)
                   .HasForeignKey(d => d.DirectionID)
                   .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TimeInterval)
                  .WithMany(x => x.StatisticWidgets)
                  .HasForeignKey(d => d.TimeIntervalID)
                  .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StatisticWidgets)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StatisticWidget_UserID");
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
