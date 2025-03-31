using AutoMapper;
using DAL_Core.Entities;
using Moq;
using TreatmentBL.Models;
using TreatmentBL.Services;
using TreatmentDal.Repositories.Interfaces;

namespace UnitTreatmentTests.Services;
public class TreatmentServiceTests
{
    private readonly Mock<IHealthCareRepository> _repository;
    private readonly Mock<IMapper> _mapper;
    private readonly TreatmentService _service;

    public TreatmentServiceTests()
    {
        _repository = new Mock<IHealthCareRepository>();
        _mapper = new Mock<IMapper>();

        _service = new TreatmentService(_repository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetTreatmentStatus_WhenTreatmentIsExpired_ShouldReturnTrue()
    {
        //Arrange
        var treatmentId = Guid.NewGuid();
        var healthCare = new HealthCare { Id = treatmentId, ExpirationDate = DateTime.UtcNow.AddDays(-1) };
        var treatmentDto = new TreatmentDto { IsExpired = true };

        _repository.Setup(x => x.GetHealthCareWithDetails(treatmentId))
            .ReturnsAsync(healthCare);

        _mapper.Setup(x => x.Map<TreatmentDto>(healthCare))
            .Returns(treatmentDto);

        //Act
        var result = await _service.GetTreatmentStatus(treatmentId);

        //Assert
        _repository.Verify(x => x.GetHealthCareWithDetails(It.IsAny<Guid>()), Times.Once());
        _mapper.Verify(x => x.Map<TreatmentDto>(It.IsAny<HealthCare>()), Times.Once());

        Assert.True(result);
    }

    [Fact]
    public async Task GetTreatmentStatus_WhenTreatmentNotFound_ShouldThrowException()
    {
        //Arrange
        _repository.Setup(x => x.GetHealthCareWithDetails(It.IsAny<Guid>())).ReturnsAsync((HealthCare)null).Verifiable();

        //Act-Assert
        await Assert.ThrowsAsync<Exception>(() => _service.GetTreatmentStatus(Guid.NewGuid()));
    }
}
