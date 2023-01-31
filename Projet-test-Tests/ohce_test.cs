using OHCE.Test.xUnit.Utilities.Builders;
using Xunit;

namespace Projet_test_Tests
{
    public class ohce_test
    {
        [Fact(DisplayName = "QUAND on saisit une cha�ne ALORS celle-ci est renvoy�e en miroir")]
        public void MiroirTest()
        {
            // Arrange :
            var ohce = OhceBuilder.Default;

            // Act : QUAND on entre une cha�ne de caract�re
            var sortie = ohce.Palindrome("loire");

            // Assert : ALORS elle est renvoy�e en miroir
            Assert.Contains("eriol", sortie);
        }

    }
}