namespace MoneyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDbAddedAccountModelExpenseModelExpenseTypeModelIncomeModelIncomeTypeModelUserModelUserAccountModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IncomeId = c.Guid(nullable: false),
                        ExpenseId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Expenses", t => t.ExpenseId, cascadeDelete: true)
                .ForeignKey("dbo.Incomes", t => t.IncomeId, cascadeDelete: true)
                .Index(t => t.IncomeId)
                .Index(t => t.ExpenseId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ExpenseTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        ExpenseSum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseTypes", t => t.ExpenseTypeId, cascadeDelete: true)
                .Index(t => t.ExpenseTypeId);
            
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IncomeTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        IncomeSum = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeTypeId, cascadeDelete: true)
                .Index(t => t.IncomeTypeId);
            
            CreateTable(
                "dbo.IncomeTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        AccountId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAccounts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "IncomeId", "dbo.Incomes");
            DropForeignKey("dbo.Incomes", "IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.Accounts", "ExpenseId", "dbo.Expenses");
            DropForeignKey("dbo.Expenses", "ExpenseTypeId", "dbo.ExpenseTypes");
            DropIndex("dbo.UserAccounts", new[] { "AccountId" });
            DropIndex("dbo.UserAccounts", new[] { "UserId" });
            DropIndex("dbo.Incomes", new[] { "IncomeTypeId" });
            DropIndex("dbo.Expenses", new[] { "ExpenseTypeId" });
            DropIndex("dbo.Accounts", new[] { "ExpenseId" });
            DropIndex("dbo.Accounts", new[] { "IncomeId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.Incomes");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Expenses");
            DropTable("dbo.Accounts");
        }
    }
}
