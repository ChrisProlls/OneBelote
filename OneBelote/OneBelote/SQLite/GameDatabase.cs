using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using OneBelote.Model;
using System.Linq;
using System.Threading.Tasks;

namespace OneBelote.SQLite
{
    public class GameDatabase : DbContext
    {
        public GameDatabase()
        {
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("OneBeloteSQLite.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }

        public DbSet<Score> Score { get; set; }
        
        public async Task SaveScore(Score score)
        {
            if (score.Id == 0)
                await this.Score.AddAsync(score);
            
            await this.SaveChangesAsync();
        }        
    }
}
