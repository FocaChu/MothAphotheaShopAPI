using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MothAphotheaShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aromas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contraindications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contraindications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlavorNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorNotes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Textures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Textures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActiveCompounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChemicalFormula = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EffectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveCompounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveCompounds_Effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effects",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    Origin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaffeineLevel = table.Column<int>(type: "int", nullable: false),
                    Preparation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveCompoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ActiveCompounds_ActiveCompoundId",
                        column: x => x.ActiveCompoundId,
                        principalTable: "ActiveCompounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_productTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "productTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AromaProduct",
                columns: table => new
                {
                    AromasId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AromaProduct", x => new { x.AromasId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_AromaProduct_Aromas_AromasId",
                        column: x => x.AromasId,
                        principalTable: "Aromas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AromaProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContraindicationProduct",
                columns: table => new
                {
                    ContraindicationsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraindicationProduct", x => new { x.ContraindicationsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ContraindicationProduct_Contraindications_ContraindicationsId",
                        column: x => x.ContraindicationsId,
                        principalTable: "Contraindications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContraindicationProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EffectProduct",
                columns: table => new
                {
                    EffectsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectProduct", x => new { x.EffectsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_EffectProduct_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EffectProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlavorNoteProduct",
                columns: table => new
                {
                    FlavorNotesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorNoteProduct", x => new { x.FlavorNotesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_FlavorNoteProduct_FlavorNotes_FlavorNotesId",
                        column: x => x.FlavorNotesId,
                        principalTable: "FlavorNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorNoteProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ScientificName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveCompoundId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_ActiveCompounds_ActiveCompoundId",
                        column: x => x.ActiveCompoundId,
                        principalTable: "ActiveCompounds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingredients_IngredientTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "IngredientTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductTexture",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TexturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTexture", x => new { x.ProductsId, x.TexturesId });
                    table.ForeignKey(
                        name: "FK_ProductTexture_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTexture_Textures_TexturesId",
                        column: x => x.TexturesId,
                        principalTable: "Textures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AromaIngredient",
                columns: table => new
                {
                    AromasId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AromaIngredient", x => new { x.AromasId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_AromaIngredient_Aromas_AromasId",
                        column: x => x.AromasId,
                        principalTable: "Aromas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AromaIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContraindicationIngredient",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WarningsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraindicationIngredient", x => new { x.IngredientsId, x.WarningsId });
                    table.ForeignKey(
                        name: "FK_ContraindicationIngredient_Contraindications_WarningsId",
                        column: x => x.WarningsId,
                        principalTable: "Contraindications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContraindicationIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EffectIngredient",
                columns: table => new
                {
                    EffectsId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectIngredient", x => new { x.EffectsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_EffectIngredient_Effects_EffectsId",
                        column: x => x.EffectsId,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EffectIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FlavorNoteIngredient",
                columns: table => new
                {
                    FlavorProfileId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlavorNoteIngredient", x => new { x.FlavorProfileId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_FlavorNoteIngredient_FlavorNotes_FlavorProfileId",
                        column: x => x.FlavorProfileId,
                        principalTable: "FlavorNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlavorNoteIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientTexture",
                columns: table => new
                {
                    IngredientsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TexturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTexture", x => new { x.IngredientsId, x.TexturesId });
                    table.ForeignKey(
                        name: "FK_IngredientTexture_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientTexture_Textures_TexturesId",
                        column: x => x.TexturesId,
                        principalTable: "Textures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveCompounds_EffectId",
                table: "ActiveCompounds",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_AromaIngredient_IngredientsId",
                table: "AromaIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_AromaProduct_ProductsId",
                table: "AromaProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContraindicationIngredient_WarningsId",
                table: "ContraindicationIngredient",
                column: "WarningsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContraindicationProduct_ProductsId",
                table: "ContraindicationProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_EffectIngredient_IngredientsId",
                table: "EffectIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_EffectProduct_ProductsId",
                table: "EffectProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorNoteIngredient_IngredientsId",
                table: "FlavorNoteIngredient",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlavorNoteProduct_ProductsId",
                table: "FlavorNoteProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ActiveCompoundId",
                table: "Ingredients",
                column: "ActiveCompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ProductId",
                table: "Ingredients",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_TypeId",
                table: "Ingredients",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTexture_TexturesId",
                table: "IngredientTexture",
                column: "TexturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ActiveCompoundId",
                table: "Products",
                column: "ActiveCompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTexture_TexturesId",
                table: "ProductTexture",
                column: "TexturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AromaIngredient");

            migrationBuilder.DropTable(
                name: "AromaProduct");

            migrationBuilder.DropTable(
                name: "ContraindicationIngredient");

            migrationBuilder.DropTable(
                name: "ContraindicationProduct");

            migrationBuilder.DropTable(
                name: "EffectIngredient");

            migrationBuilder.DropTable(
                name: "EffectProduct");

            migrationBuilder.DropTable(
                name: "FlavorNoteIngredient");

            migrationBuilder.DropTable(
                name: "FlavorNoteProduct");

            migrationBuilder.DropTable(
                name: "IngredientTexture");

            migrationBuilder.DropTable(
                name: "ProductTexture");

            migrationBuilder.DropTable(
                name: "Aromas");

            migrationBuilder.DropTable(
                name: "Contraindications");

            migrationBuilder.DropTable(
                name: "FlavorNotes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Textures");

            migrationBuilder.DropTable(
                name: "IngredientTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ActiveCompounds");

            migrationBuilder.DropTable(
                name: "productTypes");

            migrationBuilder.DropTable(
                name: "Effects");
        }
    }
}
