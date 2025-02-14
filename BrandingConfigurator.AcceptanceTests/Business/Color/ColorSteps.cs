using BrandingConfigurator.AcceptanceTests.Business.Color.Model;
using BrandingConfigurator.AcceptanceTests.Business.Color.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Color;

public class ColorSteps
{
    private const int PageNumber = 1;
    private const int PageSize = 10;
    private const string Filter = "Dark Blue C";
    private readonly IColorService _colorService;
    private ColorConfiguration _colorConfiguration;

    public ColorSteps(IColorService colorService)
    {
        _colorService = colorService;
    }

    public void GetPagedColorConfiguration()
    {
       _colorConfiguration = _colorService.GetColorConfiguration(PageNumber, PageSize, "");
    }

    public void GetFilteredColorConfiguration()
    {
       _colorConfiguration = _colorService.GetColorConfiguration(PageNumber, PageSize, Filter);
    }

    public void PagedColorConfigurationIsValid()
    {
        Assert.IsNotNull(_colorConfiguration);
        Assert.That(_colorConfiguration.PredefinedCmykColors.Count(), Is.EqualTo(9));
        Assert.That(_colorConfiguration.PredefinedPantoneColors.Count(), Is.EqualTo(9));
        Assert.That(_colorConfiguration.Colors.Count(), Is.EqualTo(PageSize));
    }

    public void FilteredColorConfigurationIsValid()
    {
        Assert.IsNotNull(_colorConfiguration);
        Assert.That(_colorConfiguration.Colors.Count(), Is.EqualTo(1));
        Assert.That(_colorConfiguration.Colors.FirstOrDefault().Name, Is.EqualTo(Filter));
    }
}
