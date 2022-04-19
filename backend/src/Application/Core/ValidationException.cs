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
    public override IEnumerable<KeyValuePair<string, object?>> Extensions()
    {
        yield return new KeyValuePair<string, object?>(nameof(Failures), Failures);
    }
}