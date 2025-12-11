using NHSValidator.NHS.Formatting;
using NHSValidator.NHS.Regions;
using NHSValidator.NHS.Validation;

namespace NHSValidator.NHS
{
    public sealed class NHSNumber
    {
        /// <summary>
        /// The NHS number in normalised form (10 digits, no spaces/dashes).
        /// </summary>
        public string NormalisedValue { get; }

        /// <summary>
        /// Optionally keep what the user originally typed.
        /// </summary>
        public string RawValue { get; }

        private NHSNumber(string normalisedValue, string rawValue)
        {
            NormalisedValue = normalisedValue;
            RawValue = rawValue;
        }

        public static bool TryParse(
            string input,
            out NHSNumber? nhsNumber,
            Region? region = null)
        {
            nhsNumber = null;

            string? normalised = NHSNumberFormatter.Standardise(input);
            if (normalised is null)
            {
                return false;
            }

            if (!NHSNumberValidator.IsValid(normalised, region))
            {
                return false;
            }

            nhsNumber = new NHSNumber(normalised, input);
            return true;
        }

        public override string ToString() => NormalisedValue;
    }
}
