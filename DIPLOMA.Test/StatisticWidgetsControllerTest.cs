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
    public class StatisticWidgetsControllerTest : BaseControllerTest
    {
        public class StatisticWidgetsControllerFortest : StatisticWidgetsController
        {
            public StatisticWidgetsControllerFortest(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
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
        public void StatisticWidgetExistsTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                StatisticWidgetsController controller = new StatisticWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.StatisticWidget.Add(new StatisticWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DirectionID = 1,
                    TextStyleID = 1,
                    DisplayModeID = 1,
                    TimeIntervalID = 1,
                    WidgetTypeID = 1,
                    UserID = "test",
                    ElementsCount = 1,
                    ScrollingSpeed =1 
                });

                context.SaveChanges();

                Assert.IsTrue(controller.StatisticWidgetExists(id));


            }
        }
        [Test]
        public void IndexAsync()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                StatisticWidgetsControllerFortest controller = new StatisticWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.StatisticWidget.Add(new StatisticWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = $"http/localhost/StatisticWidgets/Display/{id}",

                    Name = "Test",
                    DirectionID = 1,
                    TextStyleID = 1,
                    DisplayModeID = 1,
                    TimeIntervalID = 1,
                    WidgetTypeID = 1,
                    UserID = "test",
                    ElementsCount = 1,
                    ScrollingSpeed = 1
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
                StatisticWidgetsControllerFortest controller = new StatisticWidgetsControllerFortest(context, null, null, null, "test");

                Guid id = Guid.NewGuid();
                context.StatisticWidget.Add(new StatisticWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Url = $"http/localhost/StatisticWidgets/Display/{id}",
                    Name = "Test",
                    DirectionID = 1,
                    TextStyleID = 1,
                    DisplayModeID = 1,
                    TimeIntervalID = 1,
                    WidgetTypeID = 1,
                    UserID = "test",
                    ElementsCount = 1,
                    ScrollingSpeed = 1
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
                StatisticWidgetsController controller = new StatisticWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.StatisticWidget.Add(new StatisticWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DirectionID = 1,
                    TextStyleID = 1,
                    DisplayModeID = 1,
                    TimeIntervalID = 1,
                    WidgetTypeID = 1,
                    UserID = "test",
                    ElementsCount = 1,
                    ScrollingSpeed = 1
                });

                context.SaveChanges();
                if (context.StatisticWidget.FindAsync(id) == null)
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
                StatisticWidgetsController controller = new StatisticWidgetsController(context, null, null, null);

                Guid id = Guid.NewGuid();
                context.StatisticWidget.Add(new StatisticWidget()
                {
                    ID = id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Test",
                    DirectionID = 1,
                    TextStyleID = 1,
                    DisplayModeID = 1,
                    TimeIntervalID = 1,
                    WidgetTypeID = 1,
                    UserID = "test",
                    ElementsCount = 1,
                    ScrollingSpeed = 1
                });

                context.SaveChanges();
                if (context.StatisticWidget.FindAsync(id) == null)
                {
                    Assert.Fail();

                }
                var foo = controller.DeleteConfirmed(id).Result;

                if (context.StatisticWidget.Find(id) == null)
                {
                    Assert.Pass();
                }
            }

        }
    }
}
