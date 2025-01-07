using Domain.Common;

namespace Domain.Entities
{
	public class Applicant : AuditableEntity
	{
		public Guid ApplicantId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string? MiddleName { get; set; }

		public string Gender { get; set; }

		public string Pronouns { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string PhoneNumber { get; set; }

		public string? LandLine { get; set; }

		public string Email { get; set; }

		public string NationalId { get; set; }

		public string Nationality { get; set; }

		public string Street { get; set; }

		public string City { get; set; }

		public string ZipCode {  get; set; }

		public string? Hobbies {  get; set; }

		public string? OtherHobbies { get; set; }
	}
}
