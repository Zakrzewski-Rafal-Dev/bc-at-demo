Feature: Get design template by name and supplierItemId

    Scenario: Get design template by name and supplierItemId for user id
        Given I have created a new design template with name for user id
        When I request for design template by name and supplierItemId for user id
        Then The design template is provided with name
        
    Scenario: Get design template without supplierItemId for user id
        Given I have created a new design template with name for user id
        When I request for design template with name and without supplierItemId for user id
        Then The design template is not provided
        
    Scenario: Get design template with supplierItemId and without name for user id
        Given I have created a new design template with name for user id
        When I request for design template without name and with supplierItemId for user id
        Then The design template is not provided
    
    Scenario: Get design template by and supplierItemId for user id and locale sv_SE
        Given I have created a new design template with name for user id
        When I request for design template by name and supplierItemId for user id and locale sv_SE
        Then The design template is provided with name and translated to locale sv_SE

    Scenario: Get design template by and supplierItemId for user id and locale en_GB
        Given I have created a new design template with name for user id
        When I request for design template by name and supplierItemId for user id and locale en_GB
        Then The design template is provided with name and translated to locale en_GB