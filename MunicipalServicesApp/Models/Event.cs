using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Models
{
	/// <summary>
	/// Represents a single local municipal event or announcement.
	/// </summary>
	public class Event
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }

		public Event(int id, string title, string category, DateTime date, string location, string description)
		{
			Id = id;
			Title = title;
			Category = category;
			Date = date;
			Location = location;
			Description = description;
		}

		public override string ToString()
		{
			return $"{Title} ({Category}) - {Date:ddd, dd MMM yyyy}";
		}
	}
}
