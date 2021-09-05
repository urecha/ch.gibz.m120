using System;

namespace M120_urech.Models
{
    public class Presentation
    {
        public DateTime PresentationTime { get; set; }
        public int FreePlacesCount { get; set; } = 120;

        public bool IsSoldOut { get => FreePlacesCount == 0; }

        public Presentation() { }

        public Presentation(DateTime presentationTime): this()
        {
            PresentationTime = presentationTime;
        }
        public Presentation(DateTime presentationTime, int freePlaces) : this()
        {
            FreePlacesCount = freePlaces;
            PresentationTime = presentationTime;
        }
    }
}
