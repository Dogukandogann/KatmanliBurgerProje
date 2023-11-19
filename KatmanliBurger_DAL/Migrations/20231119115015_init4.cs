using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatmanliBurger_DAL.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 14, 50, 15, 26, DateTimeKind.Local).AddTicks(6597));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5347));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5572));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5579));
        }
    }
}
