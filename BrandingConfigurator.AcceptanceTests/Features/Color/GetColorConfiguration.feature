Feature: Get Color configuration

Scenario: Get paged color configuration
	When I ask for paged color configuration
	Then Paged configuration is returned

Scenario: Get filtered color configuration
	When I ask for filtered color configuration
	Then Filtered page is returned