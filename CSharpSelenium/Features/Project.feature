Feature: CSharp Selenium Project

@GmailLogIn
Scenario: Log in gmail with valid username and password
	Given I am on gmail home page
	When I input valid username and password
			| username					| password		|

	Then I should see gmail inbox
