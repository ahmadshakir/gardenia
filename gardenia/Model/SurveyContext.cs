using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gardenia.Model;

public partial class SurveyContext : DbContext
{
    public SurveyContext()
    {
    }

    public SurveyContext(DbContextOptions<SurveyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=Survey;Persist Security Info=True;User ID=sa;Password=reallyStrongPwd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Survey>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubmitTime)
                .HasColumnType("datetime")
                .HasColumnName("submit_time");
        });

        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.SurveysFk).HasColumnName("surveys_fk");

            //entity.HasOne(d => d.SurveysFkNavigation).WithMany(p => p.SurveyAnswers)
            //    .HasForeignKey(d => d.SurveysFk)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_SurveyAnswers_Surveys");
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
