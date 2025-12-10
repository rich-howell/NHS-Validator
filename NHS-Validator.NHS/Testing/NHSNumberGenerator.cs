using NHS_Validator.NHS.Regions;
using NHS_Validator.NHS.Validation;

namespace NHS_Validator.NHS.Testing
{
    /// <summary>
    /// Generates valid or invalid NHS numbers for testing purposes ONLY.
    /// 
    /// IMPORTANT:
    /// This must never be used to create real NHS numbers.
    /// All live NHS numbers are allocated centrally.
    /// </summary>
    public static class NHSNumberGenerator
    {
        private static readonly Random _random = new();

        public static IReadOnlyList<string> Generate(
            bool valid = true,
            Region? region = null,
            int quantity = 1)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            var results = new List<string>(quantity);

            while (results.Count < quantity)
            {
                var identifier = GenerateNineDigits(region);

                var checksum = NHSNumberValidator.CalculateChecksum(identifier);
                if (!checksum.HasValue)
                    continue;

                string nhsNumber;

                if (valid)
                {
                    nhsNumber = identifier + checksum.Value;
                }
                else
                {
                    int wrongChecksum;
                    do
                    {
                        wrongChecksum = _random.Next(0, 10);
                    }
                    while (wrongChecksum == checksum.Value);

                    nhsNumber = identifier + wrongChecksum;
                }

                results.Add(nhsNumber);
            }

            return results;
        }

        private static string GenerateNineDigits(Region? region)
        {
            // For now, region-based ranges are naive.
            // This mirrors your placeholder Region logic.
            char firstDigit = region switch
            {
                EnglandRegion => _random.Next(4, 6).ToString()[0],
                _ => _random.Next(1, 10).ToString()[0]
            };

            var chars = new char[9];
            chars[0] = firstDigit;

            for (int i = 1; i < 9; i++)
            {
                chars[i] = (char)('0' + _random.Next(0, 10));
            }

            return new string(chars);
        }
    }
}
