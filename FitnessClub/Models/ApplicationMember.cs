using Microsoft.AspNetCore.Identity;

namespace FitnessClub.Models
{
	public class ApplicationMember : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public DateTime CreatedAt  { get; set; }
	}
}
