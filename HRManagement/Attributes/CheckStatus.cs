using System.ComponentModel.DataAnnotations;
namespace HRManagement.Attributes
{
    public class CheckStatus
    {
        public class CheckStatusAttribute : ValidationAttribute
        {
            private readonly string[] _statuslist;
            public CheckStatusAttribute(string[] statuslist)
            {
                _statuslist = statuslist;
            }
            protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
            {
                if (!_statuslist.Contains(value))
                {
                    var statusListString = string.Join(", ", _statuslist);
                    return new ValidationResult($"Status must be one of the following values: {statusListString}.");
                }
                return ValidationResult.Success;
            }
        }
    }
}
