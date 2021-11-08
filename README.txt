#Budget Web App
The Budget Web App ASP.NET application is a more diverse version of the Budget App Planner.
It makes use of a investement calculator and web application frameworks to allow other Linux users to get access to the Budget 
planner.

##Getting Sarted
The instructions listed below will guide you on how to install and run the appliation

##What things you need to install the software and how to install them:

Any of the latest MS Visual Studio e.g. v.1.6.2019 
A device with dual core processing and at least 4GB's of RAM e.g. Acer Aspire
MsSQL Server e.g. v18.4
Adobe Acrobat Reader

###Installing

-Open MsSQL Server and create a new database by the name 'Personal_Planner_Database'.
-Open the SQlScript 'Peronal_Planner' from the file and create the tables int MSSQL Server.
-Open Ms Viual Studio.
-Click on the 'Open project or solution' option and open the BudgetWebApp project.
-Once open, click on the Server Explorer and select the option to connect to a new database.
-When the window pops up, add your server name from you MsSQL Server and select the 'Personal_Planner_Database'.
-Click on connect.
-To test the appliaction click on run.
-When the Default.aspx pops up, click on the Register button.
-To do the rest of the steps, refer to the user manual which can be found in the file. 
when done registering, you can click on the toolbar options to add savings or view other balances.
 follow through by viewing your balances.
-Click on the logout option on the toolbar to automaitally log you out of the web app.

### Break down into end to end tests

To test this program:

When on the create user page, enter a name and then remove 
the name to test if it will show an aestrics (*) in red.
Click on next for any of the registering pages to check if it will let you move onto
the next page without completing the one before.
Seperately calculate the expense and income details to confirm that the income and expense details input 
are accurate.
enter the wrong log in details to check if the og in allows wrong input.

## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

##Authors
**Koketso Baruti**

##Acknowledgements

* Youtube tutors
* Mr. Rudolph
* StackOverflow