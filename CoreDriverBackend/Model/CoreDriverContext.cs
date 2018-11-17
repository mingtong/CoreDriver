using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreDriverBackend.Model
{
    public partial class CoreDriverContext : DbContext
    {
        public CoreDriverContext()
        {
        }

        public CoreDriverContext(DbContextOptions<CoreDriverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoreActress> CoreActress { get; set; }
        public virtual DbSet<CoreVideo> CoreVideo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = DataSource//CoreDriver.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreActress>(entity =>
            {
                entity.HasKey(e => e.NameCn);

                entity.Property(e => e.NameCn).ValueGeneratedNever();
            });

            modelBuilder.Entity<CoreVideo>(entity =>
            {
                entity.HasKey(e => e.WholeSerial);

                entity.Property(e => e.WholeSerial).ValueGeneratedNever();

                entity.Property(e => e.ActressName).IsRequired();

                entity.Property(e => e.Prefix).IsRequired();
            });
        }
    }
}
