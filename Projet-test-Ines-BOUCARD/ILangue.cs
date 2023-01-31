namespace OHCE
{
    public interface ILangue
    {
        //string Langue { get; set; }
        public string BienDit { get; }
        string DireBonjour(PériodeJournée période);
        string AuRevoir { get; }
    }
}
