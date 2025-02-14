Feature: Update design template

    Scenario: Update design template
        Given I have created a new design template with name for user id
        When I update design template
        Then The design template is updated

    Scenario: Update non-existent design template
        Given I have created a new design template with name for user id
        When I update design template that does not exist
        Then The design template is not updated
        
    Scenario: Update design template with non-existent design
        Given I have created a new design template with name for user id
        When I update design template with design that does not exist
        Then The design template is not updated

    Scenario: SupplierItemId for design and design template does not match
        Given I have created a new design and design template with supplierItemId not matching
        When I update design template with design with not matching supplierItemId
        Then The design template is not updated
 