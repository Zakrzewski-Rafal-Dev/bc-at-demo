Feature: Create text

Scenario: Create text
	Given I asked for text configuration 
	And I created a new text
	When I ask for the text
	Then the image for text is returned

Scenario: Get paged text configuration
	When I ask for paged text configuration
	Then The paged configuration is returned

Scenario: Get filtered text configuration
	When I ask for filtered text configuration
	Then The filtered page is returned

Scenario: Create text with wrong font
	Given I asked for text configuration
	When I create text with wrong font
	Then Wrong font error is returned

Scenario: Create text with wrong pms color
	Given I asked for text configuration
	When I create text with wrong pms color
	Then Wrong pms color error is returned

Scenario: Create text with wrong cmyk color
	Given I asked for text configuration
	When I create text with wrong cmyk color
	Then Wrong cmyk color error is returned

Scenario: Create text with two color types
	Given I asked for text configuration
	When I create text with two color types
	Then Only one type of colors error is returned

Scenario: Create text with wrong style
	Given I asked for text configuration
	When I create text with wrong style
	Then Text formatting error is returned

Scenario: Create text with wrong alignment
	Given I asked for text configuration
	When I create text with wrong alignment
	Then Text formatting error is returned

Scenario: Get not existing text metadata
	Given I asked for text configuration 
	And I created a new text
	When I ask for the not existing text
	Then NotFound error is returned

Scenario: Get not existing text graphic
	Given I asked for text configuration 
	And I created a new text
	When I ask for the text with wrong graphic path
	Then NotFound error is returned