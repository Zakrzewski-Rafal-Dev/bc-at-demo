Feature: Get product

Scenario: Get product
	When I request for product
	Then product is provided

Scenario: Get product with locale sv_SE
	When I request for product with locale sv_SE
	Then product is provided and translated to locale sv_SE

Scenario: Get product with locale en_GB
	When I request for product with locale en_GB
	Then product is provided and translated to locale en_GB