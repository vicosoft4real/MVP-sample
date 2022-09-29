using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ActiveField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1bc536af-93ec-4832-9743-d1d9a1dc3c53"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8d7c3a76-7581-46a5-9cca-4c5cfdcba27c"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("5301ef92-c23f-4a10-a2b0-3f34408ae1d1"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("688901ff-26fa-4cc3-bc07-f419939be145"));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Agreements",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description" },
                values: new object[] { new Guid("14f29726-3c03-40d8-9d7c-ece6967085ac"), true, "AZE1234", "Product description" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description" },
                values: new object[] { new Guid("253abf73-86d5-46d1-a36e-b86864038ef3"), true, "AZE1235", "Group 2, description" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "Number", "Price" },
                values: new object[] { new Guid("4727b203-0635-41bc-8664-8f93a6ed4dbd"), true, "New product sample1", new Guid("14f29726-3c03-40d8-9d7c-ece6967085ac"), "09887654", 30.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "Number", "Price" },
                values: new object[] { new Guid("9416d410-23ac-46e8-94fb-6be64343bd17"), true, "New product sample2", new Guid("253abf73-86d5-46d1-a36e-b86864038ef3"), "09887653", 40.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4727b203-0635-41bc-8664-8f93a6ed4dbd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9416d410-23ac-46e8-94fb-6be64343bd17"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("14f29726-3c03-40d8-9d7c-ece6967085ac"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("253abf73-86d5-46d1-a36e-b86864038ef3"));

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Agreements");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description" },
                values: new object[] { new Guid("5301ef92-c23f-4a10-a2b0-3f34408ae1d1"), true, "AZE1235", "Group 2, description" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description" },
                values: new object[] { new Guid("688901ff-26fa-4cc3-bc07-f419939be145"), true, "AZE1234", "Product description" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "Number", "Price" },
                values: new object[] { new Guid("1bc536af-93ec-4832-9743-d1d9a1dc3c53"), true, "New product sample1", new Guid("688901ff-26fa-4cc3-bc07-f419939be145"), "09887654", 30.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "Number", "Price" },
                values: new object[] { new Guid("8d7c3a76-7581-46a5-9cca-4c5cfdcba27c"), true, "New product sample2", new Guid("5301ef92-c23f-4a10-a2b0-3f34408ae1d1"), "09887653", 40.00m });
        }
    }
}
