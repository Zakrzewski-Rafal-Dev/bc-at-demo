Feature: Delete image

Scenario: Delete image
    Given I have uploaded pdf image file
    When I delete image
    Then Image is deleted
