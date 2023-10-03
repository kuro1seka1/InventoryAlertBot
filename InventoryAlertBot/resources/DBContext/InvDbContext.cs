using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryAlertBot.resources.DBContext;

public partial class InvDbContext : DbContext
{
    public InvDbContext()
    {
    }

    public InvDbContext(DbContextOptions<InvDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Filial> Filials { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Inventtype> Inventtypes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=95.107.53.93;Port=5848;Database=InvDB;User Id=nmt_vbot;Password=dVbbz9*~qU7C;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Cabinetid).HasName("cabinets_pkey");

            entity.ToTable("cabinets");

            entity.Property(e => e.Cabinetid).HasColumnName("cabinetid");
            entity.Property(e => e.Cabinetname)
                .HasMaxLength(250)
                .HasColumnName("cabinetname");
        });

        modelBuilder.Entity<Filial>(entity =>
        {
            entity.HasKey(e => e.Filialid).HasName("filials_pkey");

            entity.ToTable("filials");

            entity.Property(e => e.Filialid)
                .ValueGeneratedNever()
                .HasColumnName("filialid");
            entity.Property(e => e.Filialname)
                .HasColumnType("character varying")
                .HasColumnName("filialname");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Historyid).HasName("history_pkey");

            entity.ToTable("history");

            entity.Property(e => e.Historyid).HasColumnName("historyid");
            entity.Property(e => e.Historydata)
                .HasMaxLength(250)
                .HasColumnName("historydata");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Inventid).HasName("Invent_pk");

            entity.ToTable("inventory");

            entity.Property(e => e.Inventid).HasColumnName("inventid");
            entity.Property(e => e.Cabinetid).HasColumnName("cabinetid");
            entity.Property(e => e.Datenextpov).HasColumnName("datenextpov");
            entity.Property(e => e.Datepov).HasColumnName("datepov");
            entity.Property(e => e.Filialid).HasColumnName("filialid");
            entity.Property(e => e.Inventname)
                .HasColumnType("character varying")
                .HasColumnName("inventname");
            entity.Property(e => e.Inventtype).HasColumnName("inventtype");
            entity.Property(e => e.Serialnum)
                .HasColumnType("character varying")
                .HasColumnName("serialnum");
            entity.Property(e => e.Servicedate).HasColumnName("servicedate");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Servicenextdate).HasColumnName("servicenextdate");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Yearofman).HasColumnName("yearofman");

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Cabinetid)
                .HasConstraintName("cabinet_fk");

            entity.HasOne(d => d.Filial).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Filialid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("filial_fk");

            entity.HasOne(d => d.InventtypeNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Inventtype)
                .HasConstraintName("inventtype_fk");

            entity.HasOne(d => d.Service).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Serviceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("status_fk");
        });

        modelBuilder.Entity<Inventtype>(entity =>
        {
            entity.HasKey(e => e.Inventtypeid).HasName("inventtype_pkey");

            entity.ToTable("inventtype");

            entity.Property(e => e.Inventtypeid).HasColumnName("inventtypeid");
            entity.Property(e => e.Inventname)
                .HasMaxLength(250)
                .HasColumnName("inventname");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Servicename)
                .HasMaxLength(250)
                .HasColumnName("servicename");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Statusname)
                .HasMaxLength(250)
                .HasColumnName("statusname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
