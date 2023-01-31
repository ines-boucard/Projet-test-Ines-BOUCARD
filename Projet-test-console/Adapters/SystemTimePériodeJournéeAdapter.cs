namespace OHCE.Console.Adapters
{
    internal static class SystemTimePériodeJournéeAdapter
    {
        public static PériodeJournée PériodeActuelle
            => DateTime.Now.Hour switch
               {
                   < 6  => PériodeJournée.Nuit,
                   < 12 => PériodeJournée.Matin,
                   < 18 => PériodeJournée.AprèsMidi,
                   < 21 => PériodeJournée.Soir,
                   _    => PériodeJournée.Nuit
               };
    }
}
