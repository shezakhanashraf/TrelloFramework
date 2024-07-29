@auFeature
Feature: auTesting

   Scenario: To verify au call functionality for Board , List and Card
    Given New board is created using an API call
	When Board Title is retrieved using another API call
	Then List named "QA Task" is created for the board using an API call
	Then Card named "Test case creation" is added to the list through an API call
	Then Another member "<MemberName>" is invited to the board through an their "<EmailAddress>"
	Then the notification is received by another member
	Then Board is deleted via an API call

	Examples:
  | MemberName     | EmailAddress						     |
  | xyz            | xyz@gmail.com                           |