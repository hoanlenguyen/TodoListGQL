using Microsoft.EntityFrameworkCore;
using TodoListGQL.Models;

namespace TodoListGQL.Data
{
    public class ApiDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApiDbContext(DbContextOptions<ApiDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<ItemData> Items { get; set; }
        public virtual DbSet<ItemList> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            SQLitePCL.Batteries.Init();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                    .WithMany(p => p.ItemDatas)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ItemData_ItemList");
            });
        }
    }
}