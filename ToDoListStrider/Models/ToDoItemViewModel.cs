namespace ToDoListStrider.Models
{
    public class ToDoItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoItemViewModel()
        {
        }
    }
}
