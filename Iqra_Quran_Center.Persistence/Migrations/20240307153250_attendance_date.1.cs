using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iqra_Quran_Center.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class attendance_date1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Attendances",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Attendances",
                newName: "DateTime");
        }
    }
}
