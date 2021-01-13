namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Name_column_in_MembershiptType : DbMigration
    {
        public override void Up()
        {
            Sql("Alter Table MembershipTypes ADD Name varchar(50)");
        }
        
        public override void Down()
        {
        }
    }
}
