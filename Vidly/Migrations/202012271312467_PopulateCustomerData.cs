namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerData : DbMigration
    {
        public override void Up()
        {

            //Sql("insert into Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) values ('John Smith',0,1)");
            //Sql("insert into Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) values ('Vijay',1,2)");
          //  Sql("insert into Customer (Name,IsSubscribedToNewsLetter,MembershipTypeId) values ('Abhi',false,1)");
        }
        
        public override void Down()
        {
           // Sql("delete table Customers");
        }
    }
}
