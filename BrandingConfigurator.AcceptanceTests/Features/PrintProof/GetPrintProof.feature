Feature: Get print proof

    Scenario: Get print proof
        Given I have created a new design
        When I request for print proof for design
        Then The print proof is provided
        And Print proof file is provided when requested

    Scenario: Get print proof for not existing design
        Given I request for print proof for not existing design       
        Then Print proof file is not provided