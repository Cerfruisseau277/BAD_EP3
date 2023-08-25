using System.ComponentModel.DataAnnotations;

namespace MVC_Carshaing_EP3.CustomValidator
{
    public class DateAfterTommorow : ValidationAttribute { 
        /* link stackoverflow https://stackoverflow.com/questions/8844747/restrict-datetime-value-with-data-annotations */
        public override bool IsValid(object datum)// Return a boolean value: true == IsValid, false != IsValid
        {
            DateTime d = Convert.ToDateTime(datum);
            return d > DateTime.Now;
        }
    }
}
