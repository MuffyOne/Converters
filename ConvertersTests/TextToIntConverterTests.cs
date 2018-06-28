using Converters;
using NUnit.Framework;

namespace ConvertersTests
{
    [TestFixture]
    public class TextToIntConverterTests
    {
        [Test]
        [TestCase("10", 10)]
        [TestCase("50", 50)]
        [TestCase("1", 1)]
        [TestCase("10000", 10000)]
        [TestCase("123456", 123456)]
        public void TextToIntConverter_PassText_IntIsReturnedCorrectly(string textToParse, int expectedResult)
        {
            //Arrange
            var intConverter = new TextToIntConverter();

            //Act
            object realResult = intConverter.ConvertBack(textToParse, null, null, null);

            //Assert
            Assert.AreEqual(expectedResult.GetType(), realResult.GetType());
            Assert.AreEqual(expectedResult, realResult);
        }
    }
}
