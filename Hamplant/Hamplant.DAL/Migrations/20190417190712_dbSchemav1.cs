using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hamplant.DAL.Migrations
{
    public partial class dbSchemav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Percentage = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: true),
                    Weight = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplyCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplyType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastWriteTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplyTypeDefinition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SupplyTypeId = table.Column<Guid>(nullable: false),
                    SupplyCategoryId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyTypeDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyTypeDefinition_SupplyCategory_SupplyCategoryId",
                        column: x => x.SupplyCategoryId,
                        principalTable: "SupplyCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyTypeDefinition_SupplyType_SupplyTypeId",
                        column: x => x.SupplyTypeId,
                        principalTable: "SupplyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bucket",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: false),
                    LastWriteTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bucket_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMemeber",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMemeber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMemeber_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMemeber_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SupplyStatus = table.Column<int>(nullable: false),
                    SupplyTypeId = table.Column<Guid>(nullable: false),
                    NumberOfSuppliesId = table.Column<Guid>(nullable: false),
                    isRequired = table.Column<bool>(nullable: false),
                    DaysToExpiration = table.Column<int>(nullable: false),
                    LastWriteTime = table.Column<DateTimeOffset>(nullable: false),
                    BucketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supply_Bucket_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Bucket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_MeasurementValue_NumberOfSuppliesId",
                        column: x => x.NumberOfSuppliesId,
                        principalTable: "MeasurementValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_SupplyType_SupplyTypeId",
                        column: x => x.SupplyTypeId,
                        principalTable: "SupplyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    SupplyStatus = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false),
                    NumberOfProductId = table.Column<Guid>(nullable: false),
                    LastWriteTime = table.Column<DateTimeOffset>(nullable: false),
                    SupplyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_MeasurementValue_NumberOfProductId",
                        column: x => x.NumberOfProductId,
                        principalTable: "MeasurementValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supply_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bucket_TeamId",
                table: "Bucket",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_NumberOfProductId",
                table: "Product",
                column: "NumberOfProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplyId",
                table: "Product",
                column: "SupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_BucketId",
                table: "Supply",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_NumberOfSuppliesId",
                table: "Supply",
                column: "NumberOfSuppliesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supply_SupplyTypeId",
                table: "Supply",
                column: "SupplyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyTypeDefinition_SupplyCategoryId",
                table: "SupplyTypeDefinition",
                column: "SupplyCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyTypeDefinition_SupplyTypeId",
                table: "SupplyTypeDefinition",
                column: "SupplyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemeber_TeamId",
                table: "TeamMemeber",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemeber_UserId",
                table: "TeamMemeber",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SupplyTypeDefinition");

            migrationBuilder.DropTable(
                name: "TeamMemeber");

            migrationBuilder.DropTable(
                name: "Supply");

            migrationBuilder.DropTable(
                name: "SupplyCategory");

            migrationBuilder.DropTable(
                name: "Bucket");

            migrationBuilder.DropTable(
                name: "MeasurementValue");

            migrationBuilder.DropTable(
                name: "SupplyType");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
