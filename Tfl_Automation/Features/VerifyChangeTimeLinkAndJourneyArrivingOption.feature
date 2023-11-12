Feature: VerifyChangeTimeLinkAndJourneyArrivingOption 

Scenario: Verify change time link and “Arriving” option in journey planner
	Given I access the TFL website.
	When I enter a valid location as 'Hammersmith' in From Input field
	And I enter a valid location as 'Osterley' in To Input field
	And I click on change time link 
	Then I verify 'Arriving' option displays
	And I click on Plan  my Journey button
	Then I should verify the valid journey results in Journey results page
	
