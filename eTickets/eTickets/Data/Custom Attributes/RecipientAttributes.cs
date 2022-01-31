using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Custom_Attributes
{
    public class RecipientAttributes
    {
        public class DateGreaterThanTodayAttribute : ValidationAttribute
        {
            public DateGreaterThanTodayAttribute() : base("{0}Date should be greater than current date")
            {

            }
            public override bool IsValid(object value)
            {
                DateTime propValue = Convert.ToDateTime(value);
                if (propValue >= DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
