using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTheColumnNumberIntoClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Users",
                type: "int",
                unicode: false,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 145, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DocumentTypesAnalysis",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 191, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DocumentTypesAnalysis",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 191, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 604, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 164, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 141, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 614, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 615, DateTimeKind.Local).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 615, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 615, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 155, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 622, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 622, DateTimeKind.Local).AddTicks(3468));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 622, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 622, DateTimeKind.Local).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 136, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 136, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 136, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 136, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 175, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 175, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 175, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 175, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 160, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 160, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 160, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 160, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 186, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 186, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 26, 0, 24, 45, 186, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Number" },
                values: new object[] { new DateTime(2023, 8, 26, 0, 24, 45, 646, DateTimeKind.Local).AddTicks(1404), 12345678 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Users",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Clients",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 163, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DocumentTypesAnalysis",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 201, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DocumentTypesAnalysis",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 201, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 665, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ExamTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 160, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 666, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 666, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 666, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 666, DateTimeKind.Local).AddTicks(6536));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 667, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 667, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 667, DateTimeKind.Local).AddTicks(4029));

            migrationBuilder.UpdateData(
                table: "RolOperations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 667, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SampleTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SupportTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UnitMeasurements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Number" },
                values: new object[] { new DateTime(2023, 8, 22, 4, 6, 21, 668, DateTimeKind.Local).AddTicks(3405), "51995142" });
        }
    }
}
