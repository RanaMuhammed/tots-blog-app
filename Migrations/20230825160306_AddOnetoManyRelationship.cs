using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tots.Migrations
{
    /// <inheritdoc />
    public partial class AddOnetoManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Tots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tots_GenreId",
                table: "Tots",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tots_Genres_GenreId",
                table: "Tots",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tots_Genres_GenreId",
                table: "Tots");

            migrationBuilder.DropIndex(
                name: "IX_Tots_GenreId",
                table: "Tots");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Tots");
        }
    }
}
