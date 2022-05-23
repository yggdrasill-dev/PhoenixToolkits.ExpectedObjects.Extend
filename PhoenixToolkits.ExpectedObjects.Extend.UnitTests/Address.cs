namespace PhoenixToolkits.ExpectedObjects.Extend.UnitTests;

internal record Address
{
	public string Street { get; set; } = default!;

	public string City { get; set; } = default!;

	public string State { get; set; } = default!;

	public string Zip { get; set; } = default!;
}
