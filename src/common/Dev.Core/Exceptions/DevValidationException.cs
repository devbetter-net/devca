
using FluentValidation.Results;

namespace Dev.Core.Exceptions;

public class DevValidationException : Exception
{
    public List<string> ValdationErrors { get; set; }

    public DevValidationException(ValidationResult validationResult)
    {
        ValdationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors)
        {
            ValdationErrors.Add(validationError.ErrorMessage);
        }
    }
}