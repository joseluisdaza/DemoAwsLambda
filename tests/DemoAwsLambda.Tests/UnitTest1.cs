namespace DemoAwsLambda.Tests;

public class FunctionTests
{
    [Fact]
    public void FunctionHandler_ReturnsGreeting_WhenNameIsProvided()
    {
        var function = new Function();
        var result = function.FunctionHandler(new PersonRequest { Name = "Jose" }, null!);

        Assert.Equal("hello Jose, thanks for your Request.", result);
    }

    [Fact]
    public void FunctionHandler_Throws_WhenNameIsMissing()
    {
        var function = new Function();

        var exception = Assert.Throws<ArgumentException>(() => function.FunctionHandler(new PersonRequest(), null!));
        Assert.Equal("Name", exception.ParamName);
        Assert.Contains("non-empty name", exception.Message);
    }

    [Fact]
    public void FunctionHandler_Throws_WhenRequestIsNull()
    {
        var function = new Function();

        var exception = Assert.Throws<ArgumentNullException>(() => function.FunctionHandler(null, null!));
        Assert.Equal("request", exception.ParamName);
    }

    [Fact]
    public void FunctionHandler_Throws_WhenNameIsWhitespaceOnly()
    {
        var function = new Function();

        var exception = Assert.Throws<ArgumentException>(() => function.FunctionHandler(new PersonRequest { Name = "   " }, null!));
        Assert.Equal("Name", exception.ParamName);
        Assert.Contains("non-empty name", exception.Message);
    }
}