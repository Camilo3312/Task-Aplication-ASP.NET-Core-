using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Task_Aplication.Models.DataBase;

#nullable disable

namespace Task_Aplication.Data
{
    public partial class dbtasksContext : DbContext
    {
        public dbtasksContext()
        {
        }

        public dbtasksContext(DbContextOptions<dbtasksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=dbtasks.mssql.somee.com; Database=dbtasks; user id=workfhours1_SQLLogin_1; pwd=camilo312; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.Idtask);

                entity.ToTable("tasks");

                entity.Property(e => e.Idtask).HasColumnName("idtask");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Infotask)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("infotask");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("fk_iduser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("pk_iduser");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E6164058589D2")
                    .IsUnique();

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ImageProfile)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("image_profile");

                entity.Property(e => e.Names)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("names");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rol")
                    .HasDefaultValueSql("('USER')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
