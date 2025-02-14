using BrandingConfigurator.AcceptanceTests.Applications.Configuration;
using BrandingConfigurator.AcceptanceTests.Applications.Driver.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.File.RestApi;
using BrandingConfigurator.AcceptanceTests.Business.Image.RestApi;

namespace BrandingConfigurator.AcceptanceTests.Business.Image;

[Binding]
public class ImageStepDefinitions
{
    private readonly ImageSteps _imageSteps;

    public ImageStepDefinitions()
    {
        _imageSteps = new ImageSteps(
            new ImageRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()),
            new FileRestApiService(TestRunConfiguration.GetInstance(), new RestDriver()));
    }

    [Given(@"I have uploaded (.*) image file")]
    public void GivenIHaveUploadedImageFile(string fileType)
    {
        _imageSteps.UploadImageFile(fileType);
    }

    [Given(@"I have uploaded (.*) image file twice")]
    public void GivenIHaveUploadedImageFileTwice(string fileType)
    {
        _imageSteps.UploadImageFileTwice(fileType);
    }

    [Given(@"I have uploaded wrong image file type")]
    public void GivenIHaveUploadedWrongImageFileType()
    {
        _imageSteps.UploadWrongImageFileType();
    }
    
    [When(@"I request for the image")]
    public void WhenIRequestForTheImage()
    {
        _imageSteps.GetImageMetadata();
    }

    [When(@"I request for the images")]
    public void WhenIRequestForTheImages()
    {
        _imageSteps.GetImagesMetadata();
    }

    [When(@"I request for the image with incorrect id")]
    public void WhenIRequestForTheImageWithIncorrectId()
    {
        _imageSteps.GetImageMetadataByInvalidId();
    }

    [When(@"I upload image file without UserId")]
    public void WhenIUploadPdfImageFileWithoutUserId()
    {
        _imageSteps.UploadImageFileWithoutUserId();
    }

    [When(@"I request for the image without UserId")]
    public void WhenIRequestForTheImageWithoutUserId()
    {
        _imageSteps.GetImageMetadataWithoutUserId();
    }

    [When(@"I update image without UserId")]
    public void WhenIUpdateImageWithoutUserId()
    {
        _imageSteps.UpdateImageWithoutUserId();
    }
    
    [When(@"I hide Cmyk color")]
    public void WhenIHideCmykColor()
    {
        _imageSteps.HideCmykColor();
    }
    
    [When(@"I hide Cmyk color by Cmyk id")]
    public void WhenIHideCmykColorByCmykId()
    {
        _imageSteps.HideCmykColorByCmykId();
    }

    [When(@"I change Pantone color")]
    public void WhenIChangePantoneColor()
    {
        _imageSteps.EditPantoneColor();
    }

    [When(@"I change Pantone colors")]
    public void WhenIChangePantoneColors()
    {
        _imageSteps.EditPantoneColors();
    }
    
    [When(@"I change Cmyk color by extended model")]
    public void WhenIChangeCmykColorByExtendedModel()
    {
        _imageSteps.EditCmykColorByExtendedModel();
    }
    
    [When(@"I change Cmyk color by Cmyk id")]
    public void WhenIChangeCmykColorByCmykId()
    {
        _imageSteps.EditCmykColorByCmykId();
    }

    [When(@"I change Cmyk colors by extended model")]
    public void WhenIChangeCmykColorsByExtendedModel()
    {
        _imageSteps.EditCmykColorsByExtendedModel();
    }
    
    [When(@"I change Cmyk colors by Cmyk id")]
    public void WhenIChangeCmykColorsByCmykId()
    {
        _imageSteps.EditCmykColorsByCmykId();
    }
    
    [When(@"I change Cmyk colors by extended and legacy models")]
    public void WhenIChangeCmykColorsByExtendedAndLegacyModels()
    {
        _imageSteps.EditCmykColorsByExtendedAndLegacyModel();
    }
    
    [When(@"I change Cmyk colors by Cmyk id and legacy models")]
    public void WhenIChangeCmykColorsByCmykIdAndLegacyModels()
    {
        _imageSteps.EditCmykColorsByCmykIdAndLegacyModel();
    }
    
    [When(@"I change Pantone color by extended model")]
    public void WhenIChangePantoneColorByExtendedModel()
    {
        _imageSteps.EditPantoneColorByExtendedModel();
    }
    
    [When(@"I change Pantone colors by extended model")]
    public void WhenIChangePantoneColorsByExtendedModel()
    {
        _imageSteps.EditPantoneColorsByExtendedModel();
    }
    
    [When(@"I change Pantone colors by extended and legacy models")]
    public void WhenIChangePantoneColorsByExtendedAndLegacyModels()
    {
        _imageSteps.EditPantoneColorsByExtendedAndLegacyModels();
    }
    
    [When(@"I change absent Cmyk color")]
    public void WhenIChangeAbsentCmykColor()
    {
        _imageSteps.EditAbsentCmykColor();
    }
    
    [When(@"I change absent Pantone color")]
    public void WhenIChangeAbsentPantoneColor()
    {
        _imageSteps.EditAbsentPantoneColor();
    }
    
    [When(@"I change absent Cmyk color by extended model")]
    public void WhenIChangeAbsentCmykColorByExtendedModel()
    {
        _imageSteps.EditAbsentCmykColorByExtendedModel();
    }

    [When(@"I change absent Cmyk color by Cmyk id")]
    public void WhenIChangeAbsentCmykColorByCmykId()
    {
        _imageSteps.EditAbsentCmykColorByCmykId();
    }
    
    [When(@"I change absent Pantone color by extended model")]
    public void WhenIChangeAbsentPantoneColorByExtendedModel()
    {
        _imageSteps.EditAbsentPantoneColorByExtendedModel();
    }
    
    [When(@"I change to invalid Cmyk color")]
    public void WhenIChangeToInvalidCmykColor()
    {
        _imageSteps.EditToInvalidCmykColor();
    }
    
    [When(@"I change to invalid Pantone color")]
    public void WhenIChangeToInvalidPantoneColor()
    {
        _imageSteps.EditToInvalidPantoneColor();
    }
    
    [When(@"I change to invalid Cmyk color by extended model")]
    public void WhenIChangeToInvalidCmykColorByExtendedModel()
    {
        _imageSteps.EditToInvalidCmykColorByExtendedModel();
    }

    [When(@"I change to invalid Cmyk color by Cmyk id")]
    public void WhenIChangeToInvalidCmykColorByCmykId()
    {
        _imageSteps.EditToInvalidCmykColorByCmykId();
    }
    
    [When(@"I change to invalid Pantone color by extended model")]
    public void WhenIChangeToInvalidPantoneColorByExtendedModel()
    {
        _imageSteps.EditToInvalidPantoneColorByExtendedModel();
    }
    
    [When(@"I change to the same Cmyk color")]
    public void WhenIChangeToTheSameCmykColor()
    {
        _imageSteps.EditToTheSameCmykColor();
    }
    
    [When(@"I change to the same Pantone color")]
    public void WhenIChangeToTheSamePantoneColor()
    {
        _imageSteps.EditToTheSamePantoneColor();
    }
    
    [When(@"I change to the same Cmyk color by extended model")]
    public void WhenIChangeToTheSameCmykColorByExtendedModel()
    {
        _imageSteps.EditToTheSameCmykColorByExtendedModel();
    }
    
    [When(@"I change to the same Cmyk color by Cmyk id")]
    public void WhenIChangeToTheSameCmykColorByCmykId()
    {
        _imageSteps.EditToTheSameCmykColorByCmykId();
    }
   
    [When(@"I change to the same Pantone color by extended model")]
    public void WhenIChangeToTheSamePantoneColorByExtendedModel()
    {
        _imageSteps.EditToTheSamePantoneColorByExtendedModel();
    }
    
    [When(@"I change undefined Cmyk color")]
    public void WhenIChangeUndefinedCmykColor()
    {
        _imageSteps.EditUndefinedCmykColor();
    }
    
    [When(@"I change undefined Cmyk color by extended model")]
    public void WhenIChangeUndefinedCmykColorByExtendedModel()
    {
        _imageSteps.EditUndefinedCmykColorByExtendedModel();
    }
    
    [When(@"I change undefined Cmyk color by Cmyk id")]
    public void WhenIChangeUndefinedCmykColorByCmykId()
    {
        _imageSteps.EditUndefinedCmykColorByCmykId();
    }
    
    [When(@"I change undefined Pantone color")]
    public void WhenIChangeUndefinedPantoneColor()
    {
        _imageSteps.EditUndefinedPantoneColor();
    }
    
    [When(@"I change undefined Pantone color by extended model")]
    public void WhenIChangeUndefinedPantoneColorByExtendedModel()
    {
        _imageSteps.EditUndefinedPantoneColorByExtendedModel();
    }
    
    [When(@"I change to undefined Cmyk color")]
    public void WhenIChangeToUndefinedCmykColor()
    {
        _imageSteps.EditToUndefinedCmykColor();
    }
    
    [When(@"I change to undefined Pantone color")]
    public void WhenIChangeToUndefinedPantoneColor()
    {
        _imageSteps.EditToUndefinedPantoneColor();
    }
    
    [When(@"I hide invalid Cmyk color")]
    public void WhenIHideInvalidCmykColor()
    {
        _imageSteps.HideInvalidCmykColor();
    }
    
    [When(@"I hide invalid Cmyk color by Cmyk id")]
    public void WhenIHideInvalidCmykColorByCmykId()
    {
        _imageSteps.HideInvalidCmykColorByCmykId();
    }

    [When(@"I change Cmyk color")]
    public void WhenIChangeCmykColor()
    {
        _imageSteps.EditCmykColor();
    }
    
    [When(@"I change Cmyk colors")]
    public void WhenIChangeCmykColors()
    {
        _imageSteps.EditCmykColors();
    }

    [When(@"I show Cmyk color")]
    public void WhenIShowCmykColor()
    {
        _imageSteps.ShowCmykColor();
    }

    [When(@"I show Cmyk color by Cmyk id")]
    public void WhenIShowCmykColorByCmykId()
    {
        _imageSteps.ShowCmykColorByCmykId();
    }
    
    [When(@"I show invalid Cmyk color")]
    public void WhenIShowInvalidCmykColor()
    {
        _imageSteps.ShowInvalidCmykColor();
    }
    
    [When(@"I show invalid Cmyk color by Cmyk id")]
    public void WhenIShowInvalidCmykColorByCmykId()
    {
        _imageSteps.ShowInvalidCmykColorByCmykId();
    }
    
    [When(@"I hide Pantone color")]
    public void WhenIHidePantoneColor()
    {
        _imageSteps.HidePantoneColor();
    }
    
    [When(@"I hide invalid Pantone color")]
    public void WhenIHideInvalidPantoneColor()
    {
        _imageSteps.HideInvalidPantoneColor();
    }
    
    [When(@"I show Pantone color")]
    public void WhenIShowPantoneColor()
    {
        _imageSteps.ShowPantoneColor();
    }
    
    [When(@"I show invalid Pantone color")]
    public void WhenIShowInvalidPantoneColor()
    {
        _imageSteps.ShowInvalidPantoneColor();
    }

    [When(@"I hide Cmyk and Pantone colors")]
    public void WhenIHideCmykAndPantoneColors()
    {
        _imageSteps.HideCmykAndPantoneColors();
    }
    
    [When(@"I hide Cmyk and Pantone colors by Cmyk id")]
    public void WhenIHideCmykAndPantoneColorsByCmykId()
    {
        _imageSteps.HideCmykAndPantoneColorsByCmykId();
    }
    
    [When(@"I change no colors")]
    public void WhenIChangeNoColors()
    {
        _imageSteps.EditNoColors();
    }
    
    [When(@"I change Cmyk and Pantone colors")]
    public void WhenIChangeCmykAndPantoneColors()
    {
        _imageSteps.EditCmykAndPantoneColors();
    }
    
    [When(@"I change Cmyk and Pantone colors by extended model")]
    public void WhenIChangeCmykAndPantoneColorsByExtendedModel()
    {
        _imageSteps.EditCmykAndPantoneColorsByExtendedModel();
    }
    
    [When(@"I change Cmyk and Pantone colors by Cmyk id")]
    public void WhenIChangeCmykAndPantoneColorsByCmykId()
    {
        _imageSteps.EditCmykAndPantoneColorsByCmykId();
    }
    
    [When(@"I change the same Cmyk color many times")]
    public void WhenIChangeTheSameCmykColorManyTimes()
    {
        _imageSteps.EditTheSameCmykColorManyTimes();
    }
    
    [When(@"I change the same Cmyk color many times by extended model")]
    public void WhenIChangeTheSameCmykColorManyTimesByExtendedModel()
    {
        _imageSteps.EditTheSameCmykColorManyTimesByExtendedModel();
    }
    
    [When(@"I change the same Cmyk color many times by Cmyk id")]
    public void WhenIChangeTheSameCmykColorManyTimesByCmykId()
    {
        _imageSteps.EditTheSameCmykColorManyTimesByCmykId();
    }
    
    [When(@"I change the same Pantone color many times")]
    public void WhenIChangeTheSamePantoneColorManyTimes()
    {
        _imageSteps.EditTheSamePantoneColorManyTimes();
    }
    
    [When(@"I change the same Pantone color many times by extended model")]
    public void WhenIChangeTheSamePantoneColorManyTimesByExtendedModel()
    {
        _imageSteps.EditTheSamePantoneColorManyTimesByExtendedModel();
    }
    
    [When(@"I request for the paged images")]
    public void WhenIRequestForThePagedImages()
    {
        _imageSteps.GetPagedImagesMetadata();
    }
    
    [When(@"I delete image")]
    public void WhenIDeleteImage()
    {
        _imageSteps.DeleteImage();
    }
    
    [Then(@"The image metadata is returned")]
    public void ThenTheImageMetadataIsReturned()
    {
        _imageSteps.TheImageMetadataIsReturned();
    }
    
    [Then(@"The images metadata is returned from newest to oldest")]
    public void ThenTheImageMetadataIsReturnedFromNewestToOldest()
    {
        _imageSteps.TheImageMetadataIsReturnedFromNewestToOldest();
    }
    
    [Then(@"Paged images are returned")]
    public void ThenPagedImagesAreReturned()
    {
        _imageSteps.PagedImagesAreReturned();
    }

    [Then(@"The image file is returned when requested")]
    public void ThenTheImageFileIsReturnedWhenRequested()
    {
        _imageSteps.GetImageFile();
    }

    [Then(@"The invalid file type is returned")]
    public void ThenTheInvalidFileTypeIsReturned()
    {
        _imageSteps.InvalidFileTypeIsReturned();
    }

    [Then(@"Image is not found")]
    public void ThenImageIsNotFound()
    {
        _imageSteps.ImageIsNotFound();
    }

    [Then(@"I request for the image file with wrong path")]
    public void WhenIRequestForTheImageFileWithWrongPath()
    {
        _imageSteps.GetImageFileWithWrongFilePath();
    }

    [Then(@"Image is not returned")]
    public void ThenImageIsNotReturned()
    {
        _imageSteps.ImageIsNotReturned();
    }

    [Then(@"Image is not updated")]
    public void ThenImageIsNotUpdated()
    {
        _imageSteps.ImageIsNotUpdated();
    }

    [Then(@"Image is not uploaded")]
    public void ThenImageIsNotUploaded()
    {
        _imageSteps.ImageIsNotUploaded();
    }
    
    [Then(@"Cmyk color is changed")]
    public void ThenCmykColorIsChanged()
    {
        _imageSteps.CmykColorIsChanged();
    }

    [Then(@"Cmyk colors are changed")]
    public void ThenCmykColorsAreChanged()
    {
        _imageSteps.CmykColorsAreChanged();
    }
    
    [Then(@"Pantone color is changed")]
    public void ThenPantoneColorIsChanged()
    {
        _imageSteps.PantoneColorIsChanged();
    }

    [Then(@"Pantone colors are changed")]
    public void ThenPantoneColorsAreChanged()
    {
        _imageSteps.PantoneColorsAreChanged();
    }
    
    [Then(@"Cmyk color is changed by extended model")]
    public void ThenCmykColorIsChangedByExtendedModel()
    {
        _imageSteps.CmykColorIsChangedByExtendedModel();
    }
    
    [Then(@"Cmyk color is changed by Cmyk id")]
    public void ThenCmykColorIsChangedByCmykId()
    {
        _imageSteps.CmykColorIsChangedByCmykId();
    }

    [Then(@"Cmyk colors are changed by extended model")]
    public void ThenCmykColorsAreChangedByExtendedModel()
    {
        _imageSteps.CmykColorsAreChangedByExtendedModel();
    }
    
    [Then(@"Cmyk colors are changed by Cmyk id")]
    public void ThenCmykColorsAreChangedByCmykId()
    {
        _imageSteps.CmykColorsAreChangedByCmykId();
    }
    
    [Then(@"Cmyk colors are changed by extended and legacy models")]
    public void ThenCmykColorsAreChangedByExtendedAndLegacyModels()
    {
        _imageSteps.CmykColorsAreChangedByExtendedAndLegacyModels();
    }
    
    [Then(@"Pantone color is changed by extended model")]
    public void ThenPantoneColorIsChangedByExtendedModel()
    {
        _imageSteps.PantoneColorIsChangedByExtendedModel();
    }
    
    [Then(@"Pantone colors are changed by extended model")]
    public void ThenPantoneColorsAreChangedByExtendedModel()
    {
        _imageSteps.PantoneColorsAreChangedByExtendedModel();
    }
    
    [Then(@"Pantone colors are changed by extended and legacy models")]
    public void ThenPantoneColorsAreChangedByExtendedAndLegacyModels()
    {
        _imageSteps.PantoneColorsAreChangedByExtendedAndLegacyModels();
    }
    
    [Then(@"Cmyk color is hidden")]
    public void ThenCmykColorIsHidden()
    {
        _imageSteps.CmykColorIsHidden();
    }
    
    [Then(@"Pantone color is hidden")]
    public void ThenPantoneColorIsHidden()
    {
        _imageSteps.PantoneColorIsHidden();
    }
    
    [Then(@"Cmyk color is shown")]
    public void ThenCmykColorIsShown()
    {
        _imageSteps.CmykColorIsShown();
    }
    
    [Then(@"Pantone color is shown")]
    public void ThenPantoneColorIsShown()
    {
        _imageSteps.PantoneColorIsShown();
    }

    [Then(@"Cmyk color has not been hidden")]
    public void ThenCmykColorHasNotBeenHidden()
    {
        _imageSteps.CmykColorHasNotBeenHidden();
    }
    
    [Then(@"Cmyk color has not been shown")]
    public void ThenCmykColorHasNotBeenShown()
    {
        _imageSteps.CmykColorHasNotBeenShown();
    }
    
    [Then(@"Pantone color has not been hidden")]
    public void ThenPantoneColorHasNotBeenHidden()
    {
        _imageSteps.PantoneColorHasNotBeenHidden();
    }
    
    [Then(@"Pantone color has not been shown")]
    public void ThenPantoneColorHasNotBeenShown()
    {
        _imageSteps.PantoneColorHasNotBeenShown();
    }
    
    [Then(@"Cmyk and Pantone colors have not been changed")]
    public void ThenCmykAndPantoneColorsHaveNotBeenChanged()
    {
        _imageSteps.CmykAndPantoneColorsHaveNotBeenChanged();
    }
    
    [Then(@"Original Cmyk colors has not been changed")]
    public void ThenOriginalCmykColorsHasNotBeenChanged()
    {
        _imageSteps.OriginalCmykColorsHasNotBeenChanged();
    }
    
    [Then(@"Original Pantone colors has not been changed")]
    public void ThenOriginalPantoneColorsHasNotBeenChanged()
    {
        _imageSteps.OriginalPantoneColorsHasNotBeenChanged();
    }
    
    [Then(@"Cmyk color is undefined")]
    public void ThenCmykColorIsUndefined()
    {
        _imageSteps.CmykColorIsUndefined();
    }
    
    [Then(@"Cmyk color is undefined in extended model")]
    public void ThenCmykColorIsUndefinedInExtendedModel()
    {
        _imageSteps.CmykColorIsUndefinedInExtendedModel();
    }
    
    [Then(@"Pantone color is undefined")]
    public void ThenPantoneColorIsUndefined()
    {
        _imageSteps.PantoneColorIsUndefined();
    }
    
    [Then(@"Pantone color is undefined in extended model")]
    public void ThenPantoneColorIsUndefinedInExtendedModel()
    {
        _imageSteps.PantoneColorIsUndefinedInExtendedModel();
    }

    [Then(@"Cmyk color is not found in image")]
    public void ThenCmykColorIsNotFoundInImage()
    {
        _imageSteps.ColorIsNotFoundInImage();
    }
    
    [Then(@"Pantone color is not found in image")]
    public void ThenPantoneColorIsNotFoundInImage()
    {
        _imageSteps.ColorIsNotFoundInImage();
    }

    [Then(@"No colors to change")]
    public void ThenNoColorsToChange()
    {
        _imageSteps.NoColorsToChange();
    }
    
    [Then(@"There are two types of colors")]
    public void ThenThereAreTwoTypesOfColors()
    {
        _imageSteps.ThereAreTwoTypesOfColors();
    }
    
    [Then(@"Cmyk color is invalid")]
    public void ThenCmykColorIsInvalid()
    {
        _imageSteps.CmykColorIsInvalid();
    }
    
    [Then(@"Pantone color is invalid")]
    public void ThenPantoneColorIsInvalid()
    {
        _imageSteps.PantoneColorIsInvalid();
    }
    
    [Then(@"Cmyk colors are the same")]
    public void ThenCmykColorsAreTheSame()
    {
        _imageSteps.ColorsAreTheSame();
    }
    
    [Then(@"Pantone colors are the same")]
    public void ThenPantoneColorsAreTheSame()
    {
        _imageSteps.ColorsAreTheSame();
    }
    
    [Then(@"Image is deleted")]
    public void ThenImageIsDeleted()
    {
        _imageSteps.ImageIsDeleted();
    }
}