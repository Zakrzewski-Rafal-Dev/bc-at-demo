using System.Globalization;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Color.Model;
using BrandingConfigurator.AcceptanceTests.Business.File.Service;
using BrandingConfigurator.AcceptanceTests.Business.Image.Model;
using BrandingConfigurator.AcceptanceTests.Business.Image.Service;
using NUnit.Framework;

namespace BrandingConfigurator.AcceptanceTests.Business.Image;

public class ImageSteps
{
    private const string Resource = "Resource";
    private const string ImageName = "logo";
    private const string WrongImageFileType = "svg";
    private string UserId = "AcceptanceTests" + DateTime.Now.ToString();
    private readonly IImageService _imageService;
    private readonly IFileService _fileService;
    private Model.Image? _image;
    private IEnumerable<Model.Image>? _images;
    private string _imageId;
    private string _imageId2;
    private string _notFoundResponse;
    private string _wrongTypeResponse;
    private string _errorMessage;
    private string _badRequestResponse;
    private string _editedImageId;
    private static readonly ImageFormatting _imageFormattingCmyk = PrepareImageFormattingForCmyk();
    private static readonly ImageFormatting _imageFormattingPantone = PrepareImageFormattingForPantone();
    private static readonly ImageFormatting _colorsToReplaceCmyk = PrepareColorsToReplaceCmyk();
    private static readonly ImageFormatting _colorsToReplacePantone = PrepareColorsToReplacePantone();

    public ImageSteps(
        IImageService imageService,
        IFileService fileService)
    {
        _imageService = imageService;
        _fileService = fileService;
    }

    public void UploadImageFile(string fileType)
    {
        var fileName = ImageName + "." + fileType;
        var imageStream = PrepareImage(fileName);
        _imageId = _imageService.UploadImage(imageStream, fileName, UserId);
        Assert.IsNotNull(_imageId);
    }

    public void UploadImageFileTwice(string fileType)
    {
        var fileName = ImageName + "." + fileType;
        var imageStream = PrepareImage(fileName);
        var imageStream2 = PrepareImage(fileName);
        _imageId = _imageService.UploadImage(imageStream, fileName, UserId);
        _imageId2 = _imageService.UploadImage(imageStream2, fileName, UserId);
        Assert.IsNotNull(_imageId);
        Assert.IsNotNull(_imageId2);
    }

    public void UploadImageFileWithoutUserId()
    {
        const string fileName = ImageName + ".pdf";
        var imageStream = PrepareImage(fileName);

        try
        {
            _imageId = _imageService.UploadImage(imageStream, fileName, "");
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }

    public void UploadWrongImageFileType()
    {
        const string fileName = ImageName + "." + WrongImageFileType;
        var imageStream = PrepareImage(fileName);

        try
        {
            _imageId = _imageService.UploadImage(imageStream, fileName, UserId);
        }
        catch (InvalidServiceResponseException ex)
        {
            _wrongTypeResponse = ex.ErrorDescription;
        }
    }

    public void UpdateImageWithoutUserId()
    {
        try
        {
            _imageService.EditImage(_imageId, "", _imageFormattingCmyk);
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }

    public void GetImageFileWithWrongFilePath()
    {
        try
        {
            _fileService.GetFile(_image?.PantoneImage?.Path + "invalidFilePath");
        }
        catch (Exception ex)
        {
            _notFoundResponse = ex.Message;
        }
    }

    public void GetImageMetadata()
    {
        _image = _imageService.GetImageMetadata(_imageId, UserId);
    }

    public void GetImagesMetadata()
    {
        _images = _imageService.GetImagesMetadata(UserId, null);
    }

    public void GetImageMetadataWithoutUserId()
    {
        try
        {
            _imageService.GetImageMetadata(_imageId, "");
        }
        catch (Exception ex)
        {
            _badRequestResponse = ex.Message;
        }
    }

    public void GetImageMetadataByInvalidId()
    {
        try
        {
            _image = _imageService.GetImageMetadata("invalidId", UserId);
        }
        catch (Exception ex)
        {
            _notFoundResponse = ex.Message;
        }
    }

    public void GetPagedImagesMetadata()
    {
        var paging = new Paging
        {
            PageSize = 1,
            PageNumber = 2
        };
        _images = _imageService.GetImagesMetadata(UserId, paging);
    }

    public void EditCmykColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, _colorsToReplaceCmyk);
    }

    public void EditCmykColors()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorsFormatting());
    }

    public void EditCmykColorByExtendedModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, _imageFormattingCmyk);
    }
    
    public void EditCmykColorByCmykId()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorByCmykIdFormatting());
    }
    
    public void EditCmykColorsByExtendedModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorsByExtendedModelFormatting());
    }

    public void EditCmykColorsByCmykId()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorsByCmykIdFormatting());
    }

    public void EditCmykColorsByExtendedAndLegacyModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorsByExtendedAndLegacyModelsFormatting());
    }
    
    public void EditCmykColorsByCmykIdAndLegacyModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditCmykColorsByCmykIdAndLegacyModelsFormatting());
    }

    public void EditPantoneColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, _colorsToReplacePantone);
    }

    public void EditPantoneColors()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditPantoneColorsFormatting());
    }

    public void EditPantoneColorByExtendedModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, _imageFormattingPantone);
    }

    public void EditPantoneColorsByExtendedModel()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, EditPantoneColorsByExtendedModelFormatting());
    }

    public void EditPantoneColorsByExtendedAndLegacyModels()
    {
        _editedImageId =
            _imageService.EditImage(_imageId, UserId, EditPantoneColorsByExtendedAndLegacyModelsFormatting());
    }

    public void EditAbsentCmykColor()
    {
        GetImageMetadata();
        EditImage(EditAbsentCmykColorFormatting());
    }

    public void EditAbsentPantoneColor()
    {
        GetImageMetadata();
        EditImage(EditAbsentPantoneColorFormatting());
    }

    public void EditAbsentCmykColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditAbsentCmykColorFormattingByExtendedModel());
    }
    
    public void EditAbsentCmykColorByCmykId()
    {
        GetImageMetadata();
        EditImage(EditAbsentCmykColorFormattingByCmykId());
    }
        
    public void EditAbsentPantoneColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditAbsentPantoneColorFormattingByExtendedModel());
    }

    public void EditToInvalidCmykColor()
    {
        GetImageMetadata();
        EditImage(EditToInvalidCmykColorFormatting());
    }

    public void EditToInvalidCmykColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditToInvalidCmykColorFormattingByExtendedModel());
    }

    public void EditToInvalidCmykColorByCmykId()
    {
        GetImageMetadata();
        EditImage(EditToInvalidCmykColorFormattingByCmykId());
    }

    public void EditToInvalidPantoneColor()
    {
        GetImageMetadata();
        EditImage(EditToInvalidPantoneColorFormatting());
    }

    public void EditToInvalidPantoneColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditToInvalidPantoneColorFormattingByExtendedModel());
    }

    public void EditToTheSameCmykColor()
    {
        GetImageMetadata();
        EditImage(EditToTheSameCmykColorFormatting());
    }

    public void EditToTheSamePantoneColor()
    {
        GetImageMetadata();
        EditImage(EditToTheSamePantoneColorFormatting());
    }

    public void EditToTheSameCmykColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditToTheSameCmykColorFormattingByExtendedModel());
    }

    public void EditToTheSameCmykColorByCmykId()
    {
        GetImageMetadata();
        EditImage(EditToTheSameCmykColorFormattingByCmykId());
    }
    
    public void EditToTheSamePantoneColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditToTheSamePantoneColorFormattingByExtendedModel());
    }

    public void EditUndefinedCmykColor()
    {
        GetImageMetadata();
        EditImage(EditUndefinedCmykColorFormatting());
    }

    public void EditUndefinedCmykColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditUndefinedCmykColorByExtendedModelFormatting());
    }
    
    public void EditUndefinedCmykColorByCmykId()
    {
        GetImageMetadata();
        EditImage(EditUndefinedCmykColorByCmykIdFormatting());
    }
        
    public void EditUndefinedPantoneColor()
    {
        GetImageMetadata();
        EditImage(EditUndefinedPantoneColorFormatting());
    }

    public void EditUndefinedPantoneColorByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditUndefinedPantoneColorByExtendedModelFormatting());
    }

    public void EditToUndefinedCmykColor()
    {
        GetImageMetadata();
        EditImage(EditToUndefinedCmykColorFormatting());
    }

    public void EditToUndefinedPantoneColor()
    {
        GetImageMetadata();
        EditImage(EditToUndefinedPantoneColorFormatting());
    }

    public void EditNoColors()
    {
        GetImageMetadata();
        EditImage(EditNoColorsFormatting());
    }

    public void EditCmykAndPantoneColors()
    {
        GetImageMetadata();
        EditImage(EditCmykAndPantoneColorsFormatting());
    }

    public void EditCmykAndPantoneColorsByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditCmykAndPantoneColorsFormattingByExtendedModel());
    }
    
    public void EditCmykAndPantoneColorsByCmykId()
    {
        GetImageMetadata();
        EditImage(EditCmykAndPantoneColorsFormattingByCmykId());
    }

    public void EditTheSameCmykColorManyTimes()
    {
        GetImageMetadata();
        EditImage(EditTheSameManyCmykColorsFormatting());
    }

    public void EditTheSameCmykColorManyTimesByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditTheSameManyCmykColorsFormattingByExtendedModel());
    }

    public void EditTheSameCmykColorManyTimesByCmykId()
    {
        GetImageMetadata();
        EditImage(EditTheSameManyCmykColorsFormattingByCmykId());
    }
    
    public void EditTheSamePantoneColorManyTimes()
    {
        GetImageMetadata();
        EditImage(EditTheSameManyPantoneColorsFormatting());
    }

    public void EditTheSamePantoneColorManyTimesByExtendedModel()
    {
        GetImageMetadata();
        EditImage(EditTheSameManyPantoneColorsFormattingByExtendedModel());
    }

    public void ImageIsNotFound()
    {
        Assert.That(_notFoundResponse, Is.EqualTo("Invalid service response. Expected code OK, retrieved NotFound"));
    }

    public void ImageIsNotUpdated()
    {
        Assert.That(_errorMessage, Is.EqualTo("Value of user id is not defined or empty."));
    }

    public void ImageIsNotUploaded()
    {
        Assert.That(_errorMessage, Is.EqualTo("Value of user id is not defined or empty."));
    }

    public void CmykColorsAreChanged()
    {
        var destinationCmyk1 =
            EditCmykColorsFormatting().ColorsToReplace!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk1 =
            EditCmykColorsFormatting().ColorsToReplace!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk1!, destinationCmyk1!);

        var destinationCmyk2 =
            EditCmykColorsFormatting().ColorsToReplace!.LastOrDefault()!.DestinationCmykColor;
        var sourceCmyk2 =
            EditCmykColorsFormatting().ColorsToReplace!.LastOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk2!, destinationCmyk2!);
    }

    public void PantoneColorsAreChanged()
    {
        var destinationPantone1 =
            EditPantoneColorsFormatting().ColorsToReplace!.FirstOrDefault()!.DestinationPantoneColorId;
        var sourcePantone1 =
            EditPantoneColorsFormatting().ColorsToReplace!.FirstOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone1!, destinationPantone1!);

        var destinationPantone2 =
            EditPantoneColorsFormatting().ColorsToReplace!.LastOrDefault()!.DestinationPantoneColorId;
        var sourcePantone2 =
            EditPantoneColorsFormatting().ColorsToReplace!.LastOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone2!, destinationPantone2!);
    }

    public void CmykColorsAreChangedByExtendedModel()
    {
        var destinationCmyk1 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk1 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk1!, destinationCmyk1!);

        var destinationCmyk2 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.LastOrDefault()!.DestinationCmykColor;
        var sourceCmyk2 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.LastOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk2!, destinationCmyk2!);
    }

    public void CmykColorsAreChangedByCmykId()
    {
        var destinationCmyk1 =
            EditCmykColorsByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk1 =
            EditCmykColorsByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColor;
        var sourceCmykColorId1 = 
            EditCmykColorsByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColorId;
        AssertCmykWasChanged(sourceCmyk1!, destinationCmyk1!, sourceCmykColorId1!);

        var destinationCmyk2 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.LastOrDefault()!.DestinationCmykColor;
        var sourceCmyk2 =
            EditCmykColorsByExtendedModelFormatting().CmyksToEdit!.LastOrDefault()!.SourceCmykColor;
        var sourceCmykColorId2 = 
            EditCmykColorsByCmykIdFormatting().CmyksToEdit!.LastOrDefault()!.SourceCmykColorId;
        AssertCmykWasChanged(sourceCmyk2!, destinationCmyk2!, sourceCmykColorId2!);
    }
    
    public void CmykColorsAreChangedByExtendedAndLegacyModels()
    {
        var destinationCmyk1 =
            EditCmykColorsByExtendedAndLegacyModelsFormatting().CmyksToEdit!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk1 =
            EditCmykColorsByExtendedAndLegacyModelsFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk1!, destinationCmyk1!);

        var destinationCmyk2 =
            EditCmykColorsByExtendedAndLegacyModelsFormatting().ColorsToReplace!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk2 =
            EditCmykColorsByExtendedAndLegacyModelsFormatting().ColorsToReplace!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk2!, destinationCmyk2!);
    }

    public void PantoneColorsAreChangedByExtendedModel()
    {
        var destinationPantone1 =
            EditPantoneColorsByExtendedModelFormatting().PantonesToEdit!.FirstOrDefault()!.DestinationPantoneColorId;
        var sourcePantone1 =
            EditPantoneColorsByExtendedModelFormatting().PantonesToEdit!.FirstOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone1!, destinationPantone1!);

        var destinationPantone2 =
            EditPantoneColorsByExtendedModelFormatting().PantonesToEdit!.FirstOrDefault()!.DestinationPantoneColorId;
        var sourcePantone2 =
            EditPantoneColorsByExtendedModelFormatting().PantonesToEdit!.FirstOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone2!, destinationPantone2!);
    }

    public void PantoneColorsAreChangedByExtendedAndLegacyModels()
    {
        var destinationPantone1 =
            EditPantoneColorsByExtendedAndLegacyModelsFormatting().PantonesToEdit!.FirstOrDefault()!
                .DestinationPantoneColorId;
        var sourcePantone1 =
            EditPantoneColorsByExtendedAndLegacyModelsFormatting().PantonesToEdit!.FirstOrDefault()!
                .SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone1!, destinationPantone1!);

        var destinationPantone2 =
            EditPantoneColorsByExtendedAndLegacyModelsFormatting().ColorsToReplace!.FirstOrDefault()!
                .DestinationPantoneColorId;
        var sourcePantone2 =
            EditPantoneColorsByExtendedAndLegacyModelsFormatting().ColorsToReplace!.FirstOrDefault()!
                .SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone2!, destinationPantone2!);
    }

    public void ImageIsNotReturned()
    {
        Assert.That(_badRequestResponse,
            Is.EqualTo("Invalid service response. Expected code OK, retrieved BadRequest"));
    }

    public void TheImageMetadataIsReturned()
    {
        Assert.IsNotNull(_image);
        Assert.IsNotNull(_image?.PantoneImage?.Path);
        Assert.That(_image?.PantoneImage?.Path, Is.EqualTo("/file/image/" + _imageId + "_pms.svg"));
        Assert.That(_image?.PantoneImage?.Colors?.Count(), Is.GreaterThan(1));
        Assert.That(_image?.PantoneImage?.PantoneColors?.Count(), Is.GreaterThan(1));
        Assert.IsNotNull(_image?.PantoneImage?.PantoneColors?.First().Color);
        Assert.That(_image?.PantoneImage?.PantoneColors?.First().Color?.Id, Is.Not.Empty);
        Assert.That(_image?.PantoneImage?.PantoneColors?.First().Color?.Name, Is.Not.Empty);
        Assert.That(_image?.PantoneImage?.PantoneColors?.First().Color?.CssColor, Is.Not.Empty);
        Assert.IsNotNull(_image?.PantoneImage?.PantoneColors?.First().Color);
        Assert.False(_image?.PantoneImage?.PantoneColors?.First().IsHidden);
        Assert.IsNotNull(_image?.PantoneImage?.Path);
        Assert.That(_image?.CmykImage?.Path, Is.EqualTo("/file/image/" + _imageId + "_cmyk.svg"));
        Assert.That(_image?.CmykImage?.Colors?.Count(), Is.GreaterThan(1));
        Assert.That(_image?.CmykImage?.CmykColors?.Count(), Is.GreaterThan(1));
        Assert.IsNotNull(_image?.CmykImage?.CmykColors?.First().Color);
        Assert.That(_image?.CmykImage?.CmykColors?.First().Id, Is.Not.Empty);
        Assert.False(_image?.CmykImage?.CmykColors?.First().IsHidden);
        Assert.That(_image?.EdgePoints?.Count(), Is.GreaterThan(0));
        Assert.IsTrue(_image?.OriginalName.Contains(ImageName));
    }

    public void TheImageMetadataIsReturnedFromNewestToOldest()
    {
        Assert.IsNotNull(_images);
        Assert.IsTrue(_images.Count() >= 2);
        Assert.That(_images.ToList()[0]?.Id, Is.EqualTo(_imageId2));
        Assert.That(_images.ToList()[1]?.Id, Is.EqualTo(_imageId));
    }

    public void PagedImagesAreReturned()
    {
        Assert.IsNotNull(_images);
        Assert.IsTrue(_images.Count() == 1);
        Assert.That(_images.ToList()[0]?.Id, Is.EqualTo(_imageId));
    }

    public void GetImageFile()
    {
        Assert.IsNotNull(_fileService.GetFile(_image?.PantoneImage?.Path ?? ""));
        Assert.IsNotNull(_fileService.GetFile(_image?.CmykImage?.Path ?? ""));
    }

    public void InvalidFileTypeIsReturned()
    {
        Assert.That(_wrongTypeResponse,
            Is.EqualTo("File type svg is not supported. Supported file types: pdf, eps, cdr, ai, jpg, png"));
    }

    public void CmykColorIsChanged()
    {
        var destinationCmyk =
            PrepareColorsToReplaceCmyk().ColorsToReplace!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk =
            PrepareColorsToReplaceCmyk().ColorsToReplace!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk!, destinationCmyk!);
    }

    public void PantoneColorIsChanged()
    {
        var destinationPantone =
            PrepareColorsToReplacePantone().ColorsToReplace!.FirstOrDefault()!.DestinationPantoneColorId;
        var sourcePantone =
            PrepareColorsToReplacePantone().ColorsToReplace!.FirstOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone!, destinationPantone!);
    }

    public void CmykColorIsChangedByExtendedModel()
    {
        var destinationCmyk =
            PrepareImageFormattingForCmyk().CmyksToEdit!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk =
            PrepareImageFormattingForCmyk().CmyksToEdit!.FirstOrDefault()!.SourceCmykColor;
        AssertCmykWasChanged(sourceCmyk!, destinationCmyk!);
    }
    
    public void CmykColorIsChangedByCmykId()
    {
        var destinationCmyk =
            EditCmykColorByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.DestinationCmykColor;
        var sourceCmyk =
            EditCmykColorByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColor;
        var sourceCmykId =
            EditCmykColorByCmykIdFormatting().CmyksToEdit!.FirstOrDefault()!.SourceCmykColorId;
        AssertCmykWasChanged(sourceCmyk!, destinationCmyk!, sourceCmykId!);
    }

    public void PantoneColorIsChangedByExtendedModel()
    {
        var destinationPantone =
            PrepareImageFormattingForPantone().PantonesToEdit!.FirstOrDefault()!.DestinationPantoneColorId;
        var sourcePantone =
            PrepareImageFormattingForPantone().PantonesToEdit!.FirstOrDefault()!.SourcePantoneColorId;
        AssertPantoneWasChanged(sourcePantone!, destinationPantone!);
    }

    private void AssertCmykWasChanged(Cmyk sourceCmyk, Cmyk destinationCmyk)
    {
        Assert.That(_editedImageId, Is.Not.Null);

        var imageMetadata = _imageService.GetImageMetadata(_editedImageId, UserId);

        Assert.That(
            imageMetadata.CmykImage?.CmykColors?.Any(x => x.Color!.IsEqualTo(destinationCmyk)),
            Is.True);
        Assert.That(
            imageMetadata.CmykImage?.CmykColors?.Any(x => x.Color!.IsEqualTo(sourceCmyk)),
            Is.False);
    }
    
    private void AssertCmykWasChanged(Cmyk sourceCmyk, Cmyk destinationCmyk, string sourceCmykId)
    {
        Assert.That(_editedImageId, Is.Not.Null);

        var imageMetadata = _imageService.GetImageMetadata(_editedImageId, UserId);

        Assert.That(
            imageMetadata.CmykImage?.CmykColors?.Any(x => x.Color!.IsEqualTo(destinationCmyk)),
            Is.True);
        Assert.That(
            imageMetadata.CmykImage?.CmykColors?.Any(x => x.Color!.IsEqualTo(sourceCmyk)),
            Is.False);
        Assert.That(
            imageMetadata.CmykImage?.CmykColors?.All(x => x.Id != sourceCmykId),
            Is.True);
    }

    private void AssertPantoneWasChanged(string sourcePantoneId, string destinationPantoneId)
    {
        Assert.That(_editedImageId, Is.Not.Null);

        var imageMetadata = _imageService.GetImageMetadata(_editedImageId, UserId);

        Assert.That(
            imageMetadata.PantoneImage?.PantoneColors?.Any(x => x.Color?.Id == destinationPantoneId),
            Is.True);
        Assert.That(
            imageMetadata.PantoneImage?.PantoneColors?.Any(x => x.Color?.Id == sourcePantoneId),
            Is.False);
    }

    public void HideCmykColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, HideCmykColorFormatting());
    }
    
    
    public void HideCmykColorByCmykId()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, HideCmykColorByCmykIdFormatting());
    }

    public void HideInvalidCmykColor()
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, HideInvalidCmykColorFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
    
    public void HideInvalidCmykColorByCmykId()
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, HideInvalidCmykColorByCmykIdFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
        
    public void ShowCmykColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, ShowCmykColorFormatting());
    }

    public void ShowCmykColorByCmykId()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, ShowCmykColoByCmykIdrFormatting());
    }
    
    public void ShowInvalidCmykColor()
    {
        _imageId = _editedImageId;
        _editedImageId = null;
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, ShowInvalidCmykColorFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
    
    public void ShowInvalidCmykColorByCmykId()
    {
        _imageId = _editedImageId;
        _editedImageId = null;
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, ShowInvalidCmykColorByCmykIdFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }

    public void HidePantoneColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, HidePantoneColorFormatting());
    }

    public void HideInvalidPantoneColor()
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, HideInvalidPantoneColorFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }

    public void ShowPantoneColor()
    {
        _editedImageId = _imageService.EditImage(_imageId, UserId, ShowPantoneColorFormatting());
    }

    public void ShowInvalidPantoneColor()
    {
        _imageId = _editedImageId;
        _editedImageId = null;
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, ShowInvalidPantoneColorFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }

    public void HideCmykAndPantoneColors()
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, HideCmykAndPantoneColorsFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
    
    public void HideCmykAndPantoneColorsByCmykId()
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, HideCmykAndPantoneColorsByCmykIdFormatting());
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
    
    public void CmykColorIsHidden()
    {
        var cmykImageColor = GetCmykImageColor(_editedImageId);

        Assert.That(cmykImageColor?.IsHidden, Is.True);
    }

    public void PantoneColorIsHidden()
    {
        var pantoneImageColor = GetPantoneImageColor(_editedImageId);

        Assert.That(pantoneImageColor?.IsHidden, Is.True);
    }

    public void CmykColorIsShown()
    {
        var cmykImageColor = GetCmykImageColor(_editedImageId);

        Assert.That(cmykImageColor?.IsHidden, Is.False);
    }

    public void PantoneColorIsShown()
    {
        var pantoneImageColor = GetPantoneImageColor(_editedImageId);

        Assert.That(pantoneImageColor?.IsHidden, Is.False);
    }

    public void CmykColorHasNotBeenHidden()
    {
        Assert.That(_editedImageId, Is.Null);
        var cmykImageColor = GetCmykImageColor(_imageId);
        Assert.That(cmykImageColor?.IsHidden, Is.False);
    }

    public void CmykColorHasNotBeenShown()
    {
        Assert.That(_editedImageId, Is.Null);
        var cmykImageColor = GetCmykImageColor(_imageId);
        Assert.That(cmykImageColor?.IsHidden, Is.True);
    }

    public void PantoneColorHasNotBeenHidden()
    {
        Assert.That(_editedImageId, Is.Null);
        var pantoneImageColor = GetPantoneImageColor(_imageId);
        Assert.That(pantoneImageColor?.IsHidden, Is.False);
    }

    public void PantoneColorHasNotBeenShown()
    {
        Assert.That(_editedImageId, Is.Null);
        var pantoneImageColor = GetPantoneImageColor(_imageId);
        Assert.That(pantoneImageColor?.IsHidden, Is.True);
    }

    public void CmykAndPantoneColorsHaveNotBeenChanged()
    {
        Assert.That(_editedImageId, Is.Null);
        var cmykImageColor = GetCmykImageColor(_imageId);
        Assert.That(cmykImageColor?.IsHidden, Is.False);
        var pantoneImageColor = GetPantoneImageColor(_imageId);
        Assert.That(pantoneImageColor?.IsHidden, Is.False);
    }

    public void OriginalCmykColorsHasNotBeenChanged()
    {
        Assert.That(_editedImageId, Is.Null);
        var imageMetadata = _imageService.GetImageMetadata(_imageId, UserId);
        Assert.That(_image?.CmykImage?.CmykColors, Is.EqualTo(imageMetadata.CmykImage?.CmykColors));
    }

    public void OriginalPantoneColorsHasNotBeenChanged()
    {
        Assert.That(_editedImageId, Is.Null);
        var imageMetadata = _imageService.GetImageMetadata(_imageId, UserId);
        Assert.That(_image?.PantoneImage?.PantoneColors, Is.EqualTo(imageMetadata.PantoneImage?.PantoneColors));
    }

    public void CmykColorIsUndefined()
    {
        Assert.That(_errorMessage, Is.EqualTo("Both source and destination CMYK color must be provided."));
    }

    public void CmykColorIsUndefinedInExtendedModel()
    {
        Assert.That(_errorMessage, Is.EqualTo("Source Cmyk is undefined. "));
    }

    public void PantoneColorIsUndefined()
    {
        Assert.That(_errorMessage, Is.EqualTo("Both source and destination Pantone color ids must be provided."));
    }

    public void PantoneColorIsUndefinedInExtendedModel()
    {
        Assert.That(_errorMessage, Is.EqualTo("Source Pantone:  is invalid. "));
    }

    public void ColorIsNotFoundInImage()
    {
        Assert.That(_errorMessage, Is.EqualTo("Source colors are not found in image."));
    }

    public void NoColorsToChange()
    {
        Assert.That(_errorMessage, Is.EqualTo("One type of colors should be provided. "));
    }

    public void ThereAreTwoTypesOfColors()
    {
        Assert.That(_errorMessage, Is.EqualTo("One type of colors should be provided. "));
    }

    public void CmykColorIsInvalid()
    {
        var color = EditToInvalidCmykColorFormatting().ColorsToReplace?.FirstOrDefault()?.DestinationCmykColor;
        Assert.That(_errorMessage,
            Is.EqualTo(
                $"K value of CMYK must be between 0 and 1, but was: {color?.K.ToString(CultureInfo.InvariantCulture)} "));
    }

    public void PantoneColorIsInvalid()
    {
        var color = EditToInvalidPantoneColorFormatting().ColorsToReplace?.FirstOrDefault()?.DestinationPantoneColorId;
        Assert.That(_errorMessage, Is.EqualTo($"Destination Pantone: {color} is invalid. "));
    }

    public void ColorsAreTheSame()
    {
        Assert.That(_errorMessage,
            Is.EqualTo("At least one destination color should be different from source color for image editing. "));
    }

    public void DeleteImage()
    {
        _imageService.DeleteImage(_imageId, UserId);
    }

    public void ImageIsDeleted()
    {
        try
        {
            _imageService.GetImageMetadata(_imageId, UserId);
        }
        catch (Exception ex)
        {
            Assert.That(ex.Message.Equals("Invalid service response. Expected code OK, retrieved NotFound"));
        }

        var result = _imageService.GetImagesMetadata(UserId, null);
        Assert.That(result.Count(), Is.EqualTo(0));
        Assert.That(result.Where(x => x.Id == _imageId), Is.Empty);
    }

    private static MemoryStream PrepareImage(string fileName)
    {
        return new MemoryStream(System.IO.File.ReadAllBytes(
            Path.Combine(Path.GetFullPath(AppContext.BaseDirectory), Resource, fileName)));
    }

    private static ImageFormatting PrepareImageFormattingForCmyk()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditCmykColorByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditCmykColorsByExtendedModelFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                },
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.67f,
                        M = 0.66f,
                        Y = 0.0f,
                        K = 0.47f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditCmykColorsByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                },
                new()
                {
                    SourceCmykColorId = "06667-06593-00000-04706",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditCmykColorsByExtendedAndLegacyModelsFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            },
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.67f,
                        M = 0.66f,
                        Y = 0.0f,
                        K = 0.47f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditCmykColorsByCmykIdAndLegacyModelsFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            },
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.67f,
                        M = 0.66f,
                        Y = 0.0f,
                        K = 0.47f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }
    
    private CmykImageColor? GetCmykImageColor(string imageId)
    {
        var imageMetadata = _imageService.GetImageMetadata(imageId, UserId);
        var sourceCmykColor = HideCmykColorFormatting().CmyksToEdit?.First().SourceCmykColor;

        return imageMetadata.CmykImage?.CmykColors?.FirstOrDefault(x => x.Color!.IsEqualTo(sourceCmykColor!));
    }

    private PantoneImageColor? GetPantoneImageColor(string imageId)
    {
        var imageMetadata = _imageService.GetImageMetadata(imageId, UserId);
        var sourcePantoneColor = HidePantoneColorFormatting().PantonesToEdit?.First().SourcePantoneColorId;

        return imageMetadata.PantoneImage?.PantoneColors?.FirstOrDefault(x => x.Color?.Id == sourcePantoneColor);
    }

    private static ImageFormatting PrepareImageFormattingForPantone()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            }
        };
    }

    private static ImageFormatting EditPantoneColorsByExtendedModelFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                },
                new()
                {
                    SourcePantoneColorId = "e1ca660f-896c-4916-908f-e3200d936aba",
                    DestinationPantoneColorId = "f6c8cdaf-53d8-4ffc-975a-6a75b1259193"
                }
            }
        };
    }

    private static ImageFormatting EditPantoneColorsByExtendedAndLegacyModelsFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            },
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "e1ca660f-896c-4916-908f-e3200d936aba",
                    DestinationPantoneColorId = "f6c8cdaf-53d8-4ffc-975a-6a75b1259193"
                }
            }
        };
    }

    private static ImageFormatting PrepareColorsToReplaceCmyk()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditCmykColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                },
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.67f,
                        M = 0.66f,
                        Y = 0.0f,
                        K = 0.47f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }

    private static ImageFormatting PrepareColorsToReplacePantone()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            }
        };
    }

    private static ImageFormatting EditPantoneColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                },
                new()
                {
                    SourcePantoneColorId = "e1ca660f-896c-4916-908f-e3200d936aba",
                    DestinationPantoneColorId = "f6c8cdaf-53d8-4ffc-975a-6a75b1259193"
                },
            }
        };
    }

    private static ImageFormatting EditAbsentCmykColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.1f,
                        M = 0.1f,
                        Y = 0.1f,
                        K = 1f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditAbsentCmykColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.1f,
                        M = 0.1f,
                        Y = 0.1f,
                        K = 1f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditAbsentCmykColorFormattingByCmykId()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "10000-10000-10000-10000",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1f
                    }
                }
            }
        };
    }
        
    private static ImageFormatting EditAbsentPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3",
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditAbsentPantoneColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3",
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditToInvalidCmykColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.1f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditToInvalidCmykColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.1f
                    }
                }
            }
        };
    }
    
    
    private static ImageFormatting EditToInvalidCmykColorFormattingByCmykId()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.1f
                    }
                }
            }
        };
    }
        
    private static ImageFormatting EditToInvalidPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "wrong-pantone-id"
                }
            }
        };
    }

    private static ImageFormatting EditToInvalidPantoneColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "wrong-pantone-id"
                }
            }
        };
    }

    private static ImageFormatting EditToTheSameCmykColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditToTheSameCmykColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditToTheSameCmykColorFormattingByCmykId()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditUndefinedCmykColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = null,
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditUndefinedCmykColorByExtendedModelFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = null,
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditUndefinedCmykColorByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = null,
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                }
            }
        };
    }
    private static ImageFormatting EditToUndefinedCmykColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = null
                }
            }
        };
    }

    private static ImageFormatting EditToTheSamePantoneColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditToTheSamePantoneColorFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditUndefinedPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = null,
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditUndefinedPantoneColorByExtendedModelFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = null,
                    DestinationPantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4"
                }
            }
        };
    }

    private static ImageFormatting EditToUndefinedPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = null
                }
            }
        };
    }

    private static ImageFormatting EditNoColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>(),
            CmyksToEdit = new List<CmykToEdit>(),
            PantonesToEdit = new List<PantoneToEdit>()
        };
    }

    private static ImageFormatting EditCmykAndPantoneColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    },
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            }
        };
    }

    private static ImageFormatting EditCmykAndPantoneColorsFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    },
                }
            },
            PantonesToEdit = new List<PantoneToEdit>()
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            }
        };
    }
    
    private static ImageFormatting EditCmykAndPantoneColorsFormattingByCmykId()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    },
                }
            },
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                }
            }
        };
    }
    
    private static ImageFormatting EditTheSameManyCmykColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                },
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }

    private static ImageFormatting EditTheSameManyCmykColorsFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                },
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditTheSameManyCmykColorsFormattingByCmykId()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 1.0f
                    }
                },
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    DestinationCmykColor = new Cmyk
                    {
                        C = 1.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    }
                }
            }
        };
    }
    
    private static ImageFormatting EditTheSameManyPantoneColorsFormatting()
    {
        return new ImageFormatting
        {
            ColorsToReplace = new List<ColorsToReplace>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                },
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "3499d7e9-3528-41d3-8ed5-bf371c342b34"
                }
            }
        };
    }

    private static ImageFormatting EditTheSameManyPantoneColorsFormattingByExtendedModel()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3"
                },
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    DestinationPantoneColorId = "3499d7e9-3528-41d3-8ed5-bf371c342b34"
                }
            }
        };
    }

    private static ImageFormatting HideCmykColorFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    IsHidden = true
                }
            }
        };
    }

    private static ImageFormatting HideCmykColorByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    IsHidden = true
                }
            }
        };
    }
    
    private static ImageFormatting HideInvalidCmykColorFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    },
                    IsHidden = true
                }
            }
        };
    }

    private static ImageFormatting HideInvalidCmykColorByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "00000-00000-00000-00000",
                    IsHidden = true
                }
            }
        };
    }

    private static ImageFormatting ShowCmykColorFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.2103f,
                        M = 0.0000f,
                        Y = 0.8564f,
                        K = 0.2353f
                    },
                    IsHidden = false
                }
            }
        };
    }

    private static ImageFormatting ShowCmykColoByCmykIdrFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "02103-00000-08564-02353",
                    IsHidden = false
                }
            }
        };
    }

    private static ImageFormatting ShowInvalidCmykColorFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    },
                    IsHidden = false
                }
            }
        };
    }

    private static ImageFormatting ShowInvalidCmykColorByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "00000-00000-00000-00000",
                    IsHidden = false
                }
            }
        };
    }
    
    private static ImageFormatting HidePantoneColorFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    IsHidden = true
                }
            }
        };
    }

    private static ImageFormatting HideInvalidPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3",
                    IsHidden = true
                }
            }
        };
    }

    private static ImageFormatting ShowPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    IsHidden = false
                }
            }
        };
    }

    private static ImageFormatting ShowInvalidPantoneColorFormatting()
    {
        return new ImageFormatting
        {
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ccb31f4c-d645-45e2-b3a9-d1f3342ca8e3",
                    IsHidden = false
                }
            }
        };
    }

    private static ImageFormatting HideCmykAndPantoneColorsFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColor = new Cmyk
                    {
                        C = 0.0f,
                        M = 0.0f,
                        Y = 0.0f,
                        K = 0.0f
                    },
                    IsHidden = true
                }
            },
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    IsHidden = true
                }
            }
        };
    }
    
    private static ImageFormatting HideCmykAndPantoneColorsByCmykIdFormatting()
    {
        return new ImageFormatting
        {
            CmyksToEdit = new List<CmykToEdit>
            {
                new()
                {
                    SourceCmykColorId = "00000-00000-00000-00000",
                    IsHidden = true
                }
            },
            PantonesToEdit = new List<PantoneToEdit>
            {
                new()
                {
                    SourcePantoneColorId = "ea15d84c-d9d9-46ba-ad07-0d98709bcae4",
                    IsHidden = true
                }
            }
        };
    }
    
    private void EditImage(ImageFormatting formatting)
    {
        try
        {
            _editedImageId = _imageService.EditImage(_imageId, UserId, formatting);
        }
        catch (InvalidServiceResponseException ex)
        {
            _errorMessage = ex.ErrorDescription;
        }
    }
}