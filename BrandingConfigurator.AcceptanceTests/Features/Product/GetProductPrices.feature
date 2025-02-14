Feature: Get product prices

Scenario: Get product prices in SEK
	When I request for product prices in SEK
	Then product prices in SEK are provided

Scenario: Get product prices in EUR
	When I request for product prices in EUR
	Then product prices in EUR are provided