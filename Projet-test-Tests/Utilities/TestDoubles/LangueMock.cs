namespace OHCE.Test.xUnit.Utilities.TestDoubles
{
    internal record LangueMock : ILangue
    {
        public string BienDit { get; init; } = string.Empty;

        public string DireBonjour(PériodeJournée période) => string.Empty; 

        public string AuRevoir { get; init; } = string.Empty;
    }
}
