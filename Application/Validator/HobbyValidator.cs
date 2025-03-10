using Domain.Entities;
using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Application.Validator
{
    public static class HobbyValidator
    {
        public static void Validate(Hobby hobby)
        {
            var errors = new List<string>();
            // Title validation (only letters, numbers, and spaces)
            if (string.IsNullOrWhiteSpace(hobby.Title) || !IsValidTitle(hobby.Title))
                errors.Add("Title must contain only alphabetic characters, numbers, and spaces.");

            // Description validation (allowing letters, numbers, punctuation)
            if (string.IsNullOrWhiteSpace(hobby.Description) || !IsValidDescription(hobby.Description))
                errors.Add("Description contains invalid characters.");

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
