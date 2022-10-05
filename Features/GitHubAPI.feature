Feature: GitHub API
	
	As a github user
	I want to be able to call the Github API to find out more information on github projects

@Smoke
Scenario: GET User details from Github
	Given the user has a Github account
	When the user executes a GET User call
	Then the user receives a response with the correct github project details


@Smoke
Scenario: POST a new Repository in Github
	Given the user has a Github account
	When the user Creates a new GitHub Repository
	Then the github repository is created in the system


@Smoke
Scenario: POST a new Repository in Github Dynamic Expando Object Example
	Given the user has a Github account
	When the user Creates a new GitHub Repository
	Then the github repository is created successfully