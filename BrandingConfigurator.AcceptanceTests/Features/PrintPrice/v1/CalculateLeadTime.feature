Feature: Calculate lead time
    
    Scenario: Calculate lead time for empty design
        Given I have uploaded an image
        And I have created an empty design 
        When I request for lead time for the design
        Then The zero lead time is always returned

    Scenario: Calculate lead time for design with one print area and one print technique and quantity below preferential threshold
        Given I have uploaded an image
        And I have created an design with one print area and one print technique 
        When I request for lead time for the design and quantity below preferential threshold
        Then The one day lead time is returned       
        
    Scenario: Calculate lead time for design with one print area and one print technique and quantity above preferential threshold
        Given I have uploaded an image
        And I have created an design with one print area and one print technique
        When I request for lead time for the design and quantity above preferential threshold
        Then The standard lead time is returned       
         
    Scenario: Calculate lead time for design with many print area and one print techniques and quantity below preferential threshold
        Given I have uploaded an image
        And I have created an design with many print area and one print technique
        When I request for lead time for the design and quantity below preferential threshold
        Then The extended one lead time is returned        
     
    Scenario: Calculate lead time for design with many print area and one print techniques and quantity above preferential threshold
        Given I have uploaded an image
        And I have created an design with many print area and one print technique
        When I request for lead time for the design and quantity above preferential threshold
        Then The extended standard lead time is returned   
   
    Scenario: Calculate lead time for design with many print areas and many print techniques and quantity below preferential threshold
        Given I have uploaded an image
        And I have created an design with many print areas and many print techniques
        When I request for lead time for the design and quantity below preferential threshold
        Then The combined standard lead time is returned

    Scenario: Calculate lead time for design with many print areas and many print techniques and quantity above preferential threshold
        Given I have uploaded an image
        And I have created an design with many print areas and many print techniques
        When I request for lead time for the design and quantity above preferential threshold
        Then The combined standard lead time is returned