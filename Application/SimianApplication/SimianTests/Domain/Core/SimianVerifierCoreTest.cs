using SimianDomain.Core;
using SimianDomain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimianTests.Domain.Core
{
    public class SimianVerifierCoreTest
    {

        [Fact]

        public void IsSimianLinearSequential_a_g() 
        { 
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ctgaga", "agtcag", "actgtg", "ctaaaa","cggggt", "ctgtct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSimianLinearSequential_c_t()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccccga", "agtcag", "actgtg", "ctatac", "cttttt", "ctgtct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSimianColumnSequential()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ctgaga", "atgcag", "atcgtg", "atatcg", "ctgagg", "ctgtcg" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }
        //ccagta
        //atGcag
        //atcGag
        //agatGc
        //ctgagG
        //cgTTTT
        [Fact]
        public void IsSimianColumnDiagonalAndLinear()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccgata", "atgcag", "atcgag", "agatgc", "ctgagg", "cgtttt" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        //ccagta
        //Atgcag
        //Atcgag
        //AAatgc
        //AtAaga
        //ctgAct
        [Fact]
        public void IsSimianColumnDiagonalAndColumn()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccgata", "atgcag", "atcgag", "aaatgc", "ataaga", "ctgact" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        //ccagta
        //atgcaT
        //ctcgTg
        //aaaTgc
        //ctTaga
        //TTTTct
        [Fact]
        public void IsSimianColumnDiagonalReverseAndLinear()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccagta", "atgcat", "ctcgtg", "aaatgc", "cttaga", "ttttct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        //ccagta
        //atgcaa
        //ctcgTg
        //aaaTgc
        //ctTaga
        //ccgact
        [Fact]
        public void IsNotSimian()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccagta", "atgcaa", "ctcgtg", "aaatgc", "cttaga", "ccgact" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.False(result);
        }

        //CCCCta
        //atgcaa
        //ctcgTg
        //aaaTgc
        //ctTaga
        //ccgact
        [Fact]
        public void IsNotSimianWithOneSequence()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccccta", "atgcaa", "ctcgtg", "aaatgc", "cttaga", "ccgact" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.False(result);
        }
    }
}
