# Quote Calculator
>For the Money Me technical exam, this project was created. Between October 31 and November 1, 2022, Jomiel Enriquez is the creator of this. Even though this project still needs a lot of work, the current version is functional. By utilizing many forms of technology, this project was constructed in just two days. The application is currently deployed to [SOMEE](http://www.quotecalculator.somee.com/).

## :technologist: Technologies
<p float="left">
  <img src="https://venturebeat.com/wp-content/uploads/2015/10/Microsoft_.NET_Logo.svg_.png?w=1200&strip=all" width="100" />
  <img src="https://www.freepnglogos.com/uploads/html5-logo-png/html5-logo-devextreme-multi-purpose-controls-html-javascript-3.png" width="300" /> 
  <img src="https://user-images.githubusercontent.com/77730490/199245570-14b109d0-efda-4cdb-bf55-f4c21503c1de.png" width="100" /> 
  <img src="https://static.wikia.nocookie.net/logopedia/images/e/ec/Microsoft_Visual_Studio_2022.svg/revision/latest/scale-to-width-down/250?cb=20211027141551" width="100" /> 
</p>

## :hammer_and_wrench: Requirements
- [x] Install Visual Studio 2022 and .Net Frameword 4.7.2
   <br/> :bulb: Visual Studio 2022 is used to create ASP.Net Solution.
- [x] Install Microsoft SQL Studio (SSMS)
   <br/> :bulb: SSMS is used to manage the database.
- [x] Install SSMS Express
   <br/> :bulb: To create a database in your computer or server, the SSMS express must be installed. It will not create any shortcut file to your desktop, it will only run on background.

## 🔧 Database Configuration
1. Open SSMS and Connect to your SQL server and log in
2. Create new database and name it as "CALCUDB".
<br/>  ⚠️ Not doing this step can cause an issue on the web application
4. After creating CALCUDB on your SQL server, on the file 'QuoteCalculatorDB.sql' in SSMS and press "F5" to run the query. <br/> 💡 Location of the file (../QuoteCalculator/QuoteCalculatorDB)
<br/>  💡Running file ('QuoteCalculatorDB.sql') will create all the tables and stored procedure needed to run the Quote Calculator web app.
5. Just wait for the script to finish executing.

## 🚧 Database Table
   #### 🏗️ DBO.TBLPRODUCT


|         | NAME    | TYPE  |  DESCRIPTION  |
| :---:   | :---:   | :---: |  :---:        |
|🔑|PID|INT|Product ID|
||PCODE|NVARCHAR(50)|Product Code|
||PDESC|NVARCHAR(50)|Product Description |

   
   
   #### 🏗️ DBO.TBLQUOTE
   
   
||NAME|TYPE|DESCRIPTION|
|:--:|:--:|:--:|:--:|
|🔑|QID|INT|Quote ID|
||TITLE|NVARCHAR(50)|('Mr.', 'Mrs.')|
||FIRSTNAME|NVARCHAR(50)|First name of the requestor|
||LASTNAME|NVARCHAR(50)|Last name of the requestor|
|FK|PRODUCT|NVARCHAR(50)|This is the product ID from TBLPRODUCT. Foreign key of dbo.tblproduct.pid|
||AMOUNT|DECIMAL(18,4)|Amount of the quote|
||TERM|INT|Number of months for the quote|
||EMAIL|NVARCHAR(50)|Requestor email|
||DATEOFBIRTH|DATETIME|Requestor Birth Date|
||MOBILE|NVARCHAR(50)|Requestor mobile number|
||WEEKLY|NVARCHAR(50)|Requestor weekly payable for the quote|

## 🛠️ Setting Up Web config
1. Open the solution 'QuoteCalculator.sln' in your visual studio 2022. <br/> 💡 Location of the file '../QuoteCalculator'
2. Look for the file Web.config and look for the connection string. Change the Data Source value. Default value is 'MBTMNL-JOMIEE\SQLEXPRESS'. Change this value to the name of your SQL server. You can find this in your SSMS application.
3. From Visual Studio, Press 'F5' to run the web application. The application should be running at this point. Check the error log if error was thrown.

## 📄 Pages
> There are different pages in the solution. There are partial page and pages that is connected to those partial page.
