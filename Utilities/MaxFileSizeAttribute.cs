using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.Models
{
    public static class TempDataExtension
    {
        public static void Put<T>(this ITempDataDictionary tempData, string Key, T value) where T : class
        {
            tempData[Key] = JsonConvert.SerializeObject(value);
        }
        public static T Get<T>(this ITempDataDictionary tempData, string Key) where T : class
        {
            tempData.TryGetValue(Key, out object o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        public static T Peek<T>(this ITempDataDictionary tempData, string Key) where T : class
        {
            object o = tempData.Peek(Key);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
    public class MaxFileSizeAttribute: ValidationAttribute
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if(file != null)
            {
                if(file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
             
        }
        public string GetErrorMessage()
        {
            return $"Maximum allowed fle size is {_maxFileSize} megabytes";
    }
    }
   
}
