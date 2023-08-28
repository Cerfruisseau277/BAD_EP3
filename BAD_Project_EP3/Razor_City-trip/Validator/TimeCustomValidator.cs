using System.ComponentModel.DataAnnotations;

namespace Razor_City_trip.Validator
{
    public class TimeCustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startTime = (TimeSpan)value;

            var endTimeProperty = validationContext.ObjectType.GetProperty("EndTime");
            TimeSpan endTime = (TimeSpan)endTimeProperty.GetValue(validationContext.ObjectInstance);

            if (startTime < endTime)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "Start time must be before end time.");
            }
        }
    }
}
