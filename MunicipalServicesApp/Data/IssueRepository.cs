using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// In-memory store for reported issues. A generic List&lt;Issue&gt; is used
    /// as required by the technical specification, and is exposed as a
    /// static singleton so the same collection can be accessed from the
    /// "Report Issues" form and (in later parts of the PoE) other forms
    /// such as "Service Request Status".
    /// </summary>
    public static class IssueRepository
    {
        private static readonly List<Issue> _issues = new List<Issue>();
        private static int _nextReference = 1000;

        public static IReadOnlyList<Issue> Issues => _issues.AsReadOnly();

        public static Issue AddIssue(string location, string category, string description, string attachmentPath)
        {
            var issue = new Issue(_nextReference++, location, category, description, attachmentPath);
            _issues.Add(issue);
            return issue;
        }

        public static int Count => _issues.Count;
    }
}
