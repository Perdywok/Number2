namespace Number2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "BookId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Publisher", c => c.String());
            DropColumn("dbo.Books", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Content", c => c.String());
            DropColumn("dbo.Books", "Publisher");
            DropColumn("dbo.Authors", "BookId");
        }
    }
}
