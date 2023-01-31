using System.Text;

namespace OHCE;

public class Ohce
{
    private readonly ILangue _langue;
    private readonly PériodeJournée _périodeJournée;

    public Ohce(ILangue langue, PériodeJournée périodeJournée)
    {
        _langue = langue;
        _périodeJournée = périodeJournée;
    }

    public string Palindrome(string input)
    {
        var stringBuilder = 
            new StringBuilder();

        stringBuilder.Append(Saluer());

        var reversed = new string(
            input.Reverse().ToArray()
        );

        stringBuilder.Append(reversed);

        if (reversed.Equals(input))
            stringBuilder.Append(_langue.BienDit);

        stringBuilder.Append(AuRevoir());

        return stringBuilder.ToString();
    }
    public string Saluer()
    {
        var bonjour = _langue.DireBonjour(_périodeJournée);
        return bonjour;
    }
    public string AuRevoir()
    {
        var aurevoir = _langue.AuRevoir;
        return aurevoir;
    }
}