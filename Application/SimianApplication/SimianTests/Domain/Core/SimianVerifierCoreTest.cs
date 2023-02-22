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

        public void IsSimianLinearSequential_a() 
        { 
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ctgaga", "agtcag", "actgtg", "ctaaaa","ctgagt", "ctgtct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSimianLinearSequential_t()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ctgaga", "agtcag", "actgtg", "ctatac", "cttttt", "ctgtct" };
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
            string[] dna = { "ctgaga", "atgcag", "atcgtg", "atatct", "ctgagt", "ctgtct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }
        //ccagta
        //atgcag
        //atcgag
        //agatgc
        //ctgagg
        //ctgtct
        [Fact]
        public void IsSimianColumnDiagonal()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccgata", "atgcag", "atcgag", "agatgc", "ctgagg", "ctgtct" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.True(result);
        }

        //ccagta
        //atgcag
        //Atcgag
        //aAatgc
        //ctAaga
        //ctgAct
        [Fact]
        public void IsSimianColumnDiagonal2()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccgata", "atgcag", "atcgag", "aaatgc", "ctaaga", "ctgact" };
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
        //cTgact
        [Fact]
        public void IsSimianColumnDiagonalReverse()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccagta", "atgcat", "ctcgtg", "aaatgc", "cttaga", "ctgact" };
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
        public void IsNotSimianColumnDiagonalReverse()
        {
            //Arrange
            ISimianVerifierCore Core = new SimianVerifierCore();
            string[] dna = { "ccagta", "atgcaa", "ctcgtg", "aaatgc", "cttaga", "ccgact" };
            //Act
            var result = Core.VerifyAsync(dna).Result;
            //Assert
            Assert.False(result);
        }

    }
}
