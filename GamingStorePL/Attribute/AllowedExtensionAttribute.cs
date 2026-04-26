using System.ComponentModel.DataAnnotations;

namespace GamingStorePL.Attribute
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtension;

        public AllowedExtensionAttribute(string allowedExtension)
        {
           _allowedExtension = allowedExtension;
        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var Extension = Path.GetExtension(file.FileName);

                var IsAllowed = _allowedExtension.Split(',').Contains(Extension, StringComparer.OrdinalIgnoreCase);
                if (!IsAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtension} are allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
