using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerceCore.Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountEntity : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminAccount_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bc94d070-1511-4a88-a46d-c3e029f8f4cc"), "Admin" },
                    { new Guid("da56f59a-2ab5-401d-ba8b-665b5340fa0c"), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AdminAccount",
                columns: new[] { "Id", "AccountTypeId", "ContactNumber", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "MiddleName", "Password" },
                values: new object[,]
                {
                    { new Guid("0554e729-5b8b-42d1-b0e3-8baa493f8ad8"), new Guid("da56f59a-2ab5-401d-ba8b-665b5340fa0c"), "7578998845", "admin@gmail.com", "Admin", true, false, "Admin", null, "Admin@123" },
                    { new Guid("1a6f5cec-57e5-4d2e-bf23-ad5b7b4a0562"), new Guid("bc94d070-1511-4a88-a46d-c3e029f8f4cc"), "7578998845", "admin@gmail.com", "Admin", true, false, "Admin", null, "Admin@123" },
                    { new Guid("4028251d-0368-4192-bcac-875ece2c0ccb"), new Guid("bc94d070-1511-4a88-a46d-c3e029f8f4cc"), "7578998845", "admin@gmail.com", "Admin", true, false, "Admin", null, "Admin@123" },
                    { new Guid("86bb0e2c-da9a-4fc0-9a3f-d41eb5eb112d"), new Guid("bc94d070-1511-4a88-a46d-c3e029f8f4cc"), "7578998845", "admin@gmail.com", "Admin", true, false, "Admin", null, "Admin@123" },
                    { new Guid("b9a651f2-95ff-4509-a727-c952a67471dd"), new Guid("bc94d070-1511-4a88-a46d-c3e029f8f4cc"), "7578998845", "admin@gmail.com", "Admin", true, false, "Admin", null, "Admin@123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAccount_AccountTypeId",
                table: "AdminAccount",
                column: "AccountTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAccount");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
