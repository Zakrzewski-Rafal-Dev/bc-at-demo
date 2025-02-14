Feature: Update design

    Scenario: Update by design
        Given I have created a new design without decorations
        When I update the design
        When I request for design
        Then The design is updated

    Scenario: Update design without UserId
        Given I have created a new design without decorations
        When I update the design without UserId
        Then The design is not updated

    Scenario: Update design without decorations
        Given I have created a new design
        When I update the design by design without decorations
        When I request for design
        Then The design is updated

    Scenario: Update design by design with wrong print area id
        Given I have created a new design
        When I update the design by design with wrong print area id
        Then The design is not updated

    Scenario: Update design by design with wrong print technique id
        Given I have created a new design
        When I update the design by design with wrong print technique id
        Then The design is not updated

    Scenario: Update design by design with logo outside of print area
        Given I have created a new design
        When I update the design by design with logo outside of print area
        Then The design is not updated

    Scenario: Update design by design with wrong supplier item id
        Given I have created a new design
        When I update the design by design with wrong supplier item id
        Then The design is not updated

    Scenario: Update design by design with wrong component id
        Given I have created a new design
        When I update the design by design with wrong component id
        Then The design is not updated
        
    Scenario: Update design with variants
        Given I have created a new design
        When I update the design by design with variants
        When I request for design
        Then The design is updated    
        
    Scenario: Update design with wrong id of variants
        Given I have created a new design
        When I update the design by design with wrong id of variants
        Then The design is not updated   

    Scenario: Update design with wrong model of variants
        Given I have created a new design
        When I update the design by design with wrong model of variants
        Then The design is not updated

    Scenario: Update design with wrong value of angle of logo
        Given I have created a new design
        When I update the design with wrong value of angle of logo
        Then The design is not updated
        
    Scenario: Update design with wrong value of center point of logo
        Given I have created a new design
        When I update the design with wrong value of center point of logo
        Then The design is not updated

    Scenario: Update design with wrong value of width of logo
        Given I have created a new design
        When I update the design with wrong value of width of logo
        Then The design is not updated
                
    Scenario: Update design with wrong value of height of logo
        Given I have created a new design
        When I update the design with wrong value of height of logo
        Then The design is not updated

    Scenario: Update design with wrong value of scaled x of logo
        Given I have created a new design
        When I update the design with wrong value of scaled x of logo
        Then The design is not updated
        
    Scenario: Update design with wrong value of scaled y of logo
        Given I have created a new design
        When I update the design with wrong value of scaled y of logo
        Then The design is not updated    