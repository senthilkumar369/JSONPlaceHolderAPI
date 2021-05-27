Feature: test JSONPlaceholder Get methods
	Simple Test to read resources/records using Get Method

@runonlygetMethod @valid
Scenario Outline: Read resources or records by Ids
	Given a valid ID as <id> for Get Method request
	When a request is sent 
	Then it returns response as <resp_code>
	Examples: 
	| id  | resp_code |
	| 1   | 200       |
	| 5   | 200       |
	| 80  | 200       |
	| 100 | 200       |


@runonlygetMethod @valid
Scenario Outline: Read all the resources or records 
	Given a valid Get Method request
	When it is success <resp_code>
	Then it returns all the resources 
	Examples:
	| resp_code |
	|   200     |


	@runonlygetMethod @invalid
Scenario Outline: Read resources or records by invalid Ids
	Given a invalid ID as <invalid_id> for Get Method request
	When a request is sent with Invalid id
	Then it returns response as <resp_code>
	Examples: 
	 | invalid_id | resp_code |
	 | idontexist | 404     |
	
	