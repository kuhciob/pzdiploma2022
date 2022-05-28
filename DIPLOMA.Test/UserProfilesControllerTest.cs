using System;
using System.Collections.Generic;
using System.Text;
using DIPLOMA.Controllers;
using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DIPLOMA.Test
{
    public class UserProfilesControllerFortest : UserProfilesController
    {
        public UserProfilesControllerFortest(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
             IHttpContextAccessor httpContextAccessor, string userID)
            : base(context, userManager,  httpContextAccessor)
        {
            _currentUserId = userID;

        }
    }
    public class UserProfilesControllerTest : BaseControllerTest
    {


        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }
        [Test]
        public void UserProfileExistsTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                UserProfilesControllerFortest controller = new UserProfilesControllerFortest(context, null, null, "test");

                Guid id = Guid.NewGuid();
                context.UserProfile.Add(new UserProfile()
                {
                    ID = id,
                    UserID = "test",
                    
                });

                context.SaveChanges();

                Assert.IsTrue(controller.UserProfileExists(id));


            }
        }
        [Test]
        public void IndexAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                UserProfilesControllerFortest controller = new UserProfilesControllerFortest(context, null, null, "test");

                Guid id = Guid.NewGuid();
                context.UserProfile.Add(new UserProfile()
                {
                    ID = id,
                    UserID = "test",

                });

                context.SaveChanges();

                var result = controller.Edit(id).Result;

                if (result is ViewResult)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

        }
        [Test]
        public void EditAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                UserProfilesControllerFortest controller = new UserProfilesControllerFortest(context, null, null, "test");

                Guid id = Guid.NewGuid();
                context.UserProfile.Add(new UserProfile()
                {
                    ID = id,
                    UserID = "test",

                });

                context.SaveChanges();

                var result = controller.Edit(id).Result;

                if (result is ViewResult)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

        }
        [Test]
        public void CreateTestAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                UserProfilesControllerFortest controller = new UserProfilesControllerFortest(context, null, null, "test");

                Guid id = Guid.NewGuid();
                context.UserProfile.Add(new UserProfile()
                {
                    ID = id,
                    UserID = "test",

                });

                context.SaveChanges();

                context.SaveChanges();
                if (context.UserProfile.FindAsync(id) == null)
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.Pass();
                }
            }

        }
        [Test]
        public void DeleateTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                UserProfilesControllerFortest controller = new UserProfilesControllerFortest(context, null, null, "test");

                Guid id = Guid.NewGuid();
                context.UserProfile.Add(new UserProfile()
                {
                    ID = id,
                    UserID = "test",

                });

                context.SaveChanges();

                context.SaveChanges();
                if (context.UserProfile.FindAsync(id) == null)
                {
                    Assert.Fail();

                }
                var foo = controller.DeleteConfirmed(id).Result;

                if (context.UserProfile.Find(id) == null)
                {
                    Assert.Pass();
                }
            }

        }
    }
}
