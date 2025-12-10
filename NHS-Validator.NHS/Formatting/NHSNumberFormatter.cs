namespace NHS_Validator.NHS.Formatting
{
    internal static class NHSNumberFormatter
    {
        public static string? Standardise(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string cleaned = new string(input.Where(char.IsDigit).ToArray());

            return cleaned.Length == 10 ? cleaned : null;
        }
    }
}
