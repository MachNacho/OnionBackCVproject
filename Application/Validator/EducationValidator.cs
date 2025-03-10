using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Validator
{
    public static class EducationValidator
    {
        public static void Validate(Education education)
        {
            var errors = new List<string>();

            // Title validation (only letters, numbers, and spaces)
            if (string.IsNullOrWhiteSpace(education.Title) || !IsValidTitle(education.Title))
                errors.Add("Title must contain only alphabetic characters, numbers, and spaces.");

            // Education Level validation (only letters and spaces)
            if (string.IsNullOrWhiteSpace(education.EducationLevel) || !IsAlphabetic(education.EducationLevel))
                errors.Add("Education Level must contain only alphabetic characters and spaces.");

            // Institution validation (only letters, numbers, and spaces)
            if (string.IsNullOrWhiteSpace(education.Institution) || !IsValidTitle(education.Institution))
                errors.Add("Institution must contain only alphabetic characters, numbers, and spaces.");

            // Date validation (StartDate should be before EndDate)
            if (education.StartDate >= education.EndDate)
                errors.Add("Start date must be before end date.");

            // Description validation (allowing letters, numbers, punctuation)
            if (string.IsNullOrWhiteSpace(education.Description) || !IsValidDescription(education.Description))
                errors.Add("Description contains invalid characters.");

            // ImageSrc validation (must be a valid URL if provided)
            if (!string.IsNullOrWhiteSpace(education.ImageSrc) && !IsValidUrl(education.ImageSrc))
                errors.Add("Image source must be a valid URL.");

            if (errors.Count > 0)
            {
                Console.WriteLine("Validation errors: " + string.Join(", ", errors)); // For debugging
                throw new ValidationException(string.Join(" ", errors));
            }
        }

        private static bool IsValidTitle(string title)
        {
            return Regex.IsMatch(title, @"^[a-zA-Z0-9\s]+$");
        }

        private static bool IsAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }

        private static bool IsValidDescription(string description)
        {
            return Regex.IsMatch(description, @"^[a-zA-Z0-9\s.,!?'-]+$");
        }

        private static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }

}
}
