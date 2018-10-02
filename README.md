# Overview #
The purpose of this application is to write some automated UI and REST Api testing to do the following,
- Verify login scenarios for nop-commerce site
- Register a new account in nop-commerce site
- Makes a call to RestAPI, deserialize the JSON data to Domain entity and then do some tests

## Software Requirements
### Supported Version
#### Supported Operating System
Windows 10
#### Supported Visual studio 
Microsoft Visual Studio 2017
#### Others
-Selenium: Web Browser automation
-Specflow: BDD Tool
-Restsharp: Rest API Client
-Nunit: Test runner
-Newtonsoft.JSON: For deserialization REST data to domain entity
-log4net: For generating logs
-Pickle: For live report generation of

## Coverage #
### Login
- Successfull login
- Login failure with invalid user name/password

### Registration
- Successfull registration
- Regisration with missing data
- Registration without any data

### REST API
- Basic checks
- Missing field values
- Duplicates
- Record counts

## Setup #
#### Compile Solution:
1. Dowload the solution 
2. Open in VS2017 as it was developed using VS2017
3. Once solution is opened you just need to build the solution to restore the packages. For the specific browser drivers, you can add them using NUGET. The default driver is Chrome and the NUGET package is already installed on the Sample project.   
4. Once compiled you should be able to run the test by following the instructions from "How to run the test" section

#### Application configuration
Below are the list of keys that defines appropriate keys/values to run the test
- BrowserType: Specify the browser type to be used like Chrome and FireFox
- NopCommerceUrl: Url for nop-commerce site
- RestEndpoint: Url for the REST end point https://jsonplaceholder.typicode.com/posts

#### How to run the test
##### From VS2017 Test Explorer
- Open Test explorer in VS2017 from Test -> Windows -> Test Explorer
- In the test explorer select the node ERM.AutomationTrial.Features, right click -> Run Selected Tests
##### From the command prompt
- Open command prompt
- Ensure that nunit console runner and picke is installed
- Goto the folder "ERM.AutomationTrial" from the downloaded source
- Run the "RunTest.bat" and wait until the tests are completed. Test results are stored in the file "TestResult.xml"
- Once completed, pickle will generate document in dynamic html format output and stores the result documents in "Documentation" folder

#### Browser Driver Download and install instructions
If you want to download the drivers manually you can go to the specific driver download links and put them in the bin folder of your project. 

#### Chrome:
Download the Chrome Web driver from the below link
[Download chrome driver](https://sites.google.com/a/chromium.org/chromedriver/downloads)
#### Internet Explorer:
Download the IE Web driver from the below link
[Download IE driver](http://selenium-release.storage.googleapis.com/3.4/IEDriverServer_x64_3.4.0.zip) 
#### FireFox:
The Firefox web driver can be installed through Nuget package manager.
- In Visual studio ,Go to Tools -> NuGet Package Manager -> Manage Nuget Packages for the solution
***FileName*** : Selenium.WebDriver.GeckoDriver.Win64
#### Edge:
Click on the below link to download Edge driver
[Download Edge driver](https://www.microsoft.com/en-us/download/details.aspx?id=48212)


