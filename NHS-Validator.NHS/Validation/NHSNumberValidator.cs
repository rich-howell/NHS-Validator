using NHS_Validator.NHS.Regions;

namespace NHS_Validator.NHS.Validation
{
    internal static class NHSNumberValidator
    {
        internal static bool IsValid(string normalisedNhsNumber, Region? region = null)
        {
            if (string.IsNullOrEmpty(normalisedNhsNumber) || normalisedNhsNumber.Length != 10)
                return false;

            if (region != null && !region.ContainsNumber(normalisedNhsNumber))
                return false;

            var identifierDigits = normalisedNhsNumber[..9];
            int checkDigit = normalisedNhsNumber[9] - '0';

            var checksum = CalculateChecksum(identifierDigits);

            return checksum.HasValue && checksum.Value == checkDigit;
        }

        internal static int? CalculateChecksum(string identifierDigits)
        {
            if (identifierDigits.Length != 9)
                return null;

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int digit = identifierDigits[i] - '0';
                sum += digit * (10 - i);
            }

            int checksum = 11 - (sum % 11);
            return checksum == 11 ? 0 : checksum;
        }
    }
}
