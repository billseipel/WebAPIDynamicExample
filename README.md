# WebAPIDynamicExample
A .NET Core Swagger API which consumes the NYC Comptroller Checkbook, dynamically converts the XML result to a modeled JSON result.

(Please use your own subscription, which is free. I'll leave mine for now)
NYC Comptroller Checkbook API address:
https://api-portal.nyc.gov/docs/services/comptroller-check-book/operations/comptroller-api

NYC Checkbook Spending documentation:
https://www.checkbooknyc.com/spending-api

The single (to start with) method takes a year as the single parameter and returns transactions, sorted by most expensive to least.

Note: The only available data seems to be from about 2010 onward. So queries for '1976' won't return data.

