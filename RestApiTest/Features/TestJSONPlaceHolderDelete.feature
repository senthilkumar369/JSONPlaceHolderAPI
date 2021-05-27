Feature: TestJSONPlaceHolderDelete
	Simple Test for delete API Method

@delete
Scenario Outline: Delete resources or records by Ids
	Given a valid ID as <id> for Delete Method request
	When a request is sent for delete
	Then returns success with response code <resp_code>
	Examples: 
	| id  | resp_code |
	| 1   | 200       |