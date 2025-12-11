namespace NHSValidator.NHS.Regions
{
    public abstract class Region
    {
        public abstract bool ContainsNumber(string nhsNumber);
    }
}
