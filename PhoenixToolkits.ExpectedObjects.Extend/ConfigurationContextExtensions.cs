using System;
using System.Linq.Expressions;
using ExpectedObjects.Reporting;

namespace ExpectedObjects
{
	public static class ConfigurationContextExtensions
	{
		public static IConfigurationContext<TExpected> MemberShouldEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject().Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(
					new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject(configurationAction).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject().Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject(configurationAction).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject().Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject(configurationAction).Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject().Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction)
		{
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject(configurationAction).Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}
	}
}
