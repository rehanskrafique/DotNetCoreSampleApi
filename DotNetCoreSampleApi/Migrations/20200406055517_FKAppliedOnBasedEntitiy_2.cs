using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreSampleApi.Migrations
{
    public partial class FKAppliedOnBasedEntitiy_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("8f265976-d4d7-40ad-8fc6-dfc4b0737e59"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("eab8cfbb-5a7a-4674-b525-5095b0bfcee5"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("2a6cd739-6a31-4919-b46f-666ce83c653a"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("680f2aed-7110-45cc-9290-6a792a6c4667"), "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastModifiedBy",
                table: "Users",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastModifiedBy",
                table: "Products",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastModifiedBy",
                table: "Categories",
                column: "LastModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_LastModifiedBy",
                table: "Categories",
                column: "LastModifiedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_LastModifiedBy",
                table: "Products",
                column: "LastModifiedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_LastModifiedBy",
                table: "Users",
                column: "LastModifiedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_LastModifiedBy",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_LastModifiedBy",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_LastModifiedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LastModifiedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_LastModifiedBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LastModifiedBy",
                table: "Categories");

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
                values: new object[] { new Guid("8f265976-d4d7-40ad-8fc6-dfc4b0737e59"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("eab8cfbb-5a7a-4674-b525-5095b0bfcee5"), "Customer", "CUSTOMER" });
        }
    }
}
