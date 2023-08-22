using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NameFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Confirm = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Reset = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    RecoveryToken = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cui = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departments_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypesAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypesAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypesAnalysis_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentTypesAnalysis_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTypes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamTypes_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpMachine = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    RegisterId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    TableName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    OperationType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogHeaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Modules_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestStatus_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestStatus_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SampleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleTypes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SampleTypes_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTypes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportTypes_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMeasurements_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnitMeasurements_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogBookDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLog = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PreviousValue = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastValue = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBookDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogBookDetails_LogHeaders_IdLog",
                        column: x => x.IdLog,
                        principalTable: "LogHeaders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdModule = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Modules_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Modules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportTypeId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    SupportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_ExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "ExamTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_RequestStatus_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_SupportTypes_SupportTypeId",
                        column: x => x.SupportTypeId,
                        principalTable: "SupportTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolOperations_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSampleId = table.Column<int>(type: "int", nullable: false),
                    Presentation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    QuantityUnits = table.Column<int>(type: "int", nullable: false),
                    UnitMeasurementId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(GetDate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Samples_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Samples_SampleTypes_TypeSampleId",
                        column: x => x.TypeSampleId,
                        principalTable: "SampleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Samples_UnitMeasurements_UnitMeasurementId",
                        column: x => x.UnitMeasurementId,
                        principalTable: "UnitMeasurements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TraceabilityRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    StatusRequestId = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraceabilityRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraceabilityRequests_RequestStatus_StatusRequestId",
                        column: x => x.StatusRequestId,
                        principalTable: "RequestStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TraceabilityRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedUserId = table.Column<int>(type: "int", nullable: false),
                    AssignerUserId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAssignments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAssignments_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAssignments_Users_AssignerUserId",
                        column: x => x.AssignerUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnalysisDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeAnalysisId = table.Column<int>(type: "int", nullable: false),
                    Conclusion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisDocuments_DocumentTypesAnalysis_DocumentTypeAnalysisId",
                        column: x => x.DocumentTypeAnalysisId,
                        principalTable: "DocumentTypesAnalysis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnalysisDocuments_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SamplesItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    SampleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamplesItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SamplesItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SamplesItems_Samples_SampleId",
                        column: x => x.SampleId,
                        principalTable: "Samples",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Confirm", "CreatedAt", "DateToken", "Email", "Number", "Password" },
                values: new object[] { 1, true, true, new DateTime(2023, 8, 22, 4, 6, 21, 539, DateTimeKind.Local).AddTicks(801), "", "pruebas.test29111999@gmail.com", "51995142", "b20b0f63ce2ed361e8845d6bf2e59811aaa06ec96bcdb92f9bc0c5a25e83c9a6" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2023, 8, 22, 4, 6, 21, 163, DateTimeKind.Unspecified), 1, "Administrador", "Administrador", null, null });

            migrationBuilder.InsertData(
                table: "DocumentTypesAnalysis",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 201, DateTimeKind.Unspecified), 1, "Certificación de Muestra Médica", "PE-01", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 201, DateTimeKind.Unspecified), 1, "Dictamen de Muestra Médica", "PE-02", null, null }
                });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Hematología", "HE", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Química Clínica", "QC", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Inmunología", "IN", null, null },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Microbiología", "MC", null, null },
                    { 5, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Serología", "SR", null, null },
                    { 6, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Hormonas", "HM", null, null },
                    { 7, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Genética y Biología Molecular", "GB", null, null },
                    { 8, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Citología", "CT", null, null },
                    { 9, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Microbiología", "MC", null, null },
                    { 10, new DateTime(2023, 8, 22, 4, 6, 21, 181, DateTimeKind.Unspecified), 1, "Gases en Sangre", "GS", null, null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Image", "Name", "Path", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, new DateTime(2023, 8, 22, 4, 6, 21, 160, DateTimeKind.Unspecified), 1, "Mantenimiento de usuarios", "users", "Mantenimiento Analistas", "/Users", null, null });

            migrationBuilder.InsertData(
                table: "RequestStatus",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Creada", "Cr", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Enviada", "EN", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Revisada", "RV", null, null },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Análisis", "AN", null, null },
                    { 5, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Asignada", "AS", null, null },
                    { 6, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Autorizada", "AU", null, null },
                    { 7, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Rechazada", "RE", null, null },
                    { 8, new DateTime(2023, 8, 22, 4, 6, 21, 173, DateTimeKind.Unspecified), 1, "Eliminada", "EL", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified), 1, "", "Manager", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified), 1, "", "Centralizador", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified), 1, "", "Técnico", null, null },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 156, DateTimeKind.Unspecified), 1, "", "Analista", null, null }
                });

            migrationBuilder.InsertData(
                table: "SampleTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified), 1, "Cultivo", "CL", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified), 1, "Plaquetas", "PL", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified), 1, "Eses", "ES", null, null },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 193, DateTimeKind.Unspecified), 1, "Orina", "OR", null, null }
                });

            migrationBuilder.InsertData(
                table: "SupportTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified), 1, "Comprobante de Pago", "CP", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified), 1, "Seguro Médico", "SE", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified), 1, "Solicitud Médica", "SM", null, null },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 177, DateTimeKind.Unspecified), 1, "Examen Externo", "ET", null, null }
                });

            migrationBuilder.InsertData(
                table: "UnitMeasurements",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified), 1, "Miligramos", "MG", null, null },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified), 1, "Gramos", "GR", null, null },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 196, DateTimeKind.Unspecified), 1, "Mililitros", "MI", null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DepartmentId", "Name", "RolId", "UnitId", "UserId", "UserName" },
                values: new object[] { 1, new DateTime(2023, 8, 22, 4, 6, 21, 523, DateTimeKind.Local).AddTicks(2162), 1, 1, "Usuario Manager", 1, 1, 1, "System" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "CreatedAt", "Description", "Icon", "IdModule", "IsVisible", "Name", "Path" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 527, DateTimeKind.Local).AddTicks(6615), "Creación de nuevo analista", "plus", 1, true, "Crear Analista", "/User/Create" },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 527, DateTimeKind.Local).AddTicks(7738), "Actualización de analista", "", 1, false, "Actualizar Analista", "/User/Update" },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 527, DateTimeKind.Local).AddTicks(8564), "Listado de Analistas Existentes", "", 1, true, "Listar Analistas", "/User" },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 527, DateTimeKind.Local).AddTicks(9385), "Actualización de analista", "", 1, false, "Actualizar Analista Parcialmente", "/User/Patch" }
                });

            migrationBuilder.InsertData(
                table: "RolOperations",
                columns: new[] { "Id", "CreatedAt", "OperationId", "RolId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 22, 4, 6, 21, 532, DateTimeKind.Local).AddTicks(3854), 1, 1 },
                    { 2, new DateTime(2023, 8, 22, 4, 6, 21, 532, DateTimeKind.Local).AddTicks(4627), 2, 1 },
                    { 3, new DateTime(2023, 8, 22, 4, 6, 21, 532, DateTimeKind.Local).AddTicks(5112), 3, 1 },
                    { 4, new DateTime(2023, 8, 22, 4, 6, 21, 532, DateTimeKind.Local).AddTicks(5611), 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisDocuments_DocumentTypeAnalysisId",
                table: "AnalysisDocuments",
                column: "DocumentTypeAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisDocuments_SampleId",
                table: "AnalysisDocuments",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedBy",
                table: "Departments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedBy",
                table: "Departments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RequestId",
                table: "Documents",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypesAnalysis_CreatedBy",
                table: "DocumentTypesAnalysis",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypesAnalysis_UpdatedBy",
                table: "DocumentTypesAnalysis",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RolId",
                table: "Employees",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypes_CreatedBy",
                table: "ExamTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTypes_UpdatedBy",
                table: "ExamTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatedBy",
                table: "Items",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UpdatedBy",
                table: "Items",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LogBookDetails_IdLog",
                table: "LogBookDetails",
                column: "IdLog");

            migrationBuilder.CreateIndex(
                name: "IX_LogHeaders_UserId",
                table: "LogHeaders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CreatedBy",
                table: "Modules",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UpdatedBy",
                table: "Modules",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_IdModule",
                table: "Operations",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientId",
                table: "Requests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ExamTypeId",
                table: "Requests",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestStatusId",
                table: "Requests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SupportTypeId",
                table: "Requests",
                column: "SupportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestStatus_CreatedBy",
                table: "RequestStatus",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RequestStatus_UpdatedBy",
                table: "RequestStatus",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedBy",
                table: "Roles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedBy",
                table: "Roles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RolOperations_OperationId",
                table: "RolOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_RolOperations_RolId",
                table: "RolOperations",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_RequestId",
                table: "Samples",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_TypeSampleId",
                table: "Samples",
                column: "TypeSampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Samples_UnitMeasurementId",
                table: "Samples",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_SamplesItems_ItemId",
                table: "SamplesItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SamplesItems_SampleId",
                table: "SamplesItems",
                column: "SampleId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleTypes_CreatedBy",
                table: "SampleTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SampleTypes_UpdatedBy",
                table: "SampleTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTypes_CreatedBy",
                table: "SupportTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTypes_UpdatedBy",
                table: "SupportTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TraceabilityRequests_RequestId",
                table: "TraceabilityRequests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TraceabilityRequests_StatusRequestId",
                table: "TraceabilityRequests",
                column: "StatusRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMeasurements_CreatedBy",
                table: "UnitMeasurements",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMeasurements_UpdatedBy",
                table: "UnitMeasurements",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssignments_AssignedUserId",
                table: "UserAssignments",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssignments_AssignerUserId",
                table: "UserAssignments",
                column: "AssignerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssignments_RequestId",
                table: "UserAssignments",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisDocuments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LogBookDetails");

            migrationBuilder.DropTable(
                name: "RolOperations");

            migrationBuilder.DropTable(
                name: "SamplesItems");

            migrationBuilder.DropTable(
                name: "TraceabilityRequests");

            migrationBuilder.DropTable(
                name: "UserAssignments");

            migrationBuilder.DropTable(
                name: "DocumentTypesAnalysis");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "LogHeaders");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SampleTypes");

            migrationBuilder.DropTable(
                name: "UnitMeasurements");

            migrationBuilder.DropTable(
                name: "ExamTypes");

            migrationBuilder.DropTable(
                name: "RequestStatus");

            migrationBuilder.DropTable(
                name: "SupportTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
