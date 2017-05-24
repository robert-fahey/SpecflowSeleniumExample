Feature: Example

@Home
Scenario: Search for a product type
	Given I enter the search term shorts
	When I initiate the search
	Then the search term title displayed is Shorts