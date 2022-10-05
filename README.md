# BuggyMaui

### Author: Stanley Munson
### Date: 2022-Oct-4

## Description

This application does **not** work correctly. However, it should still compile and run from the debugger. Upon running, the flow of the app is pretty straightforward and is as follows:

- MainPage loads
    - From this page, two entries are used to search for a person by lastname, firstname, or both. Enter a value and hit search
    - People values are hard-coded in-app and **do not** update, despite what the app may tell you (this is just a demo of the issue)
- ResultsPage loads
    - People list is generated and the entries from the MainPage are passed to the viewmodel
    - The viewmodel queries for people whose names match what was passed from the MainPage
    - A CollectionViews data is bound from the results of the query
    - The CollectionView can be selected from. Selecting a person will load the next page
- ReviewPage loads
    - The selected person is loaded into the viewmodel for the review page
    - The review page consists mostly of entry controls that would update a person (these do *nothing*)
    - Once changes are complete, the submit button can be clicked which will load the Success page
- SuccessPage loads
    - A message is passed to the page and displayed to the user. Below that is a button
    - The button *ideally* would take the user back to the MainPage, but is the real broken thing here
    
See this [Stack Overflow post](https://stackoverflow.com/q/73950551/10425899) to better understand the issue with the Success page's button

## Dummy data

To get the UI to display people on the first search, pass in one of the following values for the last name:

- smith
- Sanchez
