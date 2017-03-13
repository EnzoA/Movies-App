using System.Collections.Generic;

namespace BLL.Models
{
	public class MovieGroup
	{
		public string GroupName { get; set; }

		public IEnumerable<Movie> Movies { get; set; }
	}
}
