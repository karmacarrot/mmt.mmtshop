
Setup:
	- Restore any missing nuget packages
	- Run SQL scripts in mmt.mmtshop\Mmt.MmtShop.Database
	- Run web api project (Mmt.MmtShop.Api) on: https://localhost:44324
	- Run all tests (16 in total, should all pass)
	- Run console app (Mmt.MmtShop.ApiConsole) 


#Assumptions in lieu of interviewing product owner / clients
	- SKU is always numeric
	- Product name will never be more than 100 characters
	- There will never be a requirement around auditing date added / modified for products
	- All facets of a product will always be required / available 


#Future items for backlog
	- Make the console app a bit smarter, parse into objects etc
	- Move connection string to pipeline / key vault etc
	- Implement logging methods using preferred solution (application insights etc)
	- CD / CI Pipelines
	- Mock logger for making integration tests
	- Discuss security concerns, ip whitelisting, authentication, DDoS etc
	- Discuss scaling concerns, microservices, redis etc
	- Move some of the test setup to a base class

