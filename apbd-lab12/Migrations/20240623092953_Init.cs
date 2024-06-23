﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apbd_lab12.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicaments", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_prescriptions_doctors_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescriptions_patients_IdPatient",
                        column: x => x.IdPatient,
                        principalTable: "patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescription_medications",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription_medications", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "FK_prescription_medications_medicaments_IdMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prescription_medications_prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "j.kowalski@gmail.com", "Jan", "Kowalski" },
                    { 2, "a.nowak@gmail.com", "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Przeciwbólowy", "Apap", "Tabletki" },
                    { 2, "Przeciwzapalny", "Ibuprom", "Tabletki" },
                    { 3, "Przeciwgorączkowy", "Paracetamol", "Tabletki" },
                    { 4, "Przeciwpłytkowy", "Aspiryna", "Tabletki" }
                });

            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Kowalski" },
                    { 2, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", "Nowak" },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", "Wiśniewski" },
                    { 4, new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karolina", "Kowalczyk" }
                });

            migrationBuilder.InsertData(
                table: "prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 4, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "prescription_medications",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "Przed posiłkiem", 2 },
                    { 2, 2, "Po posiłku", 1 },
                    { 3, 3, "Przed snem", 3 },
                    { 4, 4, "Przed posiłkiem", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_prescription_medications_IdPrescription",
                table: "prescription_medications",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_IdDoctor",
                table: "prescriptions",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_IdPatient",
                table: "prescriptions",
                column: "IdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prescription_medications");

            migrationBuilder.DropTable(
                name: "medicaments");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");
        }
    }
}
