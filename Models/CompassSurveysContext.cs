using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompassSurveys.Models
{
    public partial class CompassSurveysContext : DbContext
    {
        public CompassSurveysContext()
        {
        }

        public CompassSurveysContext(DbContextOptions<CompassSurveysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
