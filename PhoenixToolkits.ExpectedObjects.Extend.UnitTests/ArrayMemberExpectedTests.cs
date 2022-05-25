using System;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhoenixToolkits.ExpectedObjects.Extend.UnitTests;
[TestClass]
public class ArrayMemberExpectedTests
{
	[TestMethod]
	public void ArrayMember_Should_Equal()
	{
		var expected = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name2",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name3",
					Age = 2,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		var actual = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name2",
					Age = 11,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name3",
					Age = 22,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		expected.ToExpectedObject(ctx =>
		{
			_ = ctx.IgnoreEqualsOverride();
			_ = ctx.ArrayMemberShouldEqual(
				p => p.Children,
				memberCtx => memberCtx
					.Ignore(p => p.Age)
					.IgnoreEqualsOverride());
		}).ShouldEqual(actual);
	}

	[TestMethod]
	public void ArrayMember_Should_NotEqual()
	{
		var expected = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name2",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name3",
					Age = 2,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		var actual = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name2",
					Age = 11,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name333",
					Age = 22,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		expected.ToExpectedObject(ctx =>
		{
			_ = ctx.IgnoreEqualsOverride();
			_ = ctx.ArrayMemberShouldNotEqual(
				p => p.Children,
				memberCtx => memberCtx
					.Ignore(p => p.Age)
					.IgnoreEqualsOverride());
		}).ShouldEqual(actual);
	}

	[TestMethod]
	public void ArrayMember_Should_Match()
	{
		var expected = new
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new
				{
					Name = "Name2",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2)
				},
				new
				{
					Name = "Name3",
					Age = 2,
					Birthday = new DateTime(2000, 3, 3)
				}
			}
		};

		var actual = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name2",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name3",
					Age = 2,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		expected.ToExpectedObject(ctx =>
		{
			_ = ctx.IgnoreEqualsOverride();
			_ = ctx.ArrayMemberShouldMatch(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldMatch(actual);
	}

	[TestMethod]
	public void ArrayMember_Should_NotMatch()
	{
		var expected = new
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new
				{
					Name = "Name2",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2)
				},
				new
				{
					Name = "Name3",
					Age = 2,
					Birthday = new DateTime(2000, 3, 3)
				}
			}
		};

		var actual = new Person
		{
			Name = "Name1",
			Age = 0,
			Birthday = new DateTime(2000, 1, 1),
			Address = new Address
			{
				Street = "Street1",
				City = "City1",
				State = "State1",
				Zip = "Zip1"
			},
			Children = new[]
			{
				new Person
				{
					Name = "Name22",
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					}
				},
				new Person{
					Name = "Name3",
					Age = 22,
					Birthday = new DateTime(2000, 3, 3),
					Address = new Address
					{
						Street = "Street3",
						City = "City3",
						State = "State3",
						Zip = "Zip3"
					}
				}
			}
		};

		expected.ToExpectedObject(ctx =>
		{
			_ = ctx.IgnoreEqualsOverride();
			_ = ctx.ArrayMemberShouldNotMatch(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldMatch(actual);
	}
}