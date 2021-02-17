using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //tek bir instance oluştursun diye static
    public static class ValidationTool
    {
        //burada fluent in validate interfaini kullandık bir daha bak
        public static void Validate(IValidator validator,object entity) 
        {
            var Context = new ValidationContext<object>(entity);
            var result = validator.Validate(Context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
