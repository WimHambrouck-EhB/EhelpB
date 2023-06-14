using System.ComponentModel.DataAnnotations;

namespace ExamenCodeAlong.Attributes
{
    internal class ProjectNaamValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string projectNaam && projectNaam.Length == 9 && projectNaam.StartsWith("PROJ_"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Projectnaam moet beginnen met PROJ_ en 9 karakters lang zijn.");
        }
    }
}