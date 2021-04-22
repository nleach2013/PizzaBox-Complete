using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class changestoreordersdata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizza_Crust_CrustEntityId",
                table: "APizza");

            migrationBuilder.DropForeignKey(
                name: "FK_APizza_Size_SizeEntityId",
                table: "APizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_APizza_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AStore_StoreEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_APizza_APizzaEntityId",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AStore",
                table: "AStore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_APizza",
                table: "APizza");

            migrationBuilder.RenameTable(
                name: "AStore",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "APizza",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_APizza_SizeEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_SizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_APizza_CrustEntityId",
                table: "Pizzas",
                newName: "IX_Pizzas_CrustEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreEntityId",
                table: "Order",
                column: "StoreEntityId",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId",
                table: "Pizzas",
                column: "SizeEntityId",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityId",
                table: "Topping",
                column: "APizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pizzas_PizzaEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crust_CrustEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Size_SizeEntityId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityId",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "AStore");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "APizza");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_SizeEntityId",
                table: "APizza",
                newName: "IX_APizza_SizeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "APizza",
                newName: "IX_APizza_CrustEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AStore",
                table: "AStore",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APizza",
                table: "APizza",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizza_Crust_CrustEntityId",
                table: "APizza",
                column: "CrustEntityId",
                principalTable: "Crust",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APizza_Size_SizeEntityId",
                table: "APizza",
                column: "SizeEntityId",
                principalTable: "Size",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_APizza_PizzaEntityId",
                table: "Order",
                column: "PizzaEntityId",
                principalTable: "APizza",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AStore_StoreEntityId",
                table: "Order",
                column: "StoreEntityId",
                principalTable: "AStore",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_APizza_APizzaEntityId",
                table: "Topping",
                column: "APizzaEntityId",
                principalTable: "APizza",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
