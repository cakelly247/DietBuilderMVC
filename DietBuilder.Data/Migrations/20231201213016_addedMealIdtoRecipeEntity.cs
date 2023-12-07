using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedMealIdtoRecipeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealEntityId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "DietId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
