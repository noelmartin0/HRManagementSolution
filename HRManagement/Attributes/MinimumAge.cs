using System.ComponentModel.DataAnnotations;

namespace HRManagement.Attributes
{
    public class MinimumAge
    {
        public class MinimumAgeAttribute : ValidationAttribute
        {
            private readonly int _minimumAge;

            public MinimumAgeAttribute(int minimumAge)
            {
                _minimumAge = minimumAge;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime dateOfBirth)
                {
                    var today = DateTime.Today;
                    var age = today.Year - dateOfBirth.Year;

                    // Adjust age if the birthday has not occurred yet this year
                    if (dateOfBirth.Date > today.AddYears(-age)) age--;

                    if (age < _minimumAge)
                    {
                        return new ValidationResult($"Minimum age required is {_minimumAge} years.");
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}
