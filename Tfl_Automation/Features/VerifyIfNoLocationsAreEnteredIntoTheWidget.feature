Feature: VerifyIfNoLocationsAreEnteredIntoTheWidget

Scenario: Verify when no locations are entered into From and To locations fields
	Given I access the TFL website.
	When I click on Plan my Journey button without entering From and To location field
	Then I should see an error message "The From field is required." below From field
	And I should see an error message "The To field is required." below To field
