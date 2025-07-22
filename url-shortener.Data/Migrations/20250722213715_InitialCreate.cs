using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace url_shortener.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LINK",
                columns: table => new
                {
                    ID_LINK = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_ORIGINAL_URL = table.Column<string>(type: "varchar(500)", nullable: false),
                    DS_SHORTENED_URL = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LINK", x => x.ID_LINK);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LINK");
        }
    }
}
