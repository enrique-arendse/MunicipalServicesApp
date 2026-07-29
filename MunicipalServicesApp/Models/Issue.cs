using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single issue reported by a citizen through the
    /// "Report Issues" feature of the Municipal Services Application.
    /// </summary>
    public class Issue
    {
        public int ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateReported { get; set; }

        public Issue(int referenceNumber, string location, string category, string description, string attachmentPath)
        {
            ReferenceNumber = referenceNumber;
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachmentPath;
            DateReported = DateTime.Now;
        }

        public override string ToString()
        {
            return $"#{ReferenceNumber} | {Category} | {Location} | {DateReported:g}";
        }
    }
}
