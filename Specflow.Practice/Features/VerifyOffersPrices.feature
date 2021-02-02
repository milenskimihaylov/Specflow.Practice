Feature: Verify UltimateQA offers prices
	
	
@UltimateQAOpen
Scenario Outline: Open UltimateQA offers web page and verify the prices
	When correct URL https://ultimateqa.com/automation/fake-pricing-page/ is entered in the browser
	Then verify that the offers prices are correct <price1> <price2> <price3>

Examples:
| price1  | price2   | price3    |
|$0/month |$80/month |$900/month |