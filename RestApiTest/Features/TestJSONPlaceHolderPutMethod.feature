Feature: TestJSONPlaceHolderPutMethod
	Simple test to update the resoure using put method

@puttest
Scenario Outline: Send put Request with valid data
	Given a post request with user id as <userid> id as <id> title as "<testtitle>" and body as "<testbody>"
	When put request sent 
	Then it return the status code as <Expected_resp_code>
Examples:
| userid | id  | testtitle | testbody | Expected_resp_code |
| 40    | 41 | testtitle   | testbody  | 200                |
