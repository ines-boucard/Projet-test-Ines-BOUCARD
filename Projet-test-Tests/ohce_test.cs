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
        new LangueFran�aise()
};

        private static readonly IEnumerable<P�riodeJourn�e> P�riodes = new P�riodeJourn�e[]
        {
        P�riodeJourn�e.Matin,
        P�riodeJourn�e.Apr�sMidi,
        P�riodeJourn�e.Soir,
        P�riodeJourn�e.Nuit,
        P�riodeJourn�e.Defaut
        };

        public static IEnumerable<object[]> LanguesSeules => new CartesianData(Langues);
        public static IEnumerable<object[]> LanguesEtP�riodes => new CartesianData(Langues, P�riodes);

        [Fact(DisplayName = "QUAND on saisit une cha�ne ALORS celle-ci est renvoy�e en miroir")]
        public void Miroir_Test()
        {
            // Arrange :
            var ohce = OhceBuilder.Default;

            // Act : QUAND on entre une cha�ne de caract�re
            var sortie = ohce.Palindrome("loire");

            // Assert : ALORS elle est renvoy�e en miroir
            Assert.Contains("eriol", sortie);
        }

        [Theory(DisplayName = "ETANT DONNE un utilisateur parlant une langue QUAND on entre un palindrome ALORS il est renvoy� ET le bienDit de cette langue est envoy�")]
        [MemberData(nameof(LanguesSeules))]
        public void Palindrome_Test(ILangue langue)
        {
            // Arrange : ETANT DONNE un utilisateur parlant "langue"
            var ohce = new OhceBuilder().AyantPourLangue(langue).Build();

            // Act : QUAND on entre un palindrome
            const string palindrome = "coloc";
            var sortie = ohce.Palindrome(palindrome);

            // Assert : ALORS il est renvoy�
            // ET "bienDit" en "langue" est envoy�
            Assert.Contains(palindrome + langue.BienDit,sortie);
        }


    }
}