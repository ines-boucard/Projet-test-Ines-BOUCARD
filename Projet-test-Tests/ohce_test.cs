using OHCE.Test.xUnit.Utilities.Builders;
using Xunit;

namespace Projet_test_Tests
{
    public class ohce_test
    {
        [Fact(DisplayName = "QUAND on saisit une chaîne ALORS celle-ci est renvoyée en miroir")]
        public void MiroirTest()
        {
            // Arrange :
            var ohce = OhceBuilder.Default;

            // Act : QUAND on entre une chaîne de caractère
            var sortie = ohce.Palindrome("loire");

            // Assert : ALORS elle est renvoyée en miroir
            Assert.Contains("eriol", sortie);
        }

    }
}