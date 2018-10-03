Feature: Login
In order to launch new product on my ecommerce website 
As a user 
I want to be able to login to nop-commerce ecommerce platform

@login @invalidusernameentered
Scenario: Invalid Username entered
	Given I navigate to nop-commerce web site login page
	And I enter username as 'AUT_29110334'
	And I enter password as 'Test123'
	When I press Login button
	Then I should get a message as 'Your login attempt was not successful. Please try again.'

@login @invalidpasswordentered
Scenario: Invalid Password entered
	Given I navigate to nop-commerce web site login page
	And I enter username as 'AUT_291103'
	And I enter password as 'Test1234'
	When I press Login button
	Then I should get a message as 'Your login attempt was not successful. Please try again.'

@login @validusernameandpasswordentere
Scenario: Correct username and password entered
	Given I navigate to nop-commerce web site login page
	And I enter username as 'AUT_291103'
	And I enter password as 'Test123'
	When I press Login button after valid details are entered
	Then I should be able to goto my account dashboard
