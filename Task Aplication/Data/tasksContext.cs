using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Task_Aplication.Models.DataBase
{
    public partial class tasksContext : DbContext
    {
        public tasksContext()
        {
        }

        public tasksContext(DbContextOptions<tasksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tasks");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Idtask)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idtask");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.Property(e => e.Infotask)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("infotask");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("fk_iduser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("pk_iduser");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "UQ__users__AB6E6164BF0BA6B7")
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
