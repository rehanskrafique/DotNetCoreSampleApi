using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreSampleApi.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2a6cd739-6a31-4919-b46f-666ce83c653a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("680f2aed-7110-45cc-9290-6a792a6c4667"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("2a6cd739-6a31-4919-b46f-666ce83c653a"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("680f2aed-7110-45cc-9290-6a792a6c4667"), "Customer", "CUSTOMER" });
        }
    }
}
