namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Adress = c.String(),
                        CreationDate = c.String(),
                        Scope = c.Int(nullable: false),
                        ApplyNo = c.String(),
                        File = c.String(),
                        RegistrationDate = c.String(),
                        Status = c.String(),
                        UserId = c.Int(nullable: false),
                        RepresentativeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Representatives", t => t.RepresentativeId, cascadeDelete: true)
                .Index(t => t.RepresentativeId);
            
            CreateTable(
                "dbo.Representatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "RepresentativeId", "dbo.Representatives");
            DropIndex("dbo.Branches", new[] { "RepresentativeId" });
            DropTable("dbo.Representatives");
            DropTable("dbo.Branches");
        }
    }
}
