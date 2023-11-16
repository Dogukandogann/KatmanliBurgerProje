using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatmanliBurger_DAL.Migrations
{
    public partial class ProductDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "OrderByProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MenuOrders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MenuByProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Garnitures");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ByProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Burgers");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerOrders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerMenus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerGarnitures");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ByProducts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ByProducts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "OrderByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MenuOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MenuByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Garnitures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Burgers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerMenus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerGarnitures",
                type: "datetime2",
                nullable: true);
        }
    }
}
