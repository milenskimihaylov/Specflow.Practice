Feature: Click on buttons
	
	
@UltimateQAOpen
Scenario Outline: Click on the web page buttons
	When correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	Then <number> button(s) on the page are clicked

Examples:
|  number  | 
|4		   |
|1		   |


@UltimateQAOpen
Scenario: Verify that clicking on the "Click Me" button opens a new page
	Given correct URL https://ultimateqa.com/simple-html-elements-for-automation/ is entered in the browser
	When the page is scrolled down to Simple Controls section
		And Click Me button on the page is clicked
	Then the user is redirected to https://ultimateqa.com/button-success
		And correct header "Button success" is present on the page
		And image "Button success image" is loaded on the page