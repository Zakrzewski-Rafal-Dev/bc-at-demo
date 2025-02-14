Feature: Get design preview

    Scenario: Get design preview
        Given I have created a new design
        When I request for preview for design
        Then The design preview is provided
        And Design preview file is provided when requested

    Scenario: Get design preview for not existing design
        Given I request for preview for not existing design       
        Then Design preview file is not provided