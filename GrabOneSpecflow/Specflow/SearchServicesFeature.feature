Feature: SearchDentalServices 
	

@mytag
Scenario: Search for Dental services on Grabone page
	Given User have logged into the GrabOne application 
	When User enter "Dental Services" keyword on search box and click on search button
	Then User Search results for Dental Services should be displayed
