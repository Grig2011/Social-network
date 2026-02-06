using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevNet.Migrations
{
    /// <inheritdoc />
    public partial class NoProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Profiles_CreatedById",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CreatedById",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "chatMessages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "chatMessages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CreatedById",
                table: "Topics",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Profiles_CreatedById",
                table: "Topics",
                column: "CreatedById",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
