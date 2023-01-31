using OHCE;
using OHCE.Langues;
using OHCE.Test.xUnit.Utilities;
using OHCE.Test.xUnit.Utilities.Builders;
using System.Collections.Generic;
using Xunit;

namespace Projet_test_Tests
{
    public class ohce_test
    {

        private static readonly IEnumerable<ILangue> Langues = new ILangue[]
{
        new LangueAnglaise(),
        new LangueFrançaise()
};

        private static readonly IEnumerable<PériodeJournée> Périodes = new PériodeJournée[]
        {
        PériodeJournée.Matin,
        PériodeJournée.AprèsMidi,
        PériodeJournée.Soir,
        PériodeJournée.Nuit,
        PériodeJournée.Defaut
        };

        public static IEnumerable<object[]> LanguesSeules => new CartesianData(Langues);
        public static IEnumerable<object[]> LanguesEtPériodes => new CartesianData(Langues, Périodes);

        [Fact(DisplayName = "QUAND on saisit une chaîne ALORS celle-ci est renvoyée en miroir")]
        public void Miroir_Test()
        {
            // Arrange :
            var ohce = OhceBuilder.Default;

            // Act : QUAND on entre une chaîne de caractère
            var sortie = ohce.Palindrome("loire");

            // Assert : ALORS elle est renvoyée en miroir
            Assert.Contains("eriol", sortie);
        }

        [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue QUAND on entre un palindrome ALORS il est renvoyé ET le bienDit de cette langue est envoyé")]
        [MemberData(nameof(LanguesSeules))]
        public void Palindrome_Test(ILangue langue)
        {
            // Arrange : ETANT DONNE un utilisateur parlant "langue"
            var ohce = new OhceBuilder().AyantPourLangue(langue).Build();

            // Act : QUAND on entre un palindrome
            const string palindrome = "coloc";
            var sortie = ohce.Palindrome(palindrome);

            // Assert : ALORS il est renvoyé
            // ET "bienDit" en "langue" est envoyé
            Assert.Contains(palindrome + langue.BienDit,sortie);
        }

        [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue ET que la période de la journée est période QUAND l'app démarre ALORS bonjour de cette langue à cette période est envoyé")]
        [MemberData(nameof(LanguesEtPériodes))]
        public void Bonjour_Test(ILangue langue, PériodeJournée période)
        {
            // Arrange : ETANT DONNE un utilisateur parlant une langue
            // ET que la période de la journée est "période"
            var ohce = new OhceBuilder().AyantPourLangue(langue).AyantPourPériodeDeLaJournée(période).Build();

            // Act : QUAND l'app démarre
            var sortie = ohce.Palindrome(string.Empty);

            // Assert : ALORS "bonjour" de cette langue à cette période est envoyé
            Assert.StartsWith(langue.DireBonjour(période), sortie);
        }

        [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue QUAND l'app se ferme  ALORS auRevoir dans cette langue est envoyé")]
        [MemberData(nameof(LanguesSeules))]
        public void Fermeture_Test(ILangue langue)
        {
            // Arrange : ETANT DONNE un utilisateur parlant une langue
            var ohce = new OhceBuilder().AyantPourLangue(langue).Build();

            // Act : QUAND l'app démarre
            var sortie = ohce.Palindrome(string.Empty);

            // Assert : ALORS auRevoir dans cette langue est envoyé
            Assert.EndsWith(langue.AuRevoir, sortie);
        }



    }
}