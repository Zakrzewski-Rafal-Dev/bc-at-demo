Feature: Get design templates

    Scenario: Get design templates for user id
        Given I have created a new design template with name for user id
        When I request for design templates for user id
        Then The design templates are provided    

    Scenario: Get paged design templates for user id
        Given I have created multiple design templates with name for user id
        When I request for paged design templates for user id
        Then Paged design templates are provided

    Scenario: Get design templates for other user id
        Given I have created a new design template with name for user id
        When I request for design templates for other user id
        Then The design templates are not provided
 
    Scenario: Search design templates by name for user id
        Given I have created a new design template with name for user id
        When I request for design templates by name for user id
        Then The design templates are provided
        
    Scenario: Search design templates by other name for user id
        Given I have created a new design template with name for user id
        When I request for design templates by other name for user id
        Then The design templates are not provided
    
    Scenario: Get design templates for user id and locale sv_SE
        Given I have created a new design template with name for user id
        When I request for design templates for user id and locale sv_SE
        Then The design templates are provided and translated to locale sv_SE

    Scenario: Get design templates for user id and locale en_GB
        Given I have created a new design template with name for user id
        When I request for design templates for user id and locale en_GB
        Then The design templates are provided and translated to locale en_GB