using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VismaHomework.Services.ConsoleWriter;
using VismaHomework.Services.Filter;

namespace VismaHomework.tests
{
    [TestClass]
   public class ConsoleWriterTest
    {
        IFilterMenu _filterMenu;
        [TestInitialize]
        public void Setup() {
            var filterMenuMock = new Mock<IFilterMenu>();
            _filterMenu = filterMenuMock.Object;
        }
        [TestMethod]
        public void Write() {
            var cw = new ConsoleWriter(_filterMenu);
            try
            {
                cw.Write("test");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void WriteBooksTable()
        {
            var cw = new ConsoleWriter(_filterMenu);
            try
            {
                cw.WriteBooksTable();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
