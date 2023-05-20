using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Database;

public class DefaultDbContext : DbContext  {

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options){}

    public DbSet<Bookmark> Bookmarks { get; set; }
    public DbSet<Models.Entities.File> Files { get; set; }
    public DbSet<PlayList> PlayLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
    }
}