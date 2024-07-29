Feature: Boards

@Test
Scenario Outline: Create a TestBoard on Trello
  Given User is on the Trello Dashboard
  When User creates a new board with "<BoardTitle>"
  Then User should see that the board "<BoardTitle>" is successfully created

Examples:
  | BoardTitle             |
  | Trello Testing for au  |

Scenario Outline: Initial User invites another user to a recently created board in Trello
  Given User redirects to existing board with title "<BoardTitle>"
  When User invites "<AnotherUser>" to the board
  Then "<AnotherUser>" Name is added on the board

Examples:
  | BoardTitle             | AnotherUser     |
  | Trello Testing for au  |  account        |

  @SecondUserCase
Scenario Outline: Invited user views board invitation request sent by Initial user
  When "<InvitedUser>" checks their notifications
  Then Request should be present from "<InitialUser>"

  Examples:
  | InvitedUser            | InitialUser  |
  | Trello Testing for au  | Sheza        |


Scenario Outline: User deletes a Trello board
  When User chooses to delete the board "<BoardTitle>"
  Then Board should be removed with "<Message>"

Examples:
  | BoardTitle             | Message           |
  | Trello Testing for au  | Board Deleted     |