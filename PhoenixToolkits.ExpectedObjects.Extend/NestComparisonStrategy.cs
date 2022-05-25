using System;
using ExpectedObjects.Reporting;
using ExpectedObjects.Strategies;

namespace ExpectedObjects
{
	internal class NestComparisonStrategy<TMember> : IComparisonStrategy
	{
		private readonly Action<IConfigurationContext<TMember>> m_ConfigurationAction;
		private readonly bool m_IgnoreTypeInformation;

		public NestComparisonStrategy(Action<IConfigurationContext<TMember>> configurationAction, bool ignoreTypeInformation = false)
		{
			m_ConfigurationAction = configurationAction;
			m_IgnoreTypeInformation = ignoreTypeInformation;
		}

		public bool CanCompare(object expected, object actual) => true;

		public bool AreEqual(object expected, object actual, IComparisonContext comparisonContext)
			=> expected is TMember member
				? member.ToExpectedObject(m_ConfigurationAction)
					.Equals(actual, NullWriter.Instance, m_IgnoreTypeInformation)
				: expected.ToExpectedObject()
					.Equals(actual, NullWriter.Instance, m_IgnoreTypeInformation);
	}
}
