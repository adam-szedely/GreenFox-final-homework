using GreenFoxFinalHomework.Database;
using Moq;
using GreenFoxFinalHomework.Models;
using GreenFoxFinalHomework.Services;
using AutoFixture;

namespace GreenFoxFinalHomework_UnitTests;

public class ListingServiceTests
{
    private ListingService _listingService;
    private readonly Mock<IApplicationDbContext> _mockAppDbContext = new Mock<IApplicationDbContext>(); 

    public ListingServiceTests()
    {
        _listingService = new ListingService(_mockAppDbContext.Object);
    }

    [Fact]
    public void EmptyList_ListItems_ShouldReturnEmptyList()
    {
        var dataSet = new List<Item>  
            {
            }.AsQueryable();

        var data = MoqDataSetup.SetupMockSet<Item>(dataSet); 

        _mockAppDbContext.Setup(c => c.Items).Returns(data.Object);   

        var actual = _listingService.ListItems();

        Assert.Equal(dataSet.Count(), actual.Count());
    }

    [Fact]
    public void ListOfOne_ListItems_ShouldReturnListWithOneEntry()
    {
        Fixture fixture = new Fixture();
        var dataSet = new List<Item>
        {
            new Item()
        }.AsQueryable();

        var data = MoqDataSetup.SetupMockSet<Item>(dataSet);

        _mockAppDbContext.Setup(c => c.Items).Returns(data.Object);

        var actual = _listingService.ListItems();

        Assert.Equal(dataSet.Count(), actual.Count());
    }

    [Fact]
    public void ListOfTen_ListItems_ShouldReturnListWithTenEntries()
    {
        var dataSet = new List<Item>
        {
             new Item()
        }.AsQueryable();

        var data = MoqDataSetup.SetupMockSet<Item>(dataSet);

        _mockAppDbContext.Setup(c => c.Items).Returns(data.Object);

        var actual = _listingService.ListItems();

        Assert.Equal(dataSet.Count(), actual.Count());
    }
}
