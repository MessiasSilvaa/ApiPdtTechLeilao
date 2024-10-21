using Microsoft.EntityFrameworkCore.Migrations;


namespace ApiPdtTechLeilao.Migrations
{
    /// <inheritdoc />
    public partial class AddStartBuildingAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Allotments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "StartBuilding",
                table: "Allotments",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Allotments");

            migrationBuilder.DropColumn(
                name: "StartBuilding",
                table: "Allotments");
        }
    }
}
