namespace data_mos_ru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class org20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Patronymic = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persons");
        }
    }
}
