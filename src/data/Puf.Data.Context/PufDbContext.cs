using Microsoft.EntityFrameworkCore;
using Puf.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puf.Data.Context
{
    public class PufDbContext : DbContext
    {
        public PufDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleExam> ArticleExams { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<SocialType> SocialTypes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
