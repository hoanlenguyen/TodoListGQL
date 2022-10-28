using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using TodoListGQL.Data;
using TodoListGQL.Models;

namespace TodoListGQL.GraphQL
{
    public class QueryGraphQL : ObjectGraphType
    {
         

        public ItemData GetItem([Service] ApiDbContext context, int id)
        {
            return context.Items.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}