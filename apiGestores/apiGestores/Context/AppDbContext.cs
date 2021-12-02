using System;
using apiGestores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiGestores.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<ArticulosDet> ArticulosDet { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<ComprasDet> ComprasDet { get; set; }
        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Fabricantes> Fabricantes { get; set; }
        public virtual DbSet<Impuestos> Impuestos { get; set; }
        public virtual DbSet<Modelos> Modelos { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<Reparaciones> Reparaciones { get; set; }
        public virtual DbSet<ReparacionesDet> ReparacionesDet { get; set; }
        public virtual DbSet<Reportes> Reportes { get; set; }
        public virtual DbSet<ReportesDet> ReportesDet { get; set; }
        public virtual DbSet<ReportesTipos> ReportesTipos { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Musica;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.ArtCodigo)
                    .HasName("PK__Articulo__D09E5E03894506EE");

                entity.Property(e => e.ArtCodigo)
                    .HasColumnName("art_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtDenom)
                    .IsRequired()
                    .HasColumnName("art_denom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__esta___5070F446");
            });

            modelBuilder.Entity<ArticulosDet>(entity =>
            {
                entity.HasKey(e => e.ArtCodigo)
                    .HasName("PK__Articulo__D09E5E0378603750");

                entity.Property(e => e.ArtCodigo)
                    .HasColumnName("art_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtColor)
                    .HasColumnName("art_color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ArtPrecio).HasColumnName("art_precio");

                entity.Property(e => e.FabCodigo).HasColumnName("fab_codigo");

                entity.Property(e => e.ModCodigo).HasColumnName("mod_codigo");

                entity.Property(e => e.ProveCodigo).HasColumnName("prove_codigo");

                entity.Property(e => e.SucCodigo).HasColumnName("suc_codigo");

                entity.HasOne(d => d.ArtCodigoNavigation)
                    .WithOne(p => p.ArticulosDet)
                    .HasForeignKey<ArticulosDet>(d => d.ArtCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__mod_c__534D60F1");

                entity.HasOne(d => d.FabCodigoNavigation)
                    .WithMany(p => p.ArticulosDet)
                    .HasForeignKey(d => d.FabCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__fab_c__5441852A");

                entity.HasOne(d => d.ModCodigoNavigation)
                    .WithMany(p => p.ArticulosDet)
                    .HasForeignKey(d => d.ModCodigo)
                    .HasConstraintName("FK__Articulos__mod_c__571DF1D5");

                entity.HasOne(d => d.ProveCodigoNavigation)
                    .WithMany(p => p.ArticulosDet)
                    .HasForeignKey(d => d.ProveCodigo)
                    .HasConstraintName("FK__Articulos__prove__5629CD9C");

                entity.HasOne(d => d.SucCodigoNavigation)
                    .WithMany(p => p.ArticulosDet)
                    .HasForeignKey(d => d.SucCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__suc_c__5535A963");
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => e.ciu_codigo)
                    .HasName("PK__Ciudades__740B50BC9C3E06CF");

                entity.Property(e => e.ciu_codigo)
                    .HasColumnName("ciu_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiuDenom)
                    .IsRequired()
                    .HasColumnName("ciu_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProvCodigo).HasColumnName("prov_codigo");

                entity.HasOne(d => d.ProvCodigoNavigation)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.ProvCodigo)
                    .HasConstraintName("FK__Ciudades__prov_c__2B3F6F97");
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.ComCodigo)
                    .HasName("PK__Compras__CC0BE5E885818236");

                entity.Property(e => e.ComCodigo)
                    .HasColumnName("com_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComFecha)
                    .HasColumnName("com_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.ComNumerofisico)
                    .HasColumnName("com_numerofisico")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComObserv)
                    .HasColumnName("com_observ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCodigo).HasColumnName("usu_codigo");

                entity.HasOne(d => d.UsuCodigoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.UsuCodigo)
                    .HasConstraintName("FK__Compras__usu_cod__619B8048");
            });

            modelBuilder.Entity<ComprasDet>(entity =>
            {
                entity.HasKey(e => e.ComCodigo)
                    .HasName("PK__ComprasD__CC0BE5E82FDD6272");

                entity.Property(e => e.ComCodigo)
                    .HasColumnName("com_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtCodigo).HasColumnName("art_codigo");

                entity.Property(e => e.ComdTotal).HasColumnName("comd_total");

                entity.Property(e => e.ImpCodigo).HasColumnName("imp_codigo");

                entity.HasOne(d => d.ArtCodigoNavigation)
                    .WithMany(p => p.ComprasDet)
                    .HasForeignKey(d => d.ArtCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ComprasDe__art_c__656C112C");

                entity.HasOne(d => d.ComCodigoNavigation)
                    .WithOne(p => p.ComprasDet)
                    .HasForeignKey<ComprasDet>(d => d.ComCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ComprasDe__comd___6477ECF3");

                entity.HasOne(d => d.ImpCodigoNavigation)
                    .WithMany(p => p.ComprasDet)
                    .HasForeignKey(d => d.ImpCodigo)
                    .HasConstraintName("FK__ComprasDe__imp_c__66603565");
            });

            modelBuilder.Entity<Cuentas>(entity =>
            {
                entity.HasKey(e => e.CueCodigo)
                    .HasName("PK__Cuentas__B1122C7724D0A108");

                entity.Property(e => e.CueCodigo)
                    .HasColumnName("cue_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiuCodigo).HasColumnName("ciu_codigo");

                entity.Property(e => e.CueCp)
                    .HasColumnName("cue_cp")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CueDenom)
                    .IsRequired()
                    .HasColumnName("cue_denom")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CueDireccion)
                    .HasColumnName("cue_direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CueMail)
                    .HasColumnName("cue_mail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CueTelefono)
                    .HasColumnName("cue_telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CueWebsite)
                    .HasColumnName("cue_website")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.HasOne(d => d.CiuCodigoNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.CiuCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cuentas__ciu_cod__4CA06362");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cuentas__esta_co__4D94879B");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.EstaCodigo)
                    .HasName("PK__Estados__E380477F2005C520");

                entity.Property(e => e.EstaCodigo)
                    .HasColumnName("esta_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaDenom)
                    .IsRequired()
                    .HasColumnName("esta_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fabricantes>(entity =>
            {
                entity.HasKey(e => e.FabCodigo)
                    .HasName("PK__Fabrican__EB587C809C973C02");

                entity.Property(e => e.FabCodigo)
                    .HasColumnName("fab_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.FabDenom)
                    .IsRequired()
                    .HasColumnName("fab_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FabFeccar)
                    .HasColumnName("fab_feccar")
                    .HasColumnType("date");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Fabricantes)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fabricant__esta___3C69FB99");
            });

            modelBuilder.Entity<Impuestos>(entity =>
            {
                entity.HasKey(e => e.ImpCodigo)
                    .HasName("PK__Impuesto__D46B2A916E977D71");

                entity.Property(e => e.ImpCodigo)
                    .HasColumnName("imp_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.ImpDenom)
                    .IsRequired()
                    .HasColumnName("imp_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ImpValor).HasColumnName("imp_valor");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Impuestos)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Impuestos__esta___4316F928");
            });

            modelBuilder.Entity<Modelos>(entity =>
            {
                entity.HasKey(e => e.ModCodigo)
                    .HasName("PK__Modelos__DD5D2196CF583B7A");

                entity.Property(e => e.ModCodigo)
                    .HasColumnName("mod_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.ModDenom)
                    .IsRequired()
                    .HasColumnName("mod_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modelos__esta_co__31EC6D26");
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.NivCodigo)
                    .HasName("PK__Niveles__E280267F6224172F");

                entity.Property(e => e.NivCodigo)
                    .HasColumnName("niv_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.NivDenom)
                    .HasColumnName("niv_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Niveles)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Niveles__esta_co__34C8D9D1");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.PaisCodigo)
                    .HasName("PK__Paises__872D88226C3917BE");

                entity.Property(e => e.PaisCodigo)
                    .HasColumnName("pais_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaisDenom)
                    .IsRequired()
                    .HasColumnName("pais_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.ProveCodigo)
                    .HasName("PK__Proveedo__E6C50B97B26ECF0C");

                entity.Property(e => e.ProveCodigo)
                    .HasColumnName("prove_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.CiuCodigo).HasColumnName("ciu_codigo");

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.ProveCp)
                    .HasColumnName("prove_cp")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProveDenom)
                    .IsRequired()
                    .HasColumnName("prove_denom")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProveDireccion)
                    .HasColumnName("prove_direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProveMail)
                    .HasColumnName("prove_mail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProveTelefono)
                    .HasColumnName("prove_telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProveWebsite)
                    .HasColumnName("prove_website")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CiuCodigoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.CiuCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__ciu_c__3F466844");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__esta___403A8C7D");
            });

            modelBuilder.Entity<Provincias>(entity =>
            {
                entity.HasKey(e => e.ProvCodigo)
                    .HasName("PK__Provinci__65092373FD312A69");

                entity.Property(e => e.ProvCodigo)
                    .HasColumnName("prov_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaisCodigo).HasColumnName("pais_codigo");

                entity.Property(e => e.ProvDenom)
                    .IsRequired()
                    .HasColumnName("prov_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PaisCodigoNavigation)
                    .WithMany(p => p.Provincias)
                    .HasForeignKey(d => d.PaisCodigo)
                    .HasConstraintName("FK__Provincia__pais___286302EC");
            });

            modelBuilder.Entity<Reparaciones>(entity =>
            {
                entity.HasKey(e => e.RepaCodigo)
                    .HasName("PK__Reparaci__481DC7E2FB77EF17");

                entity.Property(e => e.RepaCodigo)
                    .HasColumnName("repa_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.CueCodigo).HasColumnName("cue_codigo");

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.RepaFeccar)
                    .HasColumnName("repa_feccar")
                    .HasColumnType("date");

                entity.Property(e => e.RepaFeccie)
                    .HasColumnName("repa_feccie")
                    .HasColumnType("date");

                entity.Property(e => e.RepaObserv)
                    .HasColumnName("repa_observ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CueCodigoNavigation)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.CueCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reparacio__cue_c__5AEE82B9");

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Reparaciones)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reparacio__esta___59FA5E80");
            });

            modelBuilder.Entity<ReparacionesDet>(entity =>
            {
                entity.HasKey(e => e.RepaCodigo)
                    .HasName("PK__Reparaci__481DC7E2880CD0F6");

                entity.Property(e => e.RepaCodigo)
                    .HasColumnName("repa_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtCodigo).HasColumnName("art_codigo");

                entity.Property(e => e.RepadAccion)
                    .HasColumnName("repad_accion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RepadPrecio).HasColumnName("repad_precio");

                entity.HasOne(d => d.ArtCodigoNavigation)
                    .WithMany(p => p.ReparacionesDet)
                    .HasForeignKey(d => d.ArtCodigo)
                    .HasConstraintName("FK__Reparacio__art_c__5EBF139D");

                entity.HasOne(d => d.RepaCodigoNavigation)
                    .WithOne(p => p.ReparacionesDet)
                    .HasForeignKey<ReparacionesDet>(d => d.RepaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reparacio__repad__5DCAEF64");
            });

            modelBuilder.Entity<Reportes>(entity =>
            {
                entity.HasKey(e => e.RepCodigo)
                    .HasName("PK__Reportes__3EBC75FE87C6A77C");

                entity.Property(e => e.RepCodigo)
                    .HasColumnName("rep_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.RepFecha)
                    .HasColumnName("rep_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.RepObserv)
                    .HasColumnName("rep_observ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ReptipoCodigo).HasColumnName("reptipo_codigo");

                entity.Property(e => e.SucCodigo).HasColumnName("suc_codigo");

                entity.HasOne(d => d.ReptipoCodigoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.ReptipoCodigo)
                    .HasConstraintName("FK__Reportes__reptip__46E78A0C");

                entity.HasOne(d => d.SucCodigoNavigation)
                    .WithMany(p => p.Reportes)
                    .HasForeignKey(d => d.SucCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reportes__suc_co__45F365D3");
            });

            modelBuilder.Entity<ReportesDet>(entity =>
            {
                entity.HasKey(e => e.RepCodigo)
                    .HasName("PK__Reportes__3EBC75FE60BCA933");

                entity.Property(e => e.RepCodigo)
                    .HasColumnName("rep_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtCodigo).HasColumnName("art_codigo");

                entity.Property(e => e.CueCodigo).HasColumnName("cue_codigo");

                entity.Property(e => e.RepCantidad).HasColumnName("rep_cantidad");

                entity.Property(e => e.RepTotal).HasColumnName("rep_total");

                entity.HasOne(d => d.RepCodigoNavigation)
                    .WithOne(p => p.ReportesDet)
                    .HasForeignKey<ReportesDet>(d => d.RepCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportesD__rep_c__49C3F6B7");
            });

            modelBuilder.Entity<ReportesTipos>(entity =>
            {
                entity.HasKey(e => e.ReptipoCodigo)
                    .HasName("PK__Reportes__8B9E238873C7F0CC");

                entity.Property(e => e.ReptipoCodigo)
                    .HasColumnName("reptipo_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ReptipoDenom)
                    .IsRequired()
                    .HasColumnName("reptipo_denom")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursales>(entity =>
            {
                entity.HasKey(e => e.SucCodigo)
                    .HasName("PK__Sucursal__141321F478995D83");

                entity.Property(e => e.SucCodigo)
                    .HasColumnName("suc_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.SucDenom)
                    .IsRequired()
                    .HasColumnName("suc_denom")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuCodigo)
                    .HasName("PK__Usuarios__F232FBD133C255C3");

                entity.Property(e => e.UsuCodigo)
                    .HasColumnName("usu_codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstaCodigo).HasColumnName("esta_codigo");

                entity.Property(e => e.NivCodigo).HasColumnName("niv_codigo");

                entity.Property(e => e.SucCodigo).HasColumnName("suc_codigo");

                entity.Property(e => e.UsuPass)
                    .IsRequired()
                    .HasColumnName("usu_pass")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuUser)
                    .IsRequired()
                    .HasColumnName("usu_user")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstaCodigoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EstaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__esta_c__398D8EEE");

                entity.HasOne(d => d.NivCodigoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.NivCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__niv_co__38996AB5");

                entity.HasOne(d => d.SucCodigoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.SucCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__suc_co__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
