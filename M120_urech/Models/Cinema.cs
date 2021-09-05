using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_urech.Models
{
    public class Cinema
    {
        public string Name { get; set; }
        public int SeatCount { get; } = 120;
        public IEnumerable<Film> FilmList { get; set; }

        private static Cinema _instance;

        public Cinema GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Cinema{ Name = "Kino ABC" };
            }
            return _instance;
        }

        public IEnumerable<Film> FindFilmsByName(string name)
        {
            if (FilmList == null || FilmList.Count() == 0) return new List<Film>();
            return FilmList.Where(f => f.Title.ToLower().Contains(name.ToLower()));
        }
    }
}
