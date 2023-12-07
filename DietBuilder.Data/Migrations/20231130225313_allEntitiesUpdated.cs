using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietBuilder.Data.Migrations
{
    /// <inheritdoc />
    public partial class allEntitiesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_UserEntityId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Diets_DietId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DietId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Meals_UserEntityId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "DietId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Ingredients");

            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Recipes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "DietId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DietId",
                table: "Users",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserEntityId",
                table: "Meals",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserEntityId",
                table: "Meals",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Diets_DietId",
                table: "Users",
                column: "DietId",
                principalTable: "Diets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
