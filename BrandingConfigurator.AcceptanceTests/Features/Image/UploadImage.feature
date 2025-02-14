Feature: Upload image

Scenario: Upload pdf image
    Given I have uploaded pdf image file
    When I request for the image
    Then The image metadata is returned
    And The image file is returned when requested

Scenario: Upload cdr image
    Given I have uploaded cdr image file
    When I request for the image
    Then The image metadata is returned
    And The image file is returned when requested

Scenario: Upload eps image
    Given I have uploaded eps image file
    When I request for the image
    Then The image metadata is returned
    And The image file is returned when requested

Scenario: Upload ai image
    Given I have uploaded ai image file
    When I request for the image
    Then The image metadata is returned
    And The image file is returned when requested

Scenario: Upload invalid image type
    Given I have uploaded wrong image file type
    Then The invalid file type is returned

Scenario: Incorrect ImageId
    When I request for the image with incorrect id
    Then Image is not found

Scenario: Not existing file
    Given I have uploaded pdf image file
    When I request for the image
    Then I request for the image file with wrong path
    And Image is not found

Scenario: Upload pdf image without UserId
    When I upload image file without UserId
    Then Image is not uploaded
    
Scenario: Get image without UserId
    Given I have uploaded pdf image file
    When I request for the image without UserId
    Then Image is not returned
    
Scenario: Update image without UserId
    Given I have uploaded pdf image file
    When I update image without UserId
    Then Image is not updated    

Scenario: Get uploaded images
    Given I have uploaded pdf image file twice
    When I request for the images
    Then The images metadata is returned from newest to oldest

Scenario: Get paged images
    Given I have uploaded pdf image file twice
    When I request for the paged images
    Then Paged images are returned