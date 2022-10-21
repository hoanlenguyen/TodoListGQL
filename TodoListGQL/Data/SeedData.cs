using Microsoft.EntityFrameworkCore;
using TodoListGQL.Models;

namespace TodoListGQL.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApiDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiDbContext>>(),
                serviceProvider.GetRequiredService<IConfiguration>()))
            {
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lists.AddRange(
                    new ItemList
                    {
                        Name = "ItemList I",
                        ItemDatas = new List<ItemData> {
                            new ItemData { Title ="Title1", Description = "Desc1",Done = false  },
                            new ItemData { Title ="Title2", Description = "Desc2",Done = true  },
                        }
                    },
                    new ItemList
                    {
                        Name = "ItemList II",
                        ItemDatas = new List<ItemData> {
                        new ItemData { Title ="TitleII_1", Description = "Desc1",Done = false  },
                        new ItemData { Title ="TitleII_2", Description = "Desc2",Done = true  },
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}