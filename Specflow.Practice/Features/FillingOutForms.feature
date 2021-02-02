Feature: Validate, fill and test web page forms
	
	
@UltimateQAOpen
Scenario Outline: Fill and test web page form without Captcha
	Given correct URL https://ultimateqa.com/filling-out-forms/ is entered in the browser
	When name <name> in the Name field and message <message> in the Message field are filled in form Form1
		And Submit Button1 button is clicked
	Then a text <text> message is shown on the page

Examples:
|  name  |	message	|	text					 |
|Test	 |Test		|	Success					 |
|		 |			|	Failure					 |
|" "	 |" "		|	RequiredFieldsNotFilled  |
|Test	 |" "		|	RequiredField2NotFilled	 |
|" "	 |Test		|	RequiredField1NotFilled	 |
|Test	 |			|	MessageWarning			 |
|		 |Test		|	NameWarning				 |



@UltimateQAOpen
Scenario Outline: Fill and test web page form with Captcha
	Given correct URL https://ultimateqa.com/filling-out-forms/ is entered in the browser
	When name <name> in the Name field and message <message> in the Message field are filled in form Form2
		And captcha sum <captcha> is filled in the Captcha field
		And Submit Button2 button is clicked
	Then a text <text> message is shown on the page above the form with Captcha

Examples:
|  name  |	message	|	captcha		|	text							|
|Test	 |Test		|	correct		|	Success							|
|Test	 |Test		|	wrong		|	WrongNumberInCaptcha			|
|Test	 |Test		|	empty		|	CapthcaWarning					|
|		 |			|	correct		|	WarningNameMessage				|
|		 |			|	wrong		|	WarningNameMessageErrorCaptcha	|
|		 |			|	empty		|	WarningAll						|
|" "	 |" "		|	correct		|	RequiredFieldsNotFilled			|
|" "	 |" "		|	wrong		|	WrongNumberInCaptcha			|
|" "	 |" "		|	empty		|	CapthcaWarning					|
|		 |Test		|	correct		|	NameWarning						|
|Test	 |			|	correct		|	MessageWarning					|
|		 |Test		|	wrong		|	NameWarningErrorCaptcha			|
|Test	 |			|	wrong		|	MessageWarningErrorCaptcha		|
|		 |Test		|	empty		|	WarningNameCaptcha				|
|Test	 |			|	empty		|	WarningMessageCaptcha			|
|Test	 |" "		|	correct		|	RequiredFieldNotFilled			|
|" "	 |Test		|	correct		|	RequiredFieldNotFilled			|
|Test	 |" "		|	wrong		|	WrongNumberInCaptcha			|
|" "	 |Test		|	wrong		|	WrongNumberInCaptcha			|
|Test	 |" "		|	empty		|	CapthcaWarning					|
|" "	 |Test		|	empty		|	CapthcaWarning					|



@UltimateQAOpen
Scenario Outline: Fill and test web page form with Email and Captcha
	Given correct URL https://ultimateqa.com/complicated-page/ is entered in the browser
	When the page is scrolled down to the form
		And name <name> is filled in the Name field
		And message <message> is filled in the Message field
		And email <email> is filled in the Email field
		And captcha sum <captcha> is filled in the Captcha field in the form with Email
		And Submit Button3 button is clicked
	Then a text <text> message is shown on the page above the form with Email and Captcha

Examples:
|  name	|	message	|	email			|	captcha		|	text												|
|Test	|Test		|TestEmail@email.com|	correct		|	Success												|
|Test	|Test		|TestEmail@email.com|	wrong		|	WrongNumberInCaptcha								|
|Test	|Test		|TestEmail@email.com|	empty		|	CaptchaWarning										|
|Test	|Test		|TestEmail@			|	correct		|	InvalidEmail										|
|Test	|Test		|TestEmail			|	wrong		|	InvalidEmailWrongNumberInCaptcha					|
|Test	|Test		|TestEmail@			|	empty		|	InvalidEmailCaptchaWarning							|
|Test	|Test		|					|	correct		|	EmailWarning										|
|Test	|Test		|					|	wrong		|	EmailWarningWrongNumberInCaptcha					|
|Test	|Test		|					|	empty		|	EmailCaptchaWarning									|
|Test	|Test		|" "				|	correct		|	RequiredFieldNotFilled								|
|Test	|Test		|" "				|	wrong		|	WrongNumberInCaptcha								|
|Test	|Test		|" "				|	empty		|	CaptchaWarning										|
|		|			|					|	correct		|	NameEmailMessageWarning								|
|		|			|					|	wrong		|	NameEmailMessageWarningWrongNumberInCaptcha			|
|		|			|					|	empty		|	NameEmailMessageCaptchaWarning						|
|		|			|TestEmail@email.com|	correct		|	NameMessageWarning									|
|		|			|TestEmail@email.com|	wrong		|	NameMessageWarningWrongNumberInCaptcha				|
|		|			|TestEmail@email.com|	empty		|	NameMessageCaptchaWarning							|
|Test	|			|TestEmail@email.com|	correct		|	MessageWarning										|
|Test	|			|TestEmail@email.com|	wrong		|	MessageWarningWrongNumberInCaptcha					|
|Test	|			|TestEmail@email.com|	empty		|	MessageCaptchaWarning								|
|		|Test		|TestEmail@email.com|	correct		|	NameWarning											|
|		|Test		|TestEmail@email.com|	wrong		|	NameWarningWrongNumberInCaptcha						|
|		|Test		|TestEmail@email.com|	empty		|	NameCaptchaWarning									|
|Test	|			|					|	correct		|	EmailMessageWarning									|
|Test	|			|					|	wrong		|	EmailMessageWarningWrongNumberInCaptcha				|
|Test	|			|					|	empty		|	EmailMessageCaptchaWarning							|
|		|Test		|					|	correct		|	NameEmailWarning									|
|		|Test		|					|	wrong		|	NameEmailWarningWrongNumberInCaptcha				|
|		|Test		|					|	empty		|	NameEmailCaptchaWarning								|
|		|Test		|123				|	correct		|	InvalidEmailNameWarning								|
|		|Test		|123				|	wrong		|	InvalidEmailNameWarningWrongNumberInCaptcha			|
|		|Test		|123				|	empty		|	InvalidEmailNameCaptchaWarning						|
|Test	|			|123				|	correct		|	InvalidEmailMessageWarning							|
|Test	|			|123				|	wrong		|	InvalidEmailMessageWarningWrongNumberInCaptcha		|
|Test	|			|123				|	empty		|	InvalidEmailMessageCaptchaWarning					|
|" "	|" "		|" "				|	correct		|	RequiredFields3NotFilled							|
|" "	|" "		|" "				|	wrong		|	WrongNumberInCaptcha								|
|" "	|" "		|" "				|	empty		|	CaptchaWarning										|
|" "	|" "		|TestEmail@email.com|	correct		|	RequiredFields2NotFilled							|
|" "	|" "		|TestEmail@email.com|	wrong		|	WrongNumberInCaptcha								|
|" "	|" "		|TestEmail@email.com|	empty		|	CaptchaWarning										|
|" "	|" "		|TestEmail@			|	correct		|	InvalidEmail										|