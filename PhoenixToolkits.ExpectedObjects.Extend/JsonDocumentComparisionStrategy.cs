using System.Text.Json;
using ExpectedObjects.Reporting;
using ExpectedObjects.Strategies;

namespace ExpectedObjects
{
	public class JsonDocumentComparisionStrategy : IComparisonStrategy
	{
		public bool CanCompare(object expected, object actual) => expected is JsonDocument;

		public bool AreEqual(object expected, object actual, IComparisonContext comparisonContext)
			=> JsonSerializer.Serialize(expected)
				.ToExpectedObject()
				.Equals(JsonSerializer.Serialize(actual), NullWriter.Instance, false);
	}
}
