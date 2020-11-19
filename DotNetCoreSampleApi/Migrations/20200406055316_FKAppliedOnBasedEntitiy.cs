using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreSampleApi.Migrations
{
    public partial class FKAppliedOnBasedEntitiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("5223f8f8-3ae0-437e-8327-b931f467d0cb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("8400e3c2-f7e3-4dc1-8448-f30451b2db5d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("8f265976-d4d7-40ad-8fc6-dfc4b0737e59"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("eab8cfbb-5a7a-4674-b525-5095b0bfcee5"), "Customer", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedBy",
                table: "Categories",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedBy",
                table: "Categories",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedBy",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedBy",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatedBy",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedBy",
                table: "Categories");

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
                values: new object[] { new Guid("8400e3c2-f7e3-4dc1-8448-f30451b2db5d"), "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name", "NormalizedName" },
                values: new object[] { new Guid("5223f8f8-3ae0-437e-8327-b931f467d0cb"), "Customer", "CUSTOMER" });
        }
    }
}
