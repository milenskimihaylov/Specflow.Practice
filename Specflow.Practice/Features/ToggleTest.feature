Feature: Toggle Test
	
	
@UltimateQAOpen
Scenario: Click on the toggle to expand it and verify its inner text and then click on it again to collapse it
	Given correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	When the page is scrolled down to the toggle
		And the toggle is clicked
	Then the toggle is expanded and its inner text is shown
	When the toggle is clicked
	Then the toggle is collapsed and its inner text is hidden

