using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialApp.Datalayer.Entities;
using TutorialApp.Datalayer.Entities.User;

namespace TutorialApp.Datalayer.Context
{
    public class TutorialAppContext : DbContext
    {
        public TutorialAppContext(DbContextOptions<TutorialAppContext>options):base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Choice> Choices { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
