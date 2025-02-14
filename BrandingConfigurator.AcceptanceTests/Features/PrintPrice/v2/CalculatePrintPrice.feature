Feature: Calculate print prices for variants
    
    Scenario: Calculate print prices for print area whose print price depends on the size of the logo
        Given I have uploaded an image
        And I have created a design with a print area whose print price depends on the size of the logo
        When I request for print price for variants
        Then The valid print price for variants is returned

    Scenario: Calculate print prices for print area whose print price depend on the number of color
        Given I have uploaded an image
        And I have created a design with a print area whose print price depend on the number of colors
        When I request for print price for variants
        Then The valid print price for variants is returned

    Scenario: Calculate print prices for print area whose print price is fixed
        Given I have uploaded an image
        And I have created a design with a print area whose print price is fixed
        When I request for print price for variants
        Then The valid print price for variants is returned

    Scenario: Calculate print prices in SEK
        Given I have uploaded an image
        And I have created a design
        When I request for print price in SEK for variants
        Then The valid print price for variants in SEK is returned

    Scenario: Calculate print prices in EUR
        Given I have uploaded an image
        And I have created a design
        When I request for print price in EUR for variants
        Then The valid print price for variants in EUR is returned

    Scenario: Calculate print prices for wrong currency
        Given I have uploaded an image
        And I have created a design
        When I request for print price in wrong currency for variants
        Then Print prices are not given

    Scenario: Calculate print prices for zero product quantity
        Given I have uploaded an image
        And I have created a design
        When I request for print price for zero product quantity of variants
        Then The zero print price for variants is returned

    Scenario: Calculate print prices for negative product quantity
        Given I have uploaded an image
        And I have created a design
        When I request for print price for negative product quantity of variants
        Then The zero print price for variants is returned

    Scenario: Calculate print prices for not existing design
        When I request for print price for not existing design
        Then Error code instead of print price is returned    
  
    Scenario: Calculate print prices without variants
        Given I have uploaded an image
        And I have created a design
        When I request for print price without variants
        Then The zero print price and no variants is returned
