# Quote Calculator
>This project is dedicated for technical exam of Money Me. This is created by Jomiel Enriquez from October 31, 2022 to November 1, 2022. There are lots of things that needs to improve in this project but this version is already working. This projects is build in just 2 days using different kinds of technology.

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
4. After creating CALCUDB on your SQL server, on the file 'QuoteCalculatorDB.sql' in SSMS and press "F5" to run the query.
<br/>  💡Running file ('QuoteCalculatorDB.sql') will create all the tables and stored procedure needed to run the Quote Calculator web app.
5. Just wait for the script to finish executing.

## 🚧 Database Table
   #### 🏗️ DBO.TBLPRODUCT
   COLUMNS
   <br/> - 🔑 PID   INT   💡Product ID
   <br/> - 🟨 PCODE NVARCHAR(50) 💡Product Code
   <br/> - 🟨 PDESC NVARCHAR(50) 💡Product Description 
   <br/>
   
   
   #### 🏗️ DBO.TBLQUOTE
   COLUMNS
   <br/> - 🔑 QID   INT   💡Quote ID
   <br/> - 🟨 TITLE NVARCHAR(50) 💡('Mr.', 'Mrs.')
   <br/> - 🟨 FIRSTNAME NVARCHAR(50) 💡First name of the requestor
   <br/> - 🟨 LASTNAME NVARCHAR(50) 💡Last name of the requestor
   <br/> - 🟨 PRODUCT NVARCHAR(50) 💡This is the product ID from TBLPRODUCT. Foreign key of dbo.tblproduct.pid
   <br/> - 🟨 AMOUNT DECIMAL(18,4) 💡Amount of the quote
   <br/> - 🟨 TERM INT 💡Number of months for the quote
   <br/> - 🟨 EMAIL NVARCHAR(50) 💡Requestor email
   <br/> - 🟨 DATEOFBIRTH DATETIME 💡Requestor Birth Date
   <br/> - 🟨 MOBILE NVARCHAR(50) 💡Requestor mobile number
   <br/> - 🟨 WEEKLY NVARCHAR(50) 💡Requestor weekly payable for the quote



