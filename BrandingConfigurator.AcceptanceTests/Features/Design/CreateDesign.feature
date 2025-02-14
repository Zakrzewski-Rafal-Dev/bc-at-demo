Feature: Create design

    Scenario: Create design
        Given I have created a new design
        When I request for design
        Then The design is provided
            
    Scenario: Create design without UserId
        Given UserId was not provided
        Then The design is not created

    Scenario: Create design without decorations
        Given I have created a new design without decorations
        When I request for design
        Then The design is provided

    Scenario: Create design with empty decoration
        Given I have created a new design with empty decoration
        Then The design is not created

    Scenario: Create design with wrong print area id
        Given I have created a new design with wrong print area id
        Then The design is not created

    Scenario: Create design with wrong print technique id
        Given I have created a new design with wrong print technique id
        Then The design is not created

    Scenario: Create design with logo outside of print area
        Given I have created a new design with logo outside of print area
        Then The design is not created

    Scenario: Create design with logo edge points outside of print area
        Given I have created a new design with logo edge points outside of print area
        Then The design is not created

    Scenario: Create design with wrong supplier item id
        Given I have created a new design with wrong supplier item id
        Then The design is not created

    Scenario: Create design with wrong component id
        Given I have created a new design with wrong component id
        Then The design is not created
        
    Scenario: Create design with variants
        Given I have created a new design with variants
        When I request for design
        Then The design is provided
        
    Scenario: Create design with wrong id of variants
        Given I have created a new design with wrong id of variants
        Then The design is not created

    Scenario: Create design with wrong model of variants
        Given I have created a new design with wrong model of variants
        Then The design is not created
        
    Scenario: Create design with wrong value of angle of logo
        Given I have created a new design with wrong value of angle of logo
        Then The design is not created
        
    Scenario: Create design with wrong value of center point of logo
        Given I have created a new design with wrong value of center point of logo
        Then The design is not created

    Scenario: Create design with wrong value of width of logo
        Given I have created a new design with wrong value of width of logo
        Then The design is not created
                
    Scenario: Create design with wrong value of height of logo
        Given I have created a new design with wrong value of height of logo
        Then The design is not created

    Scenario: Create design with wrong value of scaled x of logo
        Given I have created a new design with wrong value of scaled x of logo
        Then The design is not created
        
    Scenario: Create design with wrong value of scaled y of logo
        Given I have created a new design with wrong value of scaled y of logo
        Then The design is not created

        