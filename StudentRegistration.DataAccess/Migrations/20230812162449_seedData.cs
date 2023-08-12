using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRegistration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "Management" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "ContactNo", "DOB", "Email", "NIC", "Name" },
                values: new object[,]
                {
                    { 1, "no 55/1", "gattuwana", "kurunegala", "0717992131", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yomal.devanz@gmail.com", "942021852V", "Yomal" },
                    { 2, "no 42/1", "gattuwana", "kurunegala", "0767788909", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ben.devanz@gmail.com", "992021852V", "Ben" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "ContactNo", "CourseId", "DOB", "Email", "NIC", "Name" },
                values: new object[,]
                {
                    { 1, "no 12/1", "gattuwana", "kurunegala", "0767788909", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "top.devanz@gmail.com", "992021852V", "Top" },
                    { 2, "no 12/1", "gattuwana", "kurunegala", "0767788909", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bottom.devanz@gmail.com", "992021852V", "Bottom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
