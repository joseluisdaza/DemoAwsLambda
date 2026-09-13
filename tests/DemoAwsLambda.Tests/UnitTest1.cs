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

        Assert.Throws<ArgumentException>(() => function.FunctionHandler(new PersonRequest(), null!));
    }
}