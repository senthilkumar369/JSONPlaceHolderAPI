Feature: test JSONPlaceHolder Post method
	Simple Test for POST method 

@posttest
Scenario Outline: Send Post Request with valid data
	Given a post request with user id as <userid> id as <id> title as "<testtitle>" and body as "<testbody>"
	When post request sent 
	Then it return the status code as <Expected_resp_code>
Examples:
| userid | id  | testtitle | testbody | Expected_resp_code |
| 101    | 101 | testtitle   | testbody  | 201                |
| 102    | 102 | testtitle 1  | testbody 1 | 201                |
