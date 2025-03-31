using DAL_Core;
using DAL_Core.Entities;
using DAL_Core.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using TreatmentBL.Models;

namespace IntegrationTests.Controllers;
public class TreatmentControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceScopeFactory _factory;

    public TreatmentControllerTests(WebApplicationFactory<Program> factory)
    {
        var webApplicationFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PetStoreDbContext>();
                    context.Database.EnsureCreated();
                }
            });
        });

        _httpClient = factory.CreateClient();
        _factory = webApplicationFactory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    [Fact]
    public async Task GetAllTreatments_ShouldReturnCollection()
    {
        //Arrange

        //Act
        var response = await _httpClient.GetAsync("api/treatment");

        //Assert
        response.EnsureSuccessStatusCode();
        
        var treatments = await response.Content.ReadFromJsonAsync<List<TreatmentDto>>();
        Assert.NotEmpty(treatments);
    }

    [Fact]
    public async Task AddNewTreatment_ShouldReturnTreatmentId()
    {
        //Arrange
        using var scope = _factory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<PetStoreDbContext>();

        var vendorId = Guid.NewGuid();
        var storeId = Guid.NewGuid();
        var petId = Guid.NewGuid();

        var treatmentId = Guid.NewGuid();

        var vendor = new Vendor
        {
            Id = vendorId,
            Name = $"Vendor {vendorId}",
            Description = "Description",
            ContractType = ContractType.BuyBackAgreement
        };

        var store = new Store
        {
            Id = storeId,
            Name = $"Store {storeId}",
            Description = "Description",
            Address = "Address",
            City = "City"
        };

        var pet = new Pet
        {
            Id = petId,
            Name = $"Pet {petId}",
            Breed = "ShowShu",
            Type = PetTypes.Cat,
            StoreId = storeId
        };

        await context.Vendors.AddAsync(vendor);
        await context.Stores.AddAsync(store);
        await context.Pets.AddAsync(pet);
        await context.SaveChangesAsync();

        var treatmentDto = new TreatmentDto
        {
            Name = $"Treatment {treatmentId}",
            InjectedAt = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddYears(1),
            PetId = petId,
            VendorId = vendorId
        };

        //Act
        var response = await _httpClient.PostAsJsonAsync("api/treatment", treatmentDto);

        //Assert
        response.EnsureSuccessStatusCode();

        var treatment = await context.HealthCares.FirstOrDefaultAsync(x => x.TreatmentName.EndsWith(treatmentId.ToString()));

        Assert.NotNull(treatment);

        var result = await response.Content.ReadFromJsonAsync<Guid>();
        Assert.NotNull(result);
        Assert.NotEqual(result, Guid.Empty);
    }
}
