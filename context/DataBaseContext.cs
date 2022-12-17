using Microsoft.EntityFrameworkCore;

public class DataBaseContext : DbContext 
{
    public DataBaseContext(DbContextOptions options) : base(options){

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){

    }


    //entities
    public DbSet<Lot>? lot {get; set;}
    
}