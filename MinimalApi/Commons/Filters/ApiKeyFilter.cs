namespace MinimalApi.Commons.Filters;

public class ApiKeyFilter : IEndpointFilter
{
    private const string ApiKeyHeader = "X-API-Key";
    private const string ApiKeyKeyConfig = "ApiKeys";

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var extractedApiKey))
            return Results.Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: "API Key was not provided",
                type: "https://tools.ietf.org/html/rfc7235#section-3.1");

        var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKeysSection = appSettings.GetSection(ApiKeyKeyConfig);
        var apiKeys = apiKeysSection.Get<string[]>();

        if (apiKeys is null)
            return Results.Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "A problem occurred while validating the api key configuration.");

        if (apiKeys.All(key => key != extractedApiKey))
            return Results.Problem(
                statusCode: StatusCodes.Status403Forbidden,
                title: "Invalid API Key provided",
                type: "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.3");

        return await next(context);
    }
}