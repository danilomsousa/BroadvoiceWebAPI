# BroadvoiceWebAPI
<h2>Problem</h2>


The sales department needs to report the salespeople's activity. After some preliminary interviews with the sales team, we know the following:

A salesperson sells products to customers.
From a salesperson, we know the name and email.
From a customer, we know the email and name.
A product has a code, name, and cost.
A salesperson generates profits by selling a product higher than the cost.
The company sells products to customers in any city and state in the USA.
They have 100 active salespeople.
They have 1000 products in inventory.
On average, the department completes 10,000 sales per month.


Based on the previous information, you are asked to implement a Web API that returns the list of sales filterable by the following optional arguments:

  Salesperson name.
  Date range.
  Product code.
  Customer email.
  City.
  State.
  
<h2> WebAPI developed using .NET 7 using Entity Framework to map data and a single Get method with the optional parameters for filter data. </h2>

<h2>SQL Schema</h2>
<html><iframe width="100%" height="500px" style="box-shadow: 0 2px 8px 0 rgba(63,69,81,0.16); border-radius:15px;" allowtransparency="true" allowfullscreen="true" scrolling="no" title="Embedded DrawSQL IFrame" frameborder="0" src="https://drawsql.app/teams/danilo-sousa-teams/diagrams/broadvoice-salesapi/embed"></iframe><html>

