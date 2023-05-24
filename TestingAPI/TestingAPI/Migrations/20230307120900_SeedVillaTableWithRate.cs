using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTableWithRate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 39, 0, 678, DateTimeKind.Local).AddTicks(9179), 100.0 });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 39, 0, 678, DateTimeKind.Local).AddTicks(9195), 300.0 });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 39, 0, 678, DateTimeKind.Local).AddTicks(9197), 200.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4847), 0.0 });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4865), 0.0 });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4866), 0.0 });
        }
    }
}
