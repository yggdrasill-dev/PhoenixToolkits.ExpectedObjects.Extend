using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ExpectedObjects.Reporting;
using ExpectedObjects.Strategies;

namespace ExpectedObjects
{
	public static class ConfigurationContextExtensions
	{
		public static IConfigurationContext<TExpected> MemberShouldEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject(configurationAction).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject(configurationAction).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected
						.ToExpectedObject(configurationAction)
						.Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> MemberShouldNotMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, TMember>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<TMember>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected
						.ToExpectedObject(configurationAction)
						.Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> ArrayMemberShouldEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, IEnumerable<TMember>>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<IEnumerable<TMember>>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => expected.ToExpectedObject(
						ctx =>
						{
							ctx.ClearStrategies();
							ctx.PushStrategy(new NestedComparisonStrategy<TMember>(configurationAction));
							ctx.PushStrategy<EnumerableComparisonStrategy>();
						}).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> ArrayMemberShouldNotEqual<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, IEnumerable<TMember>>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<IEnumerable<TMember>>(
					getMember.Invoke((TExpected)configurationContext.Object),
					(expected, actual) => !expected.ToExpectedObject(
						ctx =>
						{
							ctx.ClearStrategies();
							ctx.PushStrategy(new NestedComparisonStrategy<TMember>(configurationAction));
							ctx.PushStrategy<EnumerableComparisonStrategy>();
						}).Equals(actual)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> ArrayMemberShouldMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, IEnumerable<TMember>>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<IEnumerable<TMember>>(
					getMember.Invoke((TExpected)configurationContext.Object).ToArray(),
					(expected, actual) => expected.ToExpectedObject(
						ctx =>
						{
							ctx.ClearStrategies();
							ctx.PushStrategy(new NestedComparisonStrategy<TMember>(
								configurationAction,
								true));
							ctx.PushStrategy<EnumerableComparisonStrategy>();
						}).Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}

		public static IConfigurationContext<TExpected> ArrayMemberShouldNotMatch<TExpected, TMember>(
			this IConfigurationContext<TExpected> configurationContext,
			Expression<Func<TExpected, IEnumerable<TMember>>> expr,
			Action<IConfigurationContext<TMember>> configurationAction = default)
		{
			configurationAction = configurationAction ?? (_ => { });
			var getMember = expr.Compile();

			configurationContext.Member(expr)
				.UsesComparison(new ExpressionComparision<IEnumerable<TMember>>(
					getMember.Invoke((TExpected)configurationContext.Object).ToArray(),
					(expected, actual) => !expected.ToExpectedObject(
						ctx =>
						{
							ctx.ClearStrategies();
							ctx.PushStrategy(new NestedComparisonStrategy<TMember>(
								configurationAction,
								true));
							ctx.PushStrategy<EnumerableComparisonStrategy>();
						}).Equals(actual, NullWriter.Instance, true)));

			return configurationContext;
		}
	}
}
