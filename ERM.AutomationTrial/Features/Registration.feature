Feature: New User Registration
In order to setup a new e-commerce site
As a user 
I want to be able to Register to nop-commerce e-commerce platform

@registration @nodetailsentered
Scenario: Register by entering no details
	Given I navigate to nop-commerce web site registration page
	When I press Register button 
	Then System should throw validation error message as 'First name is required'
	And System should throw validation error message as 'Last name is required'
	And System should throw validation error message as 'E-Mail is required'
	And System should throw validation error message as 'Username is required'
	And System should throw validation error message as 'Password is required'
	And System should throw validation error message as 'Confirm password is required'


@registration @onlyfirstname
Scenario: Register by entering Firstname only
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	When I press Register button 
	Then System should throw validation error message as 'Last name is required'
	And System should throw validation error message as 'E-Mail is required'
	And System should throw validation error message as 'Username is required'
	And System should throw validation error message as 'Password is required'
	And System should throw validation error message as 'Confirm password is required'

@registration @onlyfirstnameandlastname
Scenario: Register by entering Firstname and LastName only
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	When I press Register button 
	Then System should throw validation error message as 'E-Mail is required'
	And System should throw validation error message as 'Username is required'
	And System should throw validation error message as 'Password is required'
	And System should throw validation error message as 'Confirm password is required'

@registration @justthebasics
Scenario: Register by entering Firstname, LastName and Email only
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	And I enter email as 'AUT_{0:ddMMyyhhmm}@test.com'
	When I press Register button 
	Then System should throw validation error message as 'Username is required'
	And System should throw validation error message as 'Password is required'
	And System should throw validation error message as 'Confirm password is required'

@registration @useexistingusername
Scenario: Register by entering existing username
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	And I enter email as 'AUT_{0:ddMMyyhhmmss}@test.com'
	And I enter username as 'AUT_291103'
	And I enter the password as 'Test123'
	And I re-enter the password as 'Test123'
	When I press Register button 
	Then System should throw validation error message as 'Please enter a different user name.'

@registration @invalidemail
Scenario: Register by entering invalid email address
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	And I enter email as 'AUT_{0:ddMMyyhhmmss}'
	And I enter username as 'AUT_{0:ddMMyyhhmmss}'
	And I enter the password as 'Test123'
	And I re-enter the password as 'Test123'
	When I press Register button 
	Then System should throw validation error message as 'Please enter a valid e-mail address.'

@registration @invalidpasswords
Scenario: Register by entering invalid password
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	And I enter email as 'AUT_{0:ddMMyyhhmmss}@test.com'
	And I enter username as 'AUT_{0:ddMMyyhhmmss}'
	And I enter the password as 'Test123'
	And I re-enter the password as 'Test1235'
	When I press Register button 
	Then System should throw validation error message as 'Entered passwords do not match'

@registration @successfulregistration
Scenario: Register by entering valid details
	Given I navigate to nop-commerce web site registration page
	And I enter first name as 'First Name'
	And I enter last name as 'Last Name'
	And I enter email as 'AUT_{0:ddMMyyhhmmss}@test.com'
	And I enter username as 'AUT_{0:ddMMyyhhmmss}'
	And I enter the password as 'Test123'
	And I re-enter the password as 'Test123'
	When I press Register button 
	Then The registration should be successfull 
	And A message page should be displayed as 'Your registration completed'
	And I should be able to access account dashboard