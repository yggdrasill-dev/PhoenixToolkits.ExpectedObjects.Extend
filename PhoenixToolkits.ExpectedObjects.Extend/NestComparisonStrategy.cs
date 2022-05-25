using System;
using ExpectedObjects.Strategies;

namespace ExpectedObjects
{
	internal class NestComparisonStrategy<TMember> : IComparisonStrategy
	{
		private readonly Action<IConfigurationContext<TMember>> m_ConfigurationAction;

		public NestComparisonStrategy(Action<IConfigurationContext<TMember>> configurationAction)
		{
			m_ConfigurationAction = configurationAction;
		}

		public bool CanCompare(object expected, object actual) => true;

		public bool AreEqual(object expected, object actual, IComparisonContext comparisonContext)
			=> expected is TMember member
				? member.ToExpectedObject(m_ConfigurationAction).Equals(actual)
				: expected.ToExpectedObject().Equals(actual);
	}
}
