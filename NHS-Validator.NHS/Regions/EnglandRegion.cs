namespace NHSValidator.NHS.Regions
{
    public sealed class EnglandRegion : Region
    {
        public override bool ContainsNumber(string nhsNumber) => nhsNumber.StartsWith("4") || nhsNumber.StartsWith("5");
    }
}
