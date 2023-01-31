namespace OHCE.Langues
{
    public class LangueFrançaise : ILangue
    {
        /// <inheritdoc />
        public string BienDit => Expressions.Français.BienDit;

        /// <inheritdoc />
        public string DireBonjour(PériodeJournée période)
        {
            return période == PériodeJournée.Soir 
                ? Expressions.Français.Bonsoir 
                : Expressions.Français.Bonjour;
        }

        /// <inheritdoc />
        public string AuRevoir => Expressions.Français.AuRevoir;
    }
}
