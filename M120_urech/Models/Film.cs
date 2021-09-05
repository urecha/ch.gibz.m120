using System.Collections.Generic;

namespace M120_urech.Models
{
    public class Film
    {
        public static readonly float PRICE_PER_TICKET = 12.95f;
        private static int NextId = 1;
        public int Id { get; }
        public string Title { get; }
        public Category Category { get; }
        public int Duration { get; }
        public IEnumerable<Presentation> Presentations { get; }

        public Film() { }

        public Film(string title, Category category, int duration, IEnumerable<Presentation> presentations)
        {
            Id = NextId++;
            Title = title;
            Category = category;
            Duration = duration;
            Presentations = presentations;
        }
    }
}
