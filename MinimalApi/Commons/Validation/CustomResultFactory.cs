using FluentValidation.Results;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Results;

namespace MinimalApi.Commons.Validation;

public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IResult CreateResult(EndpointFilterInvocationContext context, ValidationResult validationResult)
    {
        var errors = validationResult.Errors
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        return Results.ValidationProblem(
            title: "One or more validation failures have occurred.",
            errors: errors);
    }
}