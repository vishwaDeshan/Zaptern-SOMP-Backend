namespace Application.Common.Models
{
	public class ResponseModel<T> : IResponseModel
	{
		public T? Data { get; set; }

		public string? Message { get; set; }

		public bool Success { get; set; }
		public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool IsSuccess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
