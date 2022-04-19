using FluentValidation.Results;

namespace SSGP.Application.Core;

public class ValidationException : ApplicationException
{
    public ValidationException(IEnumerable<ValidationFailure> failures) : base(
        "Process couldn't be processed due to validation failures.")
    {
        Failures = failures;
    }
    
    public IEnumerable<ValidationFailure> Failures { get; }
}