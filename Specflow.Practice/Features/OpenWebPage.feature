Feature: Open UltimateQA web page
	
	
@UltimateQAOpen
Scenario: Open a web page
	When correct URL https://ultimateqa.com/fake-landing-page/ is entered in the browser
	Then the desired web page is opened correctly
