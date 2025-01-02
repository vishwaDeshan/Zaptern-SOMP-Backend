namespace Application.Utilities
{
	public class GuidGenerator
	{
		public Guid GenerateUniqueId()
		{
			// Get the current timestamp in ticks
			long timestamp = DateTime.UtcNow.Ticks;

			// Generate a random 64-bit number for uniqueness
			long randomPart = new Random().NextInt64();

			// Combine timestamp and random part into a byte array
			byte[] uniqueBytes = new byte[16];
			BitConverter.GetBytes(timestamp).CopyTo(uniqueBytes, 0);
			BitConverter.GetBytes(randomPart).CopyTo(uniqueBytes, 8);

			// Create a GUID from the byte array
			return new Guid(uniqueBytes);
		}
	}
}
