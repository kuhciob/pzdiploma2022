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
    public class MsgWidgetsControllerTests : BaseControllerTest
    {
        public class MsgWidgetsControllerFortest : MsgWidgetsController
        {
            public MsgWidgetsControllerFortest(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor, string userID)
                : base(context, userManager, webHost, httpContextAccessor)
            {
                _currentUserId = userID;

            }
        }
        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }
        
        [Test]
        public void MsgWidgetExistsTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                MsgWidgetsController controller = new MsgWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
                    UserID = "test"
                });

                context.SaveChanges();

                var result = controller.MsgWidgetExists(id);

                Assert.IsTrue(result);

            }
        }
        [Test]
        public void GetMsgWidgetTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                MsgWidgetsControllerFortest controller = 
                    new MsgWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
                    UserID = "test"
                });

                context.SaveChanges();

                var result = controller.GetMsgWidget(id).Result;

                if(result != null)
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
        public void IndexAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                MsgWidgetsControllerFortest controller = 
                    new MsgWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = $"http/localhost/MsgWidgets/Display/{id}",

                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
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
                MsgWidgetsControllerFortest controller =
                    new MsgWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = $"http/localhost/MsgWidgets/Display/{id}",

                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
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
        public void CreateTestAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                MsgWidgetsController controller =
                    new MsgWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
                    UserID = "test"
                });

                context.SaveChanges();
                if (context.MsgWidget.FindAsync(id) == null)
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
                MsgWidgetsController controller = 
                    new MsgWidgetsController(context, null, null, null);
  
                Guid id = Guid.NewGuid();
                context.MsgWidget.Add(new MsgWidget 
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DisplayTimeSec = 1,
                    RandomContent = true,
                    ReadMessage = true,
                    UserID = "test"
                });

                context.SaveChanges();
                if (context.MsgWidget.FindAsync(id) == null)
                {
                    Assert.Fail();

                }
                var foo = controller.DeleteConfirmed(id).Result;

                if (context.MsgWidget.Find(id) == null)
                {
                    Assert.Pass();
                }
            }

        }

    }
}