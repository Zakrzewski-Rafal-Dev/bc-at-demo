Feature: Get design

    Scenario: Get design
        Given I have created a new design
        When I request for design
        Then The design is provided

    Scenario: Get not existing design
        When I request for not existing design
        Then The design is not provided
            
    Scenario: Get design without UserId
        Given I have created a new design
        When I request for design without UserId
        Then The design is not returned

    Scenario: Get design with variants
        Given I have created a new design with variants
        When I request for design
        Then The design is provided  