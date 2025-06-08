using Application.Utilities;

namespace Application.Tests.Utilities
{
	[TestFixture]
	public class GuidGeneratorTests
	{
		private GuidGenerator _guidGenerator;

		[SetUp]
		public void SetUp()
		{
			_guidGenerator = new GuidGenerator();
		}

		[Test]
		public void GenerateUniqueId_ShouldReturnValidGuid()
		{
			// Act
			Guid result = _guidGenerator.GenerateUniqueId();

			// Assert
			Assert.That(result, Is.Not.EqualTo(Guid.Empty));
			Assert.That(result.ToString(), Is.Not.Null.And.Not.Empty);
		}

		[Test]
		public void GenerateUniqueId_ShouldReturnUniqueGuids()
		{
			// Act
			var generatedGuids = new HashSet<Guid>();
			for (int i = 0; i < 1000; i++)
			{
				Guid newGuid = _guidGenerator.GenerateUniqueId();
				bool isUnique = generatedGuids.Add(newGuid);

				// Assert
				Assert.IsTrue(isUnique, $"Duplicate GUID found: {newGuid}");
			}
		}
	}
}
