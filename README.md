# ProcessingApp
[![Build Status](https://dev.azure.com/200395896/ProcessingApp/_apis/build/status/ProcessingApp-dev-as%20-%20CI?branchName=master)](https://dev.azure.com/200395896/ProcessingApp/_build/latest?definitionId=6&branchName=master)

Basically, is web app that allows tenants who wants to rent a house or apartment to send only one application and apply for multiple places. As oppose of the current system where you must send and application for each apartment which is inefficient and time consuming.

Landlord part: We think we will not be able to accomplish also a landlord side. In that case, we will make a predefined property. However, we still do not know how it will go and how many people will work on it. In the best-case scenario, we will make a landlord part as well. 

I see it like that: A landlord will create a property. We will get inspiration from our previous classes but instead of “Add to Cart” button, we will name it as “Apply”.

Expected output: A tenant will complete a simple form and save it. Then, in a property listing will press submit and his form will be transferred to hidden section (OAuth 2.0), and only logged landlord will be able to see the application data. Probably, we will make a functionality to export application as a pdf file.

Technologies: OAuth 2.0, ASP.NET MVC, Material Design UI, Ajax.
Ops: Azure?
Database: mssql.

