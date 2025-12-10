using NHS_Validator.NHS.Validation;
using NHS_Validator.NHS.Regions;
using Xunit;
using NHS_Validator.NHS;

namespace PDS_Tracer.NHS.Tests.Validation
{
    public class NHSNumberTests
    {
        [Theory]
        [InlineData("943 476 5919")]
        [InlineData("9434765919")]
        [InlineData("943-476-5919")]
        public void Valid_NHS_numbers_should_parse(string nhsNumber)
        {
            // Act
            var result = NHSNumber.TryParse(nhsNumber, out var nhs);

            // Assert
            Assert.True(result);
            Assert.NotNull(nhs);
            Assert.Equal(nhsNumber, nhs!.NormalisedValue);
        }

        [Theory]
        [InlineData("9434765918")] // wrong checksum
        [InlineData("1234567890")] // invalid checksum
        [InlineData("abcdefghij")]
        [InlineData("")]
        [InlineData(null)]
        public void Invalid_NHS_numbers_should_fail_to_parse(string nhsNumber)
        {
            // Act
            var result = NHSNumber.TryParse(nhsNumber, out var nhs);

            // Assert
            Assert.False(result);
            Assert.Null(nhs);
        }

        [Fact]
        public void NHS_number_with_invalid_length_should_fail()
        {
            Assert.False(NHSNumber.TryParse("123456789", out _));
            Assert.False(NHSNumber.TryParse("12345678901", out _));
        }

        [Fact]
        public void Valid_NHS_number_should_fail_region_check_if_outside_region()
        {
            var region = new EnglandRegion();

            // Starts with 9 → fails placeholder England rule
            var nhsNumber = "9434765919";

            var result = NHSNumber.TryParse(nhsNumber, out var nhs, region);

            Assert.False(result);
            Assert.Null(nhs);
        }

        [Fact]
        public void Valid_NHS_number_should_pass_region_check_when_inside_region()
        {
            var region = new EnglandRegion();

            // NOTE:
            // This MUST be a genuinely valid NHS number that also
            // matches your EnglandRegion rule.
            var nhsNumber = "4561261237"; // valid checksum, starts with 4

            var result = NHSNumber.TryParse(nhsNumber, out var nhs, region);

            Assert.True(result);
            Assert.NotNull(nhs);
        }
    }
}
