using NUnit.Framework;
using RoadStatus.Helpers;

namespace RoadStatus.Tests.Helpers
{
    public class ParametersHelperTests
    {
        [Test]
        public void ValidateParameter_WhenSendsNull_ShouldException()
        {
            Assert.That(() => ParametersHelper.ValidateParameters(null), Throws.Exception.Message.Contains("missing"));
        }

        [Test]
        public void ValidateParameter_WhenTheresNoParameters_ShouldException()
        {
            Assert.That(() => ParametersHelper.ValidateParameters(new string[]{}), Throws.Exception.Message.Contains("missing"));
        }

        [Test]
        public void ValidateParameter_WhenTheresOneParameter_ShouldNotException()
        {
            Assert.That(() => ParametersHelper.ValidateParameters(new string[]{"parameter1"}), Throws.Nothing);
        }


        [Test]
        public void ValidateParameter_WhenTheresMoreThanOneParameter_ShouldNotException()
        {
            Assert.That(() => ParametersHelper.ValidateParameters(
                new string[]{"parameter1", "parameter2", "parameter3"}), Throws.Nothing);
        }
    }
}
