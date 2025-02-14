Feature: Get cms content

Scenario: Get FAQ for Help Center with Swedish locale
	When I request for FAQ for Help Center with Swedish locale
	Then FAQ for Help Center is provided and translated to Swedish locale

Scenario: Get FAQ for Help Center with English locale
	When I request for FAQ for Help Center with English locale
	Then FAQ for Help Center is provided and translated to English locale

