using Domain.Common;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ApplicantHealthRecords : AuditableEntity
{
	[ForeignKey("ApplicantId")]
	public required Applicant Applicant { get; set; }

	public bool? MedicalConditions { get; set; }

	public string? MedicalConditionsDetails { get; set; }

	public bool? Medications { get; set; }

	public string? MedicationsDetails { get; set; }

	public bool? Allergies { get; set; }

	public string? AllergiesDetails { get; set; }

	public bool? Vaccinated { get; set; }

	public string? VaccinatedDetails { get; set; }

	public bool? Surgeries { get; set; }

	public string? SurgeriesDetails { get; set; }

	public bool? Accommodations { get; set; }

	public string? AccommodationsDetails { get; set; }
}


