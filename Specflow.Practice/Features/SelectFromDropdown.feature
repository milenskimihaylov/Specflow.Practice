Feature: Select elements from dropdown


@UltimateQAOpen
Scenario Outline: Select elements from dropdown and validate that the right element is selected
	Given correct URL https://ultimateqa.com/simple-html-elements-for-automation/ is entered in the browser
	When the page is scrolled down to the Dropdown
		And an option <option> from the dropdown is selected
	Then Verify the correct option <option> is selected


Examples:
|	option	|
|	volvo	|
|	audi	|
|	opel	|
|	saab	|
		