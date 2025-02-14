namespace BrandingConfigurator.AcceptanceTests.Business.Color.Model;

public class Cmyk
{
    private const int Precision = 1;
    private static readonly double Tolerance = Math.Pow(10, -(Precision + 1));

    public float C { get; set; }
    public float M { get; set; }
    public float Y { get; set; }
    public float K { get; set; }

    public bool IsEqualTo(Cmyk cmyk)
    {
        if (cmyk == null)
        {
            return false;
        }

        return Math.Abs(C - cmyk.C) < Tolerance &&
               Math.Abs(M - cmyk.M) < Tolerance &&
               Math.Abs(Y - cmyk.Y) < Tolerance &&
               Math.Abs(K - cmyk.K) < Tolerance;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Cmyk)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(C, M, Y, K);
    }

    private bool Equals(Cmyk other)
    {
        return C.Equals(other.C) && M.Equals(other.M) && Y.Equals(other.Y) && K.Equals(other.K);
    }
}