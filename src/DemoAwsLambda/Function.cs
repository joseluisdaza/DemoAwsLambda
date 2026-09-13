using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace DemoAwsLambda;

public class Function
{
    public string FunctionHandler(PersonRequest request, ILambdaContext context)
    {
        var name = request.Name?.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The request must contain a non-empty name.", nameof(request.Name));
        }

        return $"hello {name}, thanks for your Request.";
    }
}

public class PersonRequest
{
    public string? Name { get; set; }
}
