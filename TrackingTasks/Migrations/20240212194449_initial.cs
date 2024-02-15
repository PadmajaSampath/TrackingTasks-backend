using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingTasks.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workTaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    workTaskDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    workTaskStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTask", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTask");
        }
    }
}
