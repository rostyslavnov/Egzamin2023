using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Ezgamin2023Test;

public class Egzamin2023Test: IClassFixture<WebApplicationFactory<Program>>
{
    
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;
    private int _points;

    public Egzamin2023Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
    
    [Theory]
    [InlineData("/exam/index")]
    [InlineData("/exam/create")]
    [InlineData("/exam/update")]
    [InlineData("/exam/delete")]
    public async void Test01(string path)
    {
        //Arrange
        
        //Act
        var result = await _client.GetAsync(path);
    
        //Assert
        //string content = await result.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
    
    [Fact]
    public async void Test02()
    {
        var result = await _client.GetAsync($"/exam/index");
        //Assert
        string content = await result.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Contains("<h2>Exam Index</h2>", content);
    }
}