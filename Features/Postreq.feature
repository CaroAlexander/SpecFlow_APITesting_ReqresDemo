Feature: post request

A short summary of the feature

@Reqres.in
Scenario: post request testing to Reqres.in
	Given the user sends a post request with url as "https://reqres.in/api/users"
	Then user should get a success response
	 
@reqbin.com
Scenario: post request testing to reqbin.com
	Given the user sends a post request to reqbin with url as "https://reqbin.com/echo/post/json"
	Then users should get a success response