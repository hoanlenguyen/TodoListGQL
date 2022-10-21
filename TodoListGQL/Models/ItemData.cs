namespace TodoListGQL.Models
{
    public class ItemData
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public bool Done { get; set; }
        public int ListId { get; set; }
        public virtual ItemList ItemList { get; set; }
    }
}