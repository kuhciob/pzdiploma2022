using DIPLOMA.Controllers;
using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIPLOMA.Test
{
    public class FundraisingWidgetsControllerFortest : FundraisingWidgetsController
    {
        public FundraisingWidgetsControllerFortest(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, string userID)
            : base(context, userManager, webHost, httpContextAccessor)
        {
            _currentUserId = userID;

        }
    }
    public class FundraisingWidgetsControllerTest : BaseControllerTest
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        [Test]
        public void FundraisingWidgetExistsTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                FundraisingWidgetsControllerFortest controller = new FundraisingWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.FundraisingWidget.Add(new FundraisingWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    HideInitAndTargetAmounts = true,
                    Active = true,
                    BorderSize = 1,
                    Radius = 1,
                    Height = 1,
                    UserID = "test",
                    
                });

                context.SaveChanges();
                
                Assert.IsTrue(controller.FundraisingWidgetExists(id));


            }
        }
        [Test]
        public void IndexAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                FundraisingWidgetsControllerFortest controller = new FundraisingWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.FundraisingWidget.Add(new FundraisingWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = $"http/localhost/FundraisingWidgets/Display/{id}",

                    Name = "Test",
                    HideInitAndTargetAmounts = true,
                    Active = true,
                    BorderSize = 1,
                    Radius = 1,
                    Height = 1,
                    UserID = "test"
                });

                context.SaveChanges();

                var result = controller.Index().Result;

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
        public void DetailsAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                FundraisingWidgetsController controller = new FundraisingWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.FundraisingWidget.Add(new FundraisingWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    Url = $"http/localhost/FundraisingWidgets/Display/{id}",

                    HideInitAndTargetAmounts = true,
                    Active = true,
                    BorderSize = 1,
                    Radius = 1,
                    Height = 1,
                    UserID = "test"
                });

                context.SaveChanges();

                var result = controller.Details(id).Result;

                if (result is ViewResult)
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
        public void CreateTestAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                FundraisingWidgetsController controller = new FundraisingWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.FundraisingWidget.Add(new FundraisingWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    HideInitAndTargetAmounts = true,
                    Active = true,
                    BorderSize = 1,
                    Radius = 1,
                    Height = 1,
                    UserID = "test"
                });

                context.SaveChanges();
                if (context.FundraisingWidget.FindAsync(id) == null)
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
        public void DeleateTestAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                FundraisingWidgetsController controller = new FundraisingWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.FundraisingWidget.Add(new FundraisingWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    HideInitAndTargetAmounts = true,
                    Active = true,
                    BorderSize = 1,
                    Radius = 1,
                    Height = 1,
                    UserID = "test"
                });

                context.SaveChanges();
                if (context.FundraisingWidget.FindAsync(id) == null)
                {
                    Assert.Fail();

                }
                var foo = controller.DeleteConfirmed(id).Result;

                if (context.FundraisingWidget.Find(id) == null)
                {
                    Assert.Pass();
                }
            }

        }
    }
}
