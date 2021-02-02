Feature: Validate, fill and test Login forms 
	
	
@UltimateQAOpen
Scenario Outline: Try to login with unregistered user (Complicated page Login form)
	Given correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	When the page is scrolled down to the form
		And Username <username> is entered
		And Password <password> is entered
		And Login button is clicked
	Then the user is redirected to https://ultimateqa.com/backoffice
		And a message for "<message>" is shown
		And a form "Try again" is shown


Examples:
|	username	|	password	|	message				|
|Test			|	Test		|	unsuccessfull login	|
|Test			|				|	password missing	|
|				|	Test		|	username missing	|

@UltimateQAOpen
Scenario: Forgot password link on the login form is clicked (Complicated page Login form)
	Given correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	When the page is scrolled down to the form
		And Forgot password link is clicked
	Then the user is redirected to https://ultimateqa.com/backoffice?action=lostpassword
		And a message for "forgotten password" is shown
		And a form "Username or Email Address" is shown


@UltimateQAOpen
Scenario Outline: Try to login with empty username and password (Complicated page Login form)
	Given correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	When the page is scrolled down to the form
		And Username <username> is entered
		And Password <password> is entered
		And Login button is clicked
	Then the user is redirected to https://ultimateqa.com/backoffice
		And a message for "empty fields" is shown
		And a form "Try again" is shown


Examples:
|	username	|	password	|
|				|				|
|" "			|	" "			|