using Domain.DTO.IsSimianDTO;
using Domain.DTO.IsSimianDTO.Validators;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using SimianApplication.Controllers;
using System;

using System.Threading.Tasks;
using Xunit;

namespace SimianApplication.Test.Controllers
{
    public class SimianControllerTests
    {
        private readonly SimianController _sut;
        private readonly MockRepository _mock;
        private readonly Mock<ISimianService> _mockSimianService;

        public SimianControllerTests()
        {
            _mock = new MockRepository(MockBehavior.Loose);
            _mockSimianService = _mock.Create<ISimianService>();
            _sut = new SimianController(_mockSimianService.Object);
        }

        [Fact]
        public async Task Post_StateUnderTest_ExpectedBehavior_ReturnTrueDnaResult()
        {
            // Arrange
            string[] dna = new string[] {
                "CTGAGA", "CTATGC", "TATTGT", "AGAGGG", "CCCCTA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            _mockSimianService.Setup(c => c.VerifyDnaAsync(data)).ReturnsAsync(new IsSimianResponseDTO(true));

            // Act
            var result = await _sut.Post(data);

            // Assert
            Assert.True(result.IsSimian);
            _mockSimianService.Verify(c => c.VerifyDnaAsync(data), Times.Once);
        }

        [Fact]
        public async Task Post_StateUnderTest_ExpectedBehavior_ReturnFalseDnaResult()
        {
            // Arrange
            string[] dna = new string[] {
                "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "TCACTG"
            };
            IsSimianRequestDTO data = new IsSimianRequestDTO() { Dna = dna };
            _mockSimianService.Setup(c => c.VerifyDnaAsync(data)).ReturnsAsync(new IsSimianResponseDTO(false));

            // Act
            var result = await _sut.Post(data);

            // Assert
            Assert.False(result.IsSimian);
            _mockSimianService.Verify(c => c.VerifyDnaAsync(data), Times.Once);
        }
    }
}
