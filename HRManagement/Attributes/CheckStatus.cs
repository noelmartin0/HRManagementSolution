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
                if ((string) value == "string")
                {
                    Console.WriteLine("Working");
                    return ValidationResult.Success;
                }
                else if (!_statuslist.Contains(value))
                {
                    var statusListString = string.Join(", ", _statuslist);
                    return new ValidationResult($"Input must be one of the following: {statusListString}.");
                }
                else
                    return ValidationResult.Success;
            }
        }
    }
}
