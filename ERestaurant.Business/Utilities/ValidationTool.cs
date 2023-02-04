using FluentValidation;
using ERestaurant.Business.ValidationRules.FluentValidation;
using ERestaurant.Entities.Concrete;
using ERestaurant.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace ERestaurant.Business.Utilities
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) 
        {
         var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (result.Errors.Count > 0 ) 
            { throw new ValidationException(result.Errors); }
        }
    }
}
