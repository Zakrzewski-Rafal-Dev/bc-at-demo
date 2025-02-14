namespace BrandingConfigurator.AcceptanceTests.Business.Color.Model;

public class Pantone
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? CssColor { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Pantone)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, CssColor);
    }

    private bool Equals(Pantone other)
    {
        return Id == other.Id && Name == other.Name && CssColor == other.CssColor;
    }
}
