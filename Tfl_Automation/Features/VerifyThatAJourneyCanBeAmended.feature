Feature: VerifyThatAJourneyCanBeAmended

Scenario: Verify that a journey can be amended by edit button
	Given I access the TFL website.
	When I enter a valid location as 'Hammersmith' in From Input field
	And I enter a valid location as 'Osterley' in To Input field
	And I click on Plan my Journey button
	Then I should see the valid journey results in Journey results page
	When I click on Edit journey link in journey results page
	And I Edit the Journey details
	And I update the changes by clicking Update Journey button
	Then I see updated Journey results



