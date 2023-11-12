Feature: VerifyListOfRecentlyPlannedJourneysInRecentTab

Scenario: Verify that a list of recently planned journeys is displayed in Recents Tab
	Given I access the TFL website.
	When I enter a valid location as 'Hammersmith' in From Input field
	And I enter a valid location as 'Osterley' in To Input field
	And I click on Plan my Journey button
	Then I should see the valid journey results in Journey results page
	When I click Plan a journey tab link Journey results page
	And I enter a valid location as 'South Harrow Underground Station' in From Input field
	And I enter a valid location as 'Euston Square Underground Station' in To Input field
	And I click on Plan my Journey button
	Then I should see the valid journey results in Journey results page
	When I click Plan a journey tab link Journey results page
	And I click on Recents Tab in Plan a journey Page
	Then I see recently planned journey results
