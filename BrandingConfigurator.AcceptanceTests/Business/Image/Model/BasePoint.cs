namespace BrandingConfigurator.AcceptanceTests.Business.Image.Model;

public class BasePoint<T>
{
    public T? X { get; }
    public T? Y { get; }
    
    public BasePoint(T? x, T? y)
    {
        X = x;
        Y = y;
    }
}