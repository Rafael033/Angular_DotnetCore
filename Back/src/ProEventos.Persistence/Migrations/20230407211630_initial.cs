using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalestrantesEventos",
                columns: table => new
                {
                    IdPalestrante = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEvento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestrantesEventos", x => new { x.IdEvento, x.IdPalestrante });
                });

            migrationBuilder.CreateTable(
                name: "RedeSocials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    IdEvento = table.Column<int>(type: "INTEGER", nullable: true),
                    IdPalestrantes = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeSocials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Theme = table.Column<string>(type: "TEXT", nullable: true),
                    Locality = table.Column<string>(type: "TEXT", nullable: true),
                    Lote = table.Column<int>(type: "INTEGER", nullable: false),
                    QdtPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    DataEvento = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PalestranteEventoIdEvento = table.Column<int>(type: "INTEGER", nullable: true),
                    PalestranteEventoIdPalestrante = table.Column<int>(type: "INTEGER", nullable: true),
                    RedeSocialId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_PalestrantesEventos_PalestranteEventoIdEvento_PalestranteEventoIdPalestrante",
                        columns: x => new { x.PalestranteEventoIdEvento, x.PalestranteEventoIdPalestrante },
                        principalTable: "PalestrantesEventos",
                        principalColumns: new[] { "IdEvento", "IdPalestrante" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_RedeSocials_RedeSocialId",
                        column: x => x.RedeSocialId,
                        principalTable: "RedeSocials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEvento = table.Column<int>(type: "INTEGER", nullable: false),
                    EventosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lotes_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palestrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SmallCV = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Cellphone = table.Column<int>(type: "INTEGER", nullable: false),
                    EventoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestrantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palestrantes_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PalestrantePalestranteEvento",
                columns: table => new
                {
                    PalestranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PalestrantesEventosIdEvento = table.Column<int>(type: "INTEGER", nullable: false),
                    PalestrantesEventosIdPalestrante = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestrantePalestranteEvento", x => new { x.PalestranteId, x.PalestrantesEventosIdEvento, x.PalestrantesEventosIdPalestrante });
                    table.ForeignKey(
                        name: "FK_PalestrantePalestranteEvento_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestrantePalestranteEvento_PalestrantesEventos_PalestrantesEventosIdEvento_PalestrantesEventosIdPalestrante",
                        columns: x => new { x.PalestrantesEventosIdEvento, x.PalestrantesEventosIdPalestrante },
                        principalTable: "PalestrantesEventos",
                        principalColumns: new[] { "IdEvento", "IdPalestrante" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PalestranteRedeSocial",
                columns: table => new
                {
                    PalestrantesId = table.Column<int>(type: "INTEGER", nullable: false),
                    RedesSocialsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestranteRedeSocial", x => new { x.PalestrantesId, x.RedesSocialsId });
                    table.ForeignKey(
                        name: "FK_PalestranteRedeSocial_Palestrantes_PalestrantesId",
                        column: x => x.PalestrantesId,
                        principalTable: "Palestrantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestranteRedeSocial_RedeSocials_RedesSocialsId",
                        column: x => x.RedesSocialsId,
                        principalTable: "RedeSocials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PalestranteEventoIdEvento_PalestranteEventoIdPalestrante",
                table: "Eventos",
                columns: new[] { "PalestranteEventoIdEvento", "PalestranteEventoIdPalestrante" });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RedeSocialId",
                table: "Eventos",
                column: "RedeSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_EventosId",
                table: "Lotes",
                column: "EventosId");

            migrationBuilder.CreateIndex(
                name: "IX_PalestrantePalestranteEvento_PalestrantesEventosIdEvento_PalestrantesEventosIdPalestrante",
                table: "PalestrantePalestranteEvento",
                columns: new[] { "PalestrantesEventosIdEvento", "PalestrantesEventosIdPalestrante" });

            migrationBuilder.CreateIndex(
                name: "IX_PalestranteRedeSocial_RedesSocialsId",
                table: "PalestranteRedeSocial",
                column: "RedesSocialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Palestrantes_EventoId",
                table: "Palestrantes",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "PalestrantePalestranteEvento");

            migrationBuilder.DropTable(
                name: "PalestranteRedeSocial");

            migrationBuilder.DropTable(
                name: "Palestrantes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "PalestrantesEventos");

            migrationBuilder.DropTable(
                name: "RedeSocials");
        }
    }
}
