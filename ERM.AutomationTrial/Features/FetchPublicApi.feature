Feature: FetchPublicApi
	In order to prove that we can write specflow for REST API
	As an automation test
	I want to consume the REST Api and run some of the scenarios defined below

@apitest
Scenario: Find a particular user and title
Given The rest endpoint in the config file
When I have loaded REST Api data
And I check the title of the posts
| id	| title																				|
| 1		| sunt aut facere repellat provident occaecati excepturi optio reprehenderit		|
| 98	| laboriosam dolor voluptates														|
| 23	| maxime id vitae nihil numquam														|
| 100	| at nam consequatur ea labore ea harum												|
| 73	| consequuntur deleniti eos quia temporibus ab aliquid at							|
| 2		| qui est esse																		|

@apitest
Scenario: Find count of records for each users
Given The rest endpoint in the config file
When I have loaded REST Api data
And I check the number of records created for each users
| userid| count	|
| 1		| 10	|
| 2		| 10	|
| 3		| 10	|
| 4		| 10	|
| 5		| 10	|

@apitest
Scenario: There is no missing data in the fields
Given The rest endpoint in the config file
When I have loaded REST Api data
Then There are no blank values in each fields 


@apitest
Scenario: There is no duplicate title
Given The rest endpoint in the config file
When I have loaded REST Api data
Then There are no duplicate titles
