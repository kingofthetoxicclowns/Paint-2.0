using CommandsLib;
using EntitiesLib;
using GeometryUtils;
using Paint_2._0.IO;

namespace Tests.IO
{
    [TestClass]
    public class IOTest()
    {
        [TestMethod]
        public void MakeFileFilter()
        {
            var expectedFilterString = "svg|*.svg|jpeg|*.jpeg|png|*.png";

            var filterString = Paint_2._0.IO.IO.MakeFileFilter();

            Assert.AreEqual(expectedFilterString, filterString);
        }
    }
}
