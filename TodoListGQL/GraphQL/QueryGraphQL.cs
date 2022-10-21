using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL
{
    public class QueryGraphQL
    {
        public IQueryable<ItemData> GetItem([Service] ApiDbContext context)
        {
            return context.Items;
        }
    }
}