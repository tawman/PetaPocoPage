Server-Side Paging with PetaPoco and DataTables
===============================================

This sample project is meant to demonstrate how to perform server-side paging using PetaPoco and DataTables in an ASP.NET MVC3 solution.

Example Source Data
-------------------
The SQL Server 2008 Express R2 database has a single *Customer* table containing 4,000 rows of sample data. I ran my tests with 1,000,000 records for the blog associated with this project, but that is too large for a public github repository.

    CREATE TABLE [dbo].[Customer](
        [Id] [int] NOT NULL,
        [First] [varchar](20) NOT NULL,
        [Last] [varchar](20) NOT NULL,
        [Street] [varchar](100) NOT NULL,
        [City] [varchar](30) NOT NULL,
        [State] [char](2) NOT NULL,
        [Zip] [char](5) NOT NULL,
        [Email] [varchar](50) NOT NULL,
        [Phone] [char](12) NOT NULL,
      CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ( [Id] ASC )
      WITH (PAD_INDEX  = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY];

This database table maps to a simple POCO object:

    public class Customer
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

How To Build It?
----------------

From a command window run: *build.bat*

Otherwise, open the Solution file in Visual Studio 2010 and Build

How Do You View It?
-------------------

From the Start menu, click Run, then type *inetmgr* to open the Internet Information Services (IIS) MMC snap-in.

1. Right mouse click on the Default Web Site and Select "Add Application"
2. Enter an Alias for the Site (i.e. *PetaPocoPage*)
3. Enter the Physical Path (i.e. *C:\@WCP\clone\PetaPocoPage\src\PetaPocoPage*)
4. Open a web browser to: http://localhost/PetaPocoPage/

Alternatively, Open the PetaPocoPage.sln Solution in Visual Studio 2010 and explore.

The sample database file provided was created with SQL Server 2008 R2. The SQL needed to create the table and sample data is provided in the src/database directory.

Thanks
------
This software is Open Source and check the LICENSE.txt file for more details.

Todd A. Wood
([@iToddWood](https://twitter.com/#!/iToddWood "Follow me on Twitter"))
Visit [Implement IToddWood](http://www.woodcp.com "Wood Consulting Practice, LLC")
