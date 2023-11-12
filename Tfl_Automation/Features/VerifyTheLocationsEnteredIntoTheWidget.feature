Feature: VerifyTheEnteredLocations

@TFL-ValidLocation
Scenario: Verify the valid location entered in the Journey Planner screen
	Given I access the TFL website.
	When I enter a valid location as 'Hammersmith' in From Input field
	And I enter a valid location as 'Osterley' in To Input field
	And I click on Plan my Journey button
	Then I should verify the valid journey results in Journey results page

@TFL-InValidLocation
Scenario: Verify the invalid location entered in the Journey Planner screen
	Given I access the TFL website.
	When I enter an invalid location as '111' in From Input field
	And I enter an invalid location as '222' in To Input field
	And I click on Plan my Journey button
	Then I should see a result not found message