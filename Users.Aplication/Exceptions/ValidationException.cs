namespace Users.Aplication.Exceptions ;
using FluentValidation.Results;

    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("Se presentaron los siguientes errores")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(fg => fg.Key, fg => fg.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
