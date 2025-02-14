Feature: Create design template

    Scenario: Create design template with name
        Given I have created a new design template with name for user id
        When I request for design template for user id
        Then The design template is provided with name

    Scenario: Create design template with existing name
        Given I create design template with name
        When I create a design template with existing name
        Then The design template is not created
        
    Scenario: Create design template without name
        Given I have created a new design template without name for user id
        When I request for design template for user id
        Then The design template is provided with default name      