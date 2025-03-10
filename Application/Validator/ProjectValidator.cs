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
    public static class ProjectValidator
    {
        public static void Validate(Project project)
        {
            var errors = new List<string>();

            // Title validation (only letters, numbers, and spaces)
            if (string.IsNullOrWhiteSpace(project.Title) || !IsValidTitle(project.Title))
                errors.Add("Title must contain only alphabetic characters, numbers, and spaces.");

            // Description validation (allowing letters, numbers, punctuation)
            if (string.IsNullOrWhiteSpace(project.Description) || !IsValidDescription(project.Description))
                errors.Add("Description contains invalid characters.");

            // ProjectDate validation (cannot be in the future)
            if (project.ProjectDate > DateTime.Now)
                errors.Add("Project date cannot be in the future.");

            // Link validation (must be a valid URL if HasPublicLink is true)
            if ((string.IsNullOrWhiteSpace(project.Link) || !IsValidUrl(project.Link)))
                errors.Add("A valid public link is required.");

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
