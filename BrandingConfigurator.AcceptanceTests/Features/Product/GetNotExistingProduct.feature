Feature: Get not existing product

Scenario: Get not existing product
	When I request for not existing product
	Then error code instead of product is provided