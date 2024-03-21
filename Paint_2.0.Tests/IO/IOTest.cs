using CommandsLib;
using EntitiesLib;
using GeometryUtils;
using Paint_2._0.IO;

namespace Tests.IO
{
    [TestClass]
    public class IOTest()
    {
       // [TestMethod]
        public void MakeFileFilter()
        {
           // List<string> FileFormats = ["svg", "jpeg", "png"];
            // Arrange
            var fileFormats = new List<string> { "svg", "jpeg", "png" };
            var expectedFilterString = "svg|*.svg|jpeg|*.jpeg|png|*.png";
            //var fileFormatHelper = new IO();

            // Act
         //  var filterString = IO.IO.MakeFileFilter();

            // Assert
            //Assert.AreEqual(expectedFilterString, filterString);


        }



    }
}
