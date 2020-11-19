using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreSampleApi.Migrations
{
    public partial class ParametersAddedtoUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("846e64ff-5bd9-43b9-a6b1-8a2e3c0f6c54"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f9ca24f3-8b65-4cda-ad27-4533d8cedb70"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("211f6640-810a-466b-818f-ca153e382072"));

            migrationBuilder.AddColumn<bool>(
                name: "Invalidated",
                table: "UserTokens",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invalidated",
                table: "UserTokens");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("846e64ff-5bd9-43b9-a6b1-8a2e3c0f6c54"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("f9ca24f3-8b65-4cda-ad27-4533d8cedb70"), "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ContactNumber", "CreatedBy", "CreatedOnUtc", "EmailId", "IsActive", "LastModifiedBy", "LastModifiedOnUtc", "Name", "Password", "UserName" },
                values: new object[] { new Guid("211f6640-810a-466b-818f-ca153e382072"), "0987654321", new Guid("211f6640-810a-466b-818f-ca153e382072"), new DateTime(2020, 4, 6, 6, 38, 33, 258, DateTimeKind.Utc).AddTicks(818), "admin@7techitservices.com", true, null, null, "Admin", "123456", "admin" });
        }
    }
}
