using ExpectedObjects;

namespace PhoenixToolkits.ExpectedObjects.Extend.UnitTests;

[TestClass]
public class MemberExpectedTests
{
	[TestMethod]
	public void Member_Should_Equal()
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
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
			_ = ctx.MemberShouldEqual(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldEqual(actual);
	}

	[TestMethod]
	public void Member_Should_Not_Equal()
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
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name5",
							Age = 5,
							Birthday = new DateTime(2000, 5, 5),
							Address = new Address
							{
								Street = "Street4",
								City = "City4",
								State = "State4",
								Zip = "Zip4"
							}
						}
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
			_ = ctx.MemberShouldNotEqual(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldEqual(actual);
	}

	[TestMethod]
	public void Member_Should_Match()
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
			Children = new object[]
			{
				new {
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
				},
				new
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
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
			_ = ctx.MemberShouldMatch(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldMatch(actual);
	}

	[TestMethod]
	public void Member_Should_Not_Match()
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
			Children = new object[]
			{
				new {
					Name = "Name9",
					Age = 9,
					Birthday = new DateTime(2000, 9, 9),
					Address = new Address
					{
						Street = "Street9",
						City = "City9",
						State = "State9",
						Zip = "Zip9"
					}
				},
				new
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
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
					Age = 1,
					Birthday = new DateTime(2000, 2, 2),
					Address = new Address
					{
						Street = "Street2",
						City = "City2",
						State = "State2",
						Zip = "Zip2"
					},
					Children = new[]
					{
						new Person
						{
							Name = "Name4",
							Age = 3,
							Birthday = new DateTime(2000, 4, 4),
							Address = new Address
							{
								Street = "Street3",
								City = "City3",
								State = "State3",
								Zip = "Zip3"
							}
						}
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
			_ = ctx.MemberShouldMatch(
				p => p.Children,
				memberCtx => memberCtx
					.IgnoreEqualsOverride());
		}).ShouldNotMatch(actual);
	}
}
