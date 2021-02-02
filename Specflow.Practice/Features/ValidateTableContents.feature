Feature: Validate table contents


@UltimateQAOpen
Scenario: Validate the contents of the table
	Given correct URL https://ultimateqa.com/simple-html-elements-for-automation/ is entered in the browser
	When the page is scrolled down to the table
	Then Verify the table contents
		