using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTableWithImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4847), "https://www.localsamosa.com/wp-content/uploads/2020/06/original_shutterstock_1294137358.jpg" });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4865), "https://www.burohappold.com/wp-content/uploads/2022/02/Mumbai-skyline_copyright-Adobe-Stock_01.jpg" });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 34, 46, 420, DateTimeKind.Local).AddTicks(4866), "https://www.uptourism.gov.in/images/shahnafaz.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 29, 22, 187, DateTimeKind.Local).AddTicks(1579), "" });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 29, 22, 187, DateTimeKind.Local).AddTicks(1592), "" });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl" },
                values: new object[] { new DateTime(2023, 3, 7, 17, 29, 22, 187, DateTimeKind.Local).AddTicks(1593), "" });
        }
    }
}
