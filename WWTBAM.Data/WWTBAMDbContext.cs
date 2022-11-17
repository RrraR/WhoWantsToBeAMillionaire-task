using Microsoft.EntityFrameworkCore;
using WWTBAM.Data.Entities;

namespace WWTBAM.Data;

public class WWTBAMDbContext : DbContext
{
    //EF core configurations. This project uses 3 tables: Questions, Answers and QuestionLevel.
    //Tables Answers and Questions are linked with QuestionId foreign key from table answers to table questions
    //tables Questions and QuestionLevels are linked with foreign key from table questions to table questionlevels
    //configuartions made using fluent API
    public DbSet<QuestionEntity> Questions { get; set; }
    public DbSet<AnswersEntity> Answers { get; set; }
    public DbSet<QuestionLevelEntity> QuestionLevel { get; set; }

    public WWTBAMDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<QuestionEntity>().ToTable("Questions");
        builder.Entity<QuestionEntity>().HasKey(t => t.QuestionId);

        builder.Entity<AnswersEntity>().ToTable("Answers");
        builder.Entity<AnswersEntity>().HasKey(t => t.AnswerId);

        builder.Entity<QuestionLevelEntity>().ToTable("QuestionLevel");
        builder.Entity<QuestionLevelEntity>().HasKey(t => t.LevelId);

        builder.Entity<QuestionLevelEntity>()
            .HasMany(q => q.QuestionsOfLevel)
            .WithOne(q => q.QuestionToLevel);

        builder.Entity<QuestionEntity>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question);


        base.OnModelCreating(builder);
    }
}