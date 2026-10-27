using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CustomerIdFromUser : Migration
    {
        // SQL Server cannot drop IDENTITY from a column, so Customers is rebuilt (rows kept).
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE [Customers_tmp] ([Id] int NOT NULL CONSTRAINT [PK_Customers_tmp] PRIMARY KEY, [NationalIdentity] nvarchar(max) NULL);");
            migrationBuilder.Sql("INSERT INTO [Customers_tmp] ([Id], [NationalIdentity]) SELECT [Id], [NationalIdentity] FROM [Customers];");
            migrationBuilder.Sql("DROP TABLE [Customers];");
            migrationBuilder.Sql("EXEC sp_rename N'Customers_tmp', N'Customers';");
            migrationBuilder.Sql("EXEC sp_rename N'PK_Customers_tmp', N'PK_Customers', N'OBJECT';");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE [Customers_tmp] ([Id] int IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Customers_tmp] PRIMARY KEY, [NationalIdentity] nvarchar(max) NOT NULL);");
            migrationBuilder.Sql("SET IDENTITY_INSERT [Customers_tmp] ON; INSERT INTO [Customers_tmp] ([Id], [NationalIdentity]) SELECT [Id], ISNULL([NationalIdentity], N'') FROM [Customers]; SET IDENTITY_INSERT [Customers_tmp] OFF;");
            migrationBuilder.Sql("DROP TABLE [Customers];");
            migrationBuilder.Sql("EXEC sp_rename N'Customers_tmp', N'Customers';");
            migrationBuilder.Sql("EXEC sp_rename N'PK_Customers_tmp', N'PK_Customers', N'OBJECT';");
        }
    }
}
