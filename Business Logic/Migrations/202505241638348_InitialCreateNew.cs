namespace Business_Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRegDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 70),
                        Password = c.String(nullable: false, maxLength: 50),
                        RequestTime = c.DateTime(),
                        userRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRegDatas");
        }
    }
}
