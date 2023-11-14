using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatmanliBurger_DAL.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderByProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "OrderByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderByProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MenuOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MenuOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MenuOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MenuOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MenuByProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "MenuByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MenuByProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MenuByProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BurgerOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BurgerOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BurgerOrders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BurgerMenus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerMenus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BurgerMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BurgerMenus",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BurgerGarnitures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "BurgerGarnitures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BurgerGarnitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BurgerGarnitures",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderByProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "OrderByProducts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderByProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "OrderByProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MenuOrders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MenuOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MenuOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MenuOrders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MenuByProducts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "MenuByProducts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MenuByProducts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MenuByProducts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BurgerOrders");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BurgerOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BurgerOrders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BurgerMenus");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerMenus");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BurgerMenus");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BurgerMenus");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BurgerGarnitures");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "BurgerGarnitures");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BurgerGarnitures");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BurgerGarnitures");
        }
    }
}
