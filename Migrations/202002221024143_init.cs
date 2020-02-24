namespace WebApplication12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietMeals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DietId = c.String(maxLength: 128),
                        MealId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .ForeignKey("dbo.Meals", t => t.MealId)
                .Index(t => t.DietId)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.Diets",
                c => new
                    {
                        DietId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DataCreate = c.String(),
                        AddMeals = c.Int(nullable: false),
                        CountPacients = c.Int(nullable: false),
                        CurrentDiet = c.String(),
                    })
                .PrimaryKey(t => t.DietId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        DoctorId = c.String(maxLength: 128),
                        DietId = c.String(maxLength: 128),
                        Age = c.Int(),
                        Alergic = c.String(),
                        CreationDate = c.DateTime(),
                        Height = c.String(),
                        Сontraindication = c.String(),
                        Unlike = c.String(),
                        LifeType = c.String(),
                        StartWeight = c.String(),
                        DietDurationDays = c.Int(),
                        CurrentDietName = c.String(),
                        ConsultationCount = c.Int(),
                        TargetWeight = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .ForeignKey("dbo.AspNetUsers", t => t.DoctorId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.DoctorId)
                .Index(t => t.DietId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DataAdd = c.String(),
                        TypeMeals = c.String(),
                        Diet_DietId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.Diets", t => t.Diet_DietId)
                .Index(t => t.Diet_DietId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Meal_MealId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.Meal_MealId)
                .Index(t => t.Meal_MealId);
            
            CreateTable(
                "dbo.MealIngridients",
                c => new
                    {
                        IngridientId = c.String(nullable: false, maxLength: 128),
                        MealId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.IngridientId, t.MealId })
                .ForeignKey("dbo.Ingredients", t => t.IngridientId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .Index(t => t.IngridientId)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DietId = c.String(maxLength: 128),
                        MealId = c.String(maxLength: 128),
                        DayOfWeek = c.Int(nullable: false),
                        MealTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diets", t => t.DietId)
                .ForeignKey("dbo.Meals", t => t.MealId)
                .Index(t => t.DietId)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DietMeals", "MealId", "dbo.Meals");
            DropForeignKey("dbo.DietMeals", "DietId", "dbo.Diets");
            DropForeignKey("dbo.Meals", "Diet_DietId", "dbo.Diets");
            DropForeignKey("dbo.Schedules", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Schedules", "DietId", "dbo.Diets");
            DropForeignKey("dbo.Ingredients", "Meal_MealId", "dbo.Meals");
            DropForeignKey("dbo.MealIngridients", "MealId", "dbo.Meals");
            DropForeignKey("dbo.MealIngridients", "IngridientId", "dbo.Ingredients");
            DropForeignKey("dbo.AspNetUsers", "DoctorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DietId", "dbo.Diets");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Schedules", new[] { "MealId" });
            DropIndex("dbo.Schedules", new[] { "DietId" });
            DropIndex("dbo.MealIngridients", new[] { "MealId" });
            DropIndex("dbo.MealIngridients", new[] { "IngridientId" });
            DropIndex("dbo.Ingredients", new[] { "Meal_MealId" });
            DropIndex("dbo.Meals", new[] { "Diet_DietId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "DietId" });
            DropIndex("dbo.AspNetUsers", new[] { "DoctorId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.DietMeals", new[] { "MealId" });
            DropIndex("dbo.DietMeals", new[] { "DietId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Schedules");
            DropTable("dbo.MealIngridients");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Meals");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Diets");
            DropTable("dbo.DietMeals");
        }
    }
}
