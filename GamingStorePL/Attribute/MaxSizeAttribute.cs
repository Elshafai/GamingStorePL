using System.ComponentModel.DataAnnotations;

namespace GamingStorePL.Attribute
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int allowedMaxSize;

        public MaxSizeAttribute(int allowedMaxSize)
        {
            this.allowedMaxSize = allowedMaxSize;
        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
           var File = value as IFormFile;
            if (File is not null)
            {
                if (File.Length > allowedMaxSize)
                {
                    return new ValidationResult($"Maxium allowed size is {allowedMaxSize} bytes");
                }
            }
            return ValidationResult.Success;
        }
    }
}
