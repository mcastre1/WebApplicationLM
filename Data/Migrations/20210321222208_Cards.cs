using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationLM.Data.Migrations
{
    public partial class Cards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workspace",
                columns: table => new
                {
                    WorkspaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspace", x => x.WorkspaceId);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    ColumnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkspaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.ColumnId);
                    table.ForeignKey(
                        name: "FK_Column_Workspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspace",
                        principalColumn: "WorkspaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColumnId = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Card_Column_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Column",
                        principalColumn: "ColumnId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_ColumnId",
                table: "Card",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_WorkspaceId",
                table: "Column",
                column: "WorkspaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "Workspace");
        }
    }
}
