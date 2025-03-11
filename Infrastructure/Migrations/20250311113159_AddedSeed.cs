using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectDate",
                table: "projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "educations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "educations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Achivements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Achivements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Achivements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Achivements",
                columns: new[] { "ID", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed the first milestone of the project.", "First Milestone" },
                    { 2, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received the team award for outstanding performance.", "Team Award" },
                    { 3, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Successfully launched the new product.", "Product Launch" }
                });

            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "ID", "Description", "ImageSrc", "Title" },
                values: new object[,]
                {
                    { 1, "Description 1", "Hobby1.png", "Hobby 1" },
                    { 2, "Descriptoin 2", "Hobby2.png", "Hobby 2" },
                    { 3, "Description 3", "Hobby3.png", "Hobby 3" },
                    { 4, "Description 4", "Hobby4.png", "Hobby 4" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "TagName" },
                values: new object[,]
                {
                    { 1, "Tag 1" },
                    { 2, "Tag 2" },
                    { 3, "Tag 3" }
                });

            migrationBuilder.InsertData(
                table: "educations",
                columns: new[] { "ID", "Description", "EducationLevel", "EndDate", "ImageSrc", "Institution", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Completed a BSc in Computer Science.", "Undergraduate", new DateTime(2018, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/uct.png", "University of Cape Town", new DateTime(2015, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bachelor of Science" },
                    { 2, "Completed an MSc in Data Science.", "Postgraduate", new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/uct.png", "University of Cape Town", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master of Science" },
                    { 3, "Pursuing a PhD in AI.", "Doctorate", new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/uct.png", "University of Cape Town", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PhD in Artificial Intelligence" }
                });

            migrationBuilder.InsertData(
                table: "experiences",
                columns: new[] { "ID", "Company", "EndDate", "ImageSrc", "IsCurrent", "Role", "StartDate" },
                values: new object[,]
                {
                    { 1, "Company A", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/companyA.png", false, "Software Developer", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Company B", null, "images/companyB.png", true, "Data Scientist", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Company C", null, "images/companyC.png", true, "AI Researcher", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "ID", "Description", "HasPublicLink", "Link", "ProjectDate", "Title" },
                values: new object[,]
                {
                    { 1, "Description 1", true, "https://www.google.com", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 1" },
                    { 2, "Description 2", true, "https://www.google.com", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 2" },
                    { 3, "Description 3", true, "https://www.google.com", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project 3" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTags",
                columns: new[] { "ID", "ProjectID", "TagID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 1 },
                    { 6, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achivements",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Achivements",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Achivements",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hobby",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hobby",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hobby",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hobby",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "educations",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "educations",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "educations",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "experiences",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "experiences",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "experiences",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "projects",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectDate",
                table: "projects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "educations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Institution",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageSrc",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "educations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "EducationLevel",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Achivements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Achivements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Achivements",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
