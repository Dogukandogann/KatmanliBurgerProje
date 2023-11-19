using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatmanliBurger_DAL.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "ParameterTypes",
                columns: new[] { "Id", "CreatedDate", "Status", "TypeName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5570), 1, "About", null },
                    { 2, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5572), 1, "Contact", null },
                    { 3, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5574), 1, "General", null },
                    { 4, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5576), 1, "Exception", null },
                    { 5, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5577), 1, "UIMessagges", null },
                    { 6, new DateTime(2023, 11, 19, 0, 18, 5, 111, DateTimeKind.Local).AddTicks(5579), 1, "AdminMessagges", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParameterTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 23, 18, 27, 415, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 23, 18, 27, 415, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 23, 18, 27, 415, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 23, 18, 27, 415, DateTimeKind.Local).AddTicks(6351));
        }
    }
}
