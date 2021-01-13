using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class Min18YearsIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

             if (customer.MembershipTypeId == MembershipType.PAYASYOUGO || customer.MembershipTypeId == MembershipType.UNKNOWN)
                return ValidationResult.Success;

             if(customer.BirthDate == null)
                return new ValidationResult("Birthdate is requiured");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 year old");



        }
    }
}