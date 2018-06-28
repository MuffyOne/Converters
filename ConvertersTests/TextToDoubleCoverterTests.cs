using Converters;
using NUnit.Framework;

namespace ConvertersTests
{
    [TestFixture]
    public class TextToDoubleCoverterTests
    {
        [TestAttribute]
        [TestCase("1.0", 1.0)]
        [TestCase("0.5", 0.5)]
        [TestCase("1.1", 1.1)]
        [TestCase("100.00", 100.00)]
        [TestCase("12.3456", 12.3456)]
        public void TextToDoubleConverter_PassText_DoublesReturnedCorrectly(string textToParse, double expectedResult)
        {
            //Arrange
            var intConverter = new TextToDoubleConverter();

            //Act
            object realResult = intConverter.ConvertBack(textToParse, null, null, null);

            //Assert
            Assert.AreEqual(expectedResult.GetType(), realResult.GetType());
            Assert.AreEqual(expectedResult, realResult);
        }
    }
}
