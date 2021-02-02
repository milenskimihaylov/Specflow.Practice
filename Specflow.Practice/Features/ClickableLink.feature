Feature: Verify the link is clickable


@UltimateQAOpen
Scenario: Verify the link is clickable and opens new page
	Given correct URL https://ultimateqa.com/simple-html-elements-for-automation/ is entered in the browser
	When the page is scrolled down to Simple Controls section
	Then Verify the link is clickable
		And the link is clicked
		And the user is redirected to https://ultimateqa.com/link-success
		And correct header "Link success" is present on the page
		And image "Link success image" is loaded on the page