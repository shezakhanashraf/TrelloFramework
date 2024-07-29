# TrelloFramework

Overview
The repository comprises of an automation testing framework built using Specflow and C#. It aims to automate the functionalities of Trello specifically for UI and API testing, providing CRUD operations alongside UI verification to ensure comprehensive test coverage.

Key Aspects:
• Generic Functions: Modular functions for each action, allowing easy addition of new functionalities.
• Dynamic Xpath: Supports dynamic Xpath for flexible identification of elements.
• Page Object Model: Utilizes the Page Object Model pattern for maintainability and scalability.
• API Endpoint Testing: Verifies backend operations, including functionality, payload, and endpoints.
• Allure Reporting: Generates graphical reports for improved visualization of test execution.
• Jenkins Integration: Supports CI/CD pipelines with both headless and master-slave architectures.

Prerequisites:
Before running the tests, ensure the following prerequisites are met:
• Visual Studio: Install Visual Studio on your machine. If not installed, download it from [https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/).
• .NET Framework: Ensure the appropriate .NET Framework version is installed.
• Trello API Key and Token: Obtain a Trello API key and token to authenticate API requests. Follow the instructions [here](https://developer.atlassian.com/cloud/trello/guides/rest-api/api-introduction/).
• Jenkins: For CI/CD pipelines, Jenkins is used. Ensure it is installed on your system and the services are running. Follow the steps provided below for installation.

Jenkins Installation:

Headless Mode:
1. Open [https://www.jenkins.io/download/](https://www.jenkins.io/download/).
2. Download the windows file and install Jenkins on your system.
3. Enter the administrator password and follow the installation instructions.
4. After installation, open the provided link and access the initialAdminPassword file.
5. Install suggested plugins and create the first admin user.
6. Configure Jenkins by setting up the necessary plugins and tools.
7. Trigger your build in Jenkins.

Master-Slave Architecture:
1. Go to Manage Jenkins and select Nodes.
2. Add a new node with a unique name and select "Permanent Agent."
3. Configure the node with the required settings, including the custom work directory path.
4. Launch the agent by connecting it to the controller using the provided commands.
5. Download WinSW-x64.exe and paste it into your Jenkins folder.
6. Configure the Jenkins-agent.xml file with your details and install the agent as a service.
7. Start the Jenkins service and trigger your builds.

Allure:
Make sure you have allure installed on your system. If not refer to the following documentation [https://allurereport.org/docs/specflow/](https://allurereport.org/docs/specflow/). Once downloaded you need to execute your cases then a folder must be created in your project repository. For instance: “C:\Users\source\repos\TrelloProject\TrelloProject\bin\Debug\net6.0\allure-results”. Now execute the command “allure serve allure-results”

Installation:
1. Clone the repository to your local machine using the following command:
git clone https://github.com/your-username/trello-testing-framework.git
2. Open the solution file (TrelloTestingFramework.sln) in Visual Studio.
3. Install the required NuGet packages listed below:
   - DotNetSeleniumExtras.PageObjects (3.11.0)
   - FluentAssertions (6.2.0)
   - JSON (1.0.1)
   - JsonPath (1.0.6)
   - Microsoft.Extensions.Configuration (8.0.0)
   - Microsoft.NET.Test.Sdk (17.0.0)
   - NUnit (3.13.2)
   - NUnit3TestAdapter (4.1.0)
   - Remote.Linq.Newtonsoft.Json (7.1.0)
   - RestClient (3.1024.23771)
   - RestSharp (106.15.0)
   - Selenium.Support (4.20.0)
   - Selenium.WebDriver (4.20.0)
   - Selenium.WebDriver.ChromeDriver (124.0.6367)
   - SpecFlow.Allure (3.5.0.73)
   - SpecFlow.NUnit (3.9.40)
   - System.IO (4.3.0)
   - TrelloDotNet (1.10.0)
4. Update the appsettings.json file with your Trello API key and token.

Usage
Running API and UI Tests
1. Navigate to the Test folder.
2. Go to the Test Explorer.
3. Run the desired tests

Running Jenkins Tests on Headless mode
1. Open [http://localhost:8080/](http://localhost:8080/).
2. Go to Build-In-Node.
3. Select your project.
4. Trigger the build.

Running Jenkins Tests on Headless mode
1. Go to Dashboard.
2. Go to your project.
3. Click on Configuration.
4. Select “Restrict where this project can be run”.
5. Add a Label Expression.
6. Click Save.
7. Trigger the build.
