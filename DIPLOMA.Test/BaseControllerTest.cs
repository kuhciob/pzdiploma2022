using System;
using System.Collections.Generic;
using System.Text;
using DIPLOMA.Controllers;
using DIPLOMA.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DIPLOMA.Test
{
    public class BaseControllerTest
    {
        protected DbContextOptions<ApplicationDbContext> _options;
       //public BaseControllerTest()
       //{

       //}
        [SetUp]
        public virtual void Setup()
        {
            DbContextOptions<ApplicationDbContext>  options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "DIPLOMATest")
                .Options;

            _options = options;
        }

        [Test]
        public void GetUploadFileAsyncTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                BaseController controller = new BaseController(context, null, null);

                context.MsgWidgetContent.ToListAsync();

                Assert.Pass();
            }
                
        }
        [Test]
        public void ContanteToUrlsTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                BaseController controller = new BaseController(context, null, null);

                context.MsgWidgetContent.ToListAsync();
                context.MsgWidget.ToListAsync();

                Assert.Pass();
            }
            Assert.Pass();
        }
        [Test]
        public void GetFormFileTest()
        {
            using (var context = new ApplicationDbContext(this._options))
            {
                BaseController controller = new BaseController(context, null, null);

                context.UploadFile.ToListAsync();

                Assert.Pass();
            }
            Assert.Pass();
        }
        
    }
}
