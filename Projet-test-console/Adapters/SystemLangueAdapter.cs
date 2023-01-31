using System.Globalization;
namespace OHCE.Console.Adapters
{
    internal class SystemLangueAdapter 
    {

        public static ILangue langueSystem
            => CultureInfo.InstalledUICulture.TwoLetterISOLanguageName switch
            {
                "fr" => new Langues.LangueFrançaise(),
                "en" => new Langues.LangueAnglaise(),
                //    < 12 => PériodeJournée.Matin,
            };
   
    }
}
