using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server_side_pagination.Models;

public partial class EmpwageContext : DbContext
{
    public EmpwageContext()
    {
    }

    public EmpwageContext(DbContextOptions<EmpwageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Salary> Salaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC0511\\MSSQL2019;Database=Empwage;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Salary__CA1E5D786056563F");

            entity.ToTable("Salary");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
