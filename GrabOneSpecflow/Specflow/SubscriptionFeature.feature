Feature: SubscriptionFeature


@mytag
Scenario: GrabOne application Subscription functionality validation
	Given I have logged into the application with my credentials
	When  I select Some of the options to subscribe and click on save button
	Then  I should see the message "Your changes have been saved" on screen
