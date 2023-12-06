using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedDietIdtoMealEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Meals_MealEntityId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealEntityId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealEntityId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "MealEntityId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealEntityId",
                table: "Recipes",
                column: "MealEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Meals_MealEntityId",
                table: "Recipes",
                column: "MealEntityId",
                principalTable: "Meals",
                principalColumn: "Id");
        }
    }
}
