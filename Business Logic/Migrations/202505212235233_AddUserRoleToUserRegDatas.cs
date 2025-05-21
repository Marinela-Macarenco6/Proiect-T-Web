namespace Business_Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleToUserRegDatas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegDatas", "userRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegDatas", "userRole");
        }
    }
}
