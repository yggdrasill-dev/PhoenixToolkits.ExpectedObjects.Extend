namespace PhoenixToolkits.ExpectedObjects.Extend.UnitTests;

internal record Person
{
	public string Name { get; set; } = default!;

	public int Age { get; set; }

	public DateTime Birthday { get; set; }

	public Address? Address { get; set; }

	public IEnumerable<Person>? Children { get; set; }
}
