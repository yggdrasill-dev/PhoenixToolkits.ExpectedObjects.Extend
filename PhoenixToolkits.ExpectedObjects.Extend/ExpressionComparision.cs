using System;

namespace ExpectedObjects
{
	internal class ExpressionComparision<TMember> : IComparison
	{
		private readonly TMember m_Expected;
		private readonly Func<TMember, object, bool> m_EqualFunc;

		public ExpressionComparision(TMember expected, Func<TMember, object, bool> equalFunc)
		{
			m_Expected = expected;
			m_EqualFunc = equalFunc;
		}

		public bool AreEqual(object actual) => m_EqualFunc(m_Expected, actual);

		public object GetExpectedResult() => m_Expected;
	}
}
