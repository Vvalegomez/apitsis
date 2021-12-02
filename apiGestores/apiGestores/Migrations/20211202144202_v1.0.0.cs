using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apiGestores.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    esta_codigo = table.Column<int>(nullable: false),
                    esta_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Estados__E380477F2005C520", x => x.esta_codigo);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    pais_codigo = table.Column<int>(nullable: false),
                    pais_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paises__872D88226C3917BE", x => x.pais_codigo);
                });

            migrationBuilder.CreateTable(
                name: "ReportesTipos",
                columns: table => new
                {
                    reptipo_codigo = table.Column<int>(nullable: false),
                    reptipo_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__8B9E238873C7F0CC", x => x.reptipo_codigo);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    suc_codigo = table.Column<int>(nullable: false),
                    suc_denom = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sucursal__141321F478995D83", x => x.suc_codigo);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    art_codigo = table.Column<int>(nullable: false),
                    art_denom = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Articulo__D09E5E03894506EE", x => x.art_codigo);
                    table.ForeignKey(
                        name: "FK__Articulos__esta___5070F446",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    fab_codigo = table.Column<int>(nullable: false),
                    fab_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    fab_feccar = table.Column<DateTime>(type: "date", nullable: true),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fabrican__EB587C809C973C02", x => x.fab_codigo);
                    table.ForeignKey(
                        name: "FK__Fabricant__esta___3C69FB99",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    imp_codigo = table.Column<int>(nullable: false),
                    imp_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    imp_valor = table.Column<int>(nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Impuesto__D46B2A916E977D71", x => x.imp_codigo);
                    table.ForeignKey(
                        name: "FK__Impuestos__esta___4316F928",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    mod_codigo = table.Column<int>(nullable: false),
                    mod_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modelos__DD5D2196CF583B7A", x => x.mod_codigo);
                    table.ForeignKey(
                        name: "FK__Modelos__esta_co__31EC6D26",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Niveles",
                columns: table => new
                {
                    niv_codigo = table.Column<int>(nullable: false),
                    niv_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Niveles__E280267F6224172F", x => x.niv_codigo);
                    table.ForeignKey(
                        name: "FK__Niveles__esta_co__34C8D9D1",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    prov_codigo = table.Column<int>(nullable: false),
                    prov_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    pais_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Provinci__65092373FD312A69", x => x.prov_codigo);
                    table.ForeignKey(
                        name: "FK__Provincia__pais___286302EC",
                        column: x => x.pais_codigo,
                        principalTable: "Paises",
                        principalColumn: "pais_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    rep_codigo = table.Column<int>(nullable: false),
                    rep_fecha = table.Column<DateTime>(type: "date", nullable: false),
                    reptipo_codigo = table.Column<int>(nullable: true),
                    rep_observ = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    suc_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__3EBC75FE87C6A77C", x => x.rep_codigo);
                    table.ForeignKey(
                        name: "FK__Reportes__reptip__46E78A0C",
                        column: x => x.reptipo_codigo,
                        principalTable: "ReportesTipos",
                        principalColumn: "reptipo_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Reportes__suc_co__45F365D3",
                        column: x => x.suc_codigo,
                        principalTable: "Sucursales",
                        principalColumn: "suc_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usu_codigo = table.Column<int>(nullable: false),
                    usu_user = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    usu_pass = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    niv_codigo = table.Column<int>(nullable: false),
                    suc_codigo = table.Column<int>(nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__F232FBD133C255C3", x => x.usu_codigo);
                    table.ForeignKey(
                        name: "FK__Usuarios__esta_c__398D8EEE",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Usuarios__niv_co__38996AB5",
                        column: x => x.niv_codigo,
                        principalTable: "Niveles",
                        principalColumn: "niv_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Usuarios__suc_co__37A5467C",
                        column: x => x.suc_codigo,
                        principalTable: "Sucursales",
                        principalColumn: "suc_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    ciu_codigo = table.Column<int>(nullable: false),
                    ciu_denom = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    prov_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ciudades__740B50BC9C3E06CF", x => x.ciu_codigo);
                    table.ForeignKey(
                        name: "FK__Ciudades__prov_c__2B3F6F97",
                        column: x => x.prov_codigo,
                        principalTable: "Provincias",
                        principalColumn: "prov_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportesDet",
                columns: table => new
                {
                    rep_codigo = table.Column<int>(nullable: false),
                    art_codigo = table.Column<int>(nullable: false),
                    cue_codigo = table.Column<int>(nullable: false),
                    rep_cantidad = table.Column<int>(nullable: true),
                    rep_total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reportes__3EBC75FE60BCA933", x => x.rep_codigo);
                    table.ForeignKey(
                        name: "FK__ReportesD__rep_c__49C3F6B7",
                        column: x => x.rep_codigo,
                        principalTable: "Reportes",
                        principalColumn: "rep_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    com_codigo = table.Column<int>(nullable: false),
                    com_numerofisico = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    com_observ = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    com_fecha = table.Column<DateTime>(type: "date", nullable: true),
                    usu_codigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compras__CC0BE5E885818236", x => x.com_codigo);
                    table.ForeignKey(
                        name: "FK__Compras__usu_cod__619B8048",
                        column: x => x.usu_codigo,
                        principalTable: "Usuarios",
                        principalColumn: "usu_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    cue_codigo = table.Column<int>(nullable: false),
                    cue_denom = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    cue_website = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cue_telefono = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    cue_mail = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    cue_direccion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    cue_cp = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    ciu_codigo = table.Column<int>(nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cuentas__B1122C7724D0A108", x => x.cue_codigo);
                    table.ForeignKey(
                        name: "FK__Cuentas__ciu_cod__4CA06362",
                        column: x => x.ciu_codigo,
                        principalTable: "Ciudades",
                        principalColumn: "ciu_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Cuentas__esta_co__4D94879B",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    prove_codigo = table.Column<int>(nullable: false),
                    prove_denom = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    prove_website = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prove_telefono = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    prove_mail = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    prove_direccion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    prove_cp = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    ciu_codigo = table.Column<int>(nullable: false),
                    esta_codigo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__E6C50B97B26ECF0C", x => x.prove_codigo);
                    table.ForeignKey(
                        name: "FK__Proveedor__ciu_c__3F466844",
                        column: x => x.ciu_codigo,
                        principalTable: "Ciudades",
                        principalColumn: "ciu_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Proveedor__esta___403A8C7D",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDet",
                columns: table => new
                {
                    com_codigo = table.Column<int>(nullable: false),
                    art_codigo = table.Column<int>(nullable: false),
                    imp_codigo = table.Column<int>(nullable: true),
                    comd_total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ComprasD__CC0BE5E82FDD6272", x => x.com_codigo);
                    table.ForeignKey(
                        name: "FK__ComprasDe__art_c__656C112C",
                        column: x => x.art_codigo,
                        principalTable: "Articulos",
                        principalColumn: "art_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ComprasDe__comd___6477ECF3",
                        column: x => x.com_codigo,
                        principalTable: "Compras",
                        principalColumn: "com_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ComprasDe__imp_c__66603565",
                        column: x => x.imp_codigo,
                        principalTable: "Impuestos",
                        principalColumn: "imp_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reparaciones",
                columns: table => new
                {
                    repa_codigo = table.Column<int>(nullable: false),
                    repa_feccar = table.Column<DateTime>(type: "date", nullable: false),
                    repa_feccie = table.Column<DateTime>(type: "date", nullable: false),
                    cue_codigo = table.Column<int>(nullable: false),
                    esta_codigo = table.Column<int>(nullable: false),
                    repa_observ = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reparaci__481DC7E2FB77EF17", x => x.repa_codigo);
                    table.ForeignKey(
                        name: "FK__Reparacio__cue_c__5AEE82B9",
                        column: x => x.cue_codigo,
                        principalTable: "Cuentas",
                        principalColumn: "cue_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Reparacio__esta___59FA5E80",
                        column: x => x.esta_codigo,
                        principalTable: "Estados",
                        principalColumn: "esta_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosDet",
                columns: table => new
                {
                    art_codigo = table.Column<int>(nullable: false),
                    art_color = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    art_precio = table.Column<int>(nullable: true),
                    fab_codigo = table.Column<int>(nullable: false),
                    suc_codigo = table.Column<int>(nullable: false),
                    prove_codigo = table.Column<int>(nullable: true),
                    mod_codigo = table.Column<int>(nullable: true),
                    ArticulosArtCodigo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Articulo__D09E5E0378603750", x => x.art_codigo);
                    table.ForeignKey(
                        name: "FK__Articulos__mod_c__534D60F1",
                        column: x => x.art_codigo,
                        principalTable: "Articulos",
                        principalColumn: "art_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticulosDet_Articulos_ArticulosArtCodigo",
                        column: x => x.ArticulosArtCodigo,
                        principalTable: "Articulos",
                        principalColumn: "art_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Articulos__fab_c__5441852A",
                        column: x => x.fab_codigo,
                        principalTable: "Fabricantes",
                        principalColumn: "fab_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Articulos__mod_c__571DF1D5",
                        column: x => x.mod_codigo,
                        principalTable: "Modelos",
                        principalColumn: "mod_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Articulos__prove__5629CD9C",
                        column: x => x.prove_codigo,
                        principalTable: "Proveedores",
                        principalColumn: "prove_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Articulos__suc_c__5535A963",
                        column: x => x.suc_codigo,
                        principalTable: "Sucursales",
                        principalColumn: "suc_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReparacionesDet",
                columns: table => new
                {
                    repa_codigo = table.Column<int>(nullable: false),
                    art_codigo = table.Column<int>(nullable: true),
                    repad_precio = table.Column<int>(nullable: true),
                    repad_accion = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reparaci__481DC7E2880CD0F6", x => x.repa_codigo);
                    table.ForeignKey(
                        name: "FK__Reparacio__art_c__5EBF139D",
                        column: x => x.art_codigo,
                        principalTable: "Articulos",
                        principalColumn: "art_codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Reparacio__repad__5DCAEF64",
                        column: x => x.repa_codigo,
                        principalTable: "Reparaciones",
                        principalColumn: "repa_codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_esta_codigo",
                table: "Articulos",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosDet_ArticulosArtCodigo",
                table: "ArticulosDet",
                column: "ArticulosArtCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosDet_fab_codigo",
                table: "ArticulosDet",
                column: "fab_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosDet_mod_codigo",
                table: "ArticulosDet",
                column: "mod_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosDet_prove_codigo",
                table: "ArticulosDet",
                column: "prove_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosDet_suc_codigo",
                table: "ArticulosDet",
                column: "suc_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_prov_codigo",
                table: "Ciudades",
                column: "prov_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_usu_codigo",
                table: "Compras",
                column: "usu_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDet_art_codigo",
                table: "ComprasDet",
                column: "art_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDet_imp_codigo",
                table: "ComprasDet",
                column: "imp_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ciu_codigo",
                table: "Cuentas",
                column: "ciu_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_esta_codigo",
                table: "Cuentas",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricantes_esta_codigo",
                table: "Fabricantes",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Impuestos_esta_codigo",
                table: "Impuestos",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_esta_codigo",
                table: "Modelos",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Niveles_esta_codigo",
                table: "Niveles",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_ciu_codigo",
                table: "Proveedores",
                column: "ciu_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_esta_codigo",
                table: "Proveedores",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_pais_codigo",
                table: "Provincias",
                column: "pais_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_cue_codigo",
                table: "Reparaciones",
                column: "cue_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reparaciones_esta_codigo",
                table: "Reparaciones",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ReparacionesDet_art_codigo",
                table: "ReparacionesDet",
                column: "art_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_reptipo_codigo",
                table: "Reportes",
                column: "reptipo_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_suc_codigo",
                table: "Reportes",
                column: "suc_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_esta_codigo",
                table: "Usuarios",
                column: "esta_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_niv_codigo",
                table: "Usuarios",
                column: "niv_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_suc_codigo",
                table: "Usuarios",
                column: "suc_codigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosDet");

            migrationBuilder.DropTable(
                name: "ComprasDet");

            migrationBuilder.DropTable(
                name: "ReparacionesDet");

            migrationBuilder.DropTable(
                name: "ReportesDet");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Impuestos");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Reparaciones");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "ReportesTipos");

            migrationBuilder.DropTable(
                name: "Niveles");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
