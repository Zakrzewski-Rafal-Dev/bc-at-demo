Feature: Get design template

    Scenario: Get design template for user id
        Given I have created a new design template with name for user id
        When I request for design template for user id
        Then The design template is provided with name and default language

    Scenario: Get not design template for user id
        Given I have created a new design template with name for user id
        When I request for design template for other user id
        Then The design template is not provided
    
    Scenario: Get design template for user id and locale sv_SE
        Given I have created a new design template with name for user id
        When I request for design template for user id and locale sv_SE
        Then The design template is provided with name and translated to locale sv_SE

    Scenario: Get design template for user id and locale en_GB
        Given I have created a new design template with name for user id
        When I request for design template for user id and locale en_GB
        Then The design template is provided with name and translated to locale en_GB