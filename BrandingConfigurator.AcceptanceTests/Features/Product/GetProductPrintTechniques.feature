Feature: Get product print techniques

Scenario: Get product print techniques with locale sv_SE
	When I request for product print techniques for locale sv_SE
	Then product print techniques is provided and translated to locale sv_SE

Scenario: Get product print techniques with locale en_GB
	When I request for product print techniques for locale en_GB
	Then product print techniques is provided and translated to locale en_GB