namespace M120_urech.Models
{
    public class Category
    {
        private static int NextId = 1;
        public int Id { get; }
        public string Description { get; }

        public Category() { }
        public Category(string description): this()
        {
            Id = NextId++;
            Description = description;
        }
    }
}
