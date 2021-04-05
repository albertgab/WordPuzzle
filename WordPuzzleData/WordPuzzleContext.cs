using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WordPuzzleData
{
    public partial class WordPuzzleContext : DbContext
    {
        public WordPuzzleContext()
        {
        }

        public WordPuzzleContext(DbContextOptions<WordPuzzleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Solution> Solutions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = WordPuzzle; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.DateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Levels");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History_Users");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.Letters)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.HasIndex(e => new { e.LevelId, e.Word }, "UQ__Solution__80AB6C176EC0AD62")
                    .IsUnique();

                entity.Property(e => e.SolutionId).HasColumnName("SolutionID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Solutions)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solutions_Levels");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D105349104BCD3")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Country)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Unknown')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
