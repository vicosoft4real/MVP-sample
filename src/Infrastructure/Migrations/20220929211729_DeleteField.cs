using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DeleteField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Agreements",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description", "IsDeleted" },
                values: new object[] { new Guid("6dcd71d6-acef-4608-b478-d55a47c3910f"), true, "AZE1235", "Group 2, description", false });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Active", "Code", "Description", "IsDeleted" },
                values: new object[] { new Guid("a7eac81b-32bd-4940-9301-4fd832aefb3b"), true, "AZE1234", "Product description", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "IsDeleted", "Number", "Price" },
                values: new object[] { new Guid("45f64aa8-5271-402c-b1b5-680b0536836f"), true, "New product sample1", new Guid("a7eac81b-32bd-4940-9301-4fd832aefb3b"), false, "09887654", 30.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "GroupId", "IsDeleted", "Number", "Price" },
                values: new object[] { new Guid("ad292ec6-aeff-4fe9-b72b-a4d0a216a7bc"), true, "New product sample2", new Guid("6dcd71d6-acef-4608-b478-d55a47c3910f"), false, "09887653", 40.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45f64aa8-5271-402c-b1b5-680b0536836f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad292ec6-aeff-4fe9-b72b-a4d0a216a7bc"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("6dcd71d6-acef-4608-b478-d55a47c3910f"));

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: new Guid("a7eac81b-32bd-4940-9301-4fd832aefb3b"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Agreements");

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
    }
}
