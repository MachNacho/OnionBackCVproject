using Domain.Entities;
using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Application.Validator
{
    public static class AchievementValidator
    {
        public static void Validate(Achivement achievement)
        {
            var errors = new List<string>();

            // Title validation (only letters, numbers, and spaces)
            if (string.IsNullOrWhiteSpace(achievement.Title) || !IsValidTitle(achievement.Title))
                errors.Add("Title must contain only alphabetic characters, numbers, and spaces.");

            // Date validation (cannot be in the future)
            if (achievement.Date > DateTime.Now)
                errors.Add("Date cannot be in the future.");

            // Description validation (allowing letters, numbers, punctuation)
            if (string.IsNullOrWhiteSpace(achievement.Description) || !IsValidDescription(achievement.Description))
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
    }
}
