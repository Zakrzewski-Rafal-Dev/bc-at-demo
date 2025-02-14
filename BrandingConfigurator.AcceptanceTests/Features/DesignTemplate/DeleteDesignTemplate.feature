Feature: Delete design template

    Scenario: Delete design template 
        Given I have created a new design template with name for user id
        When I delete the design template for user id
        When I request for design template for user id
        Then The design template is not provided
        Then The design template previews are not provided
        
    Scenario: Do not delete design template 
        Given I have created a new design template with name for user id
        When I delete the design template for other user id
        When I request for design template for user id
        Then The design template is provided with name