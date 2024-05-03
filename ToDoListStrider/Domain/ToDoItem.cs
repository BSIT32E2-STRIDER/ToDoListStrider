namespace ToDoListStrider.Domain
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        public DateTime? CompletedDate { get; set; }
       
    }
}
