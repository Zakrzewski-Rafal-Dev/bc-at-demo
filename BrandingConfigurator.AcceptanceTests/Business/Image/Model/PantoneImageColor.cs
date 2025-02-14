using BrandingConfigurator.AcceptanceTests.Business.Color.Model;

namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class PantoneImageColor
{
    public Pantone? Color { get; set; }
    public bool IsHidden { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PantoneImageColor)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Color, IsHidden);
    }

    private bool Equals(PantoneImageColor other)
    {
        return Equals(Color, other.Color) && IsHidden == other.IsHidden;
    }
}