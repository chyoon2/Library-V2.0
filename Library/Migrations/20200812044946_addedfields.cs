using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addedfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts");

            migrationBuilder.DropIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Checkouts");

            migrationBuilder.RenameColumn(
                name: "Due",
                table: "Copies",
                newName: "DueDate");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "Copies",
                newName: "IsCheckedOut");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCheckedOut",
                table: "Copies",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Copies",
                newName: "Due");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Checkouts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_BookId",
                table: "Checkouts",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_Books_BookId",
                table: "Checkouts",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
