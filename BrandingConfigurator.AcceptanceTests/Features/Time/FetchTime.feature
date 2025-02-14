Feature: Fetch server time

Scenario: Fetch server time
	When I requests for server time
	Then server time is provided