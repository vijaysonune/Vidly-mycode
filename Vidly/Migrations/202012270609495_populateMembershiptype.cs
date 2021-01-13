namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershiptype : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonth,Discount) values (1,0,0,0)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonth,Discount) values (2,30,1,10)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonth,Discount) values (3,90,3,15)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonth,Discount) values (4,200,12,20)");

            // Sql("drop table MembershipTypes");
        }

        public override void Down()
        {
           // Sql("drop table MembershipTypes");
        }
    }
}
