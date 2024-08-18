namespace Application.Common.Models
{
	public interface IResponseModel
	{
		string? Name { get; set; }

		bool IsSuccess { get; set; }
	}
}
