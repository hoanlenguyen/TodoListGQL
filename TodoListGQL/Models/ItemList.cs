namespace TodoListGQL.Models
{
    public class ItemList
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public virtual ICollection<ItemData> ItemDatas { get; set; } = new HashSet<ItemData>();
    }
}