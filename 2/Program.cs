#define LOL
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Listas
    {
        class Mazgas
        {
            public Mazgas Kitas { get; set; }
            public int Duom { get; set; }

            public Mazgas(Mazgas kitas, int duom)
            {
                Kitas = kitas;
                Duom = duom;
            }
        }
        private Mazgas pr;
        private Mazgas pb;
        private Mazgas d;

        public void Pradzia()
        {
            d = pr;
        }

        public void Pabaiga()
        {
            d = pb;
        }

        public bool Yra()
        {
            return d != null;
        }

        public void Kitas()
        {
            d = d.Kitas;
        }
        /// <summary>
        /// Rikiavimas
        /// </summary>
        public void Rikiuoti()
        {
            for(Mazgas a = pr; a != null; a = a.Kitas)
            {
                for(Mazgas b = a.Kitas; b != null; b = b.Kitas)
                {
                    if(a.Duom < b.Duom)
                    {
                        int laikinas = a.Duom;
                        a.Duom = b.Duom;
                        b.Duom = laikinas;
                    }
                }
            }
        }
        /// <summary>
        /// Iterpiau
        /// </summary>
        /// <param name="sk"></param>
        public void Iterpti(int sk)
        {
            Mazgas mazgas = new Mazgas(null, sk);
            pb.Kitas = mazgas;
            pb.Kitas.Duom = sk;
            pb = mazgas;
            Rikiuoti();
        }
    }
    class Player
    {
        public string number { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public int inches { get; set; }

        public Player(string _number, string _surname, string _name, int _inches)
        {
            number = _number;
            surname = _surname;
            name = _name;
            inches = _inches;
        }
    };
    class ProtocolLine
    {
        public string number { get; set; }
        public int quarter { get; set; }
        public int start { get; set; }
        // time to start playing
        public int duration { get; set; }
        // time of playing

        public ProtocolLine(string _number, int _quarter, int _start, int _duration)
        {
            number = _number;
            quarter = _quarter;
            start = _start;
            duration = _duration;
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> Pl = new List<Player>();
            List<ProtocolLine> PLine = new List<ProtocolLine>();
            var time = (from n in PLine
                        where n.number == "10"
                        select n.duration).Sum();
            IEnumerable<string> sum2 =
            from ar in Pl
            let sumA = (from mr in PLine
                        where ar.number == mr.number
                        && mr.quarter == 1
                        select mr.duration).Count()
            where sumA >= 5
            orderby sumA descending
            select ar.number + " " + ar.surname + " " +
ar.name + " " + sumA;
            Print("Rezultatai.txt", sum2, "Atrinkti 1 kėlinio žaidėjai", "Minutes");

            //           int kiekis = (from i in p where i.ModKodas == "P175B123" select i.PažNr).Distinct().Count();
            //         var sem = from mod in m let modkiek = (from i in p where i.ModKodas == m.ModKodas && m.Sem == "Pavasario" select i.PažNr).Distinct().Count() where modkiek > 3 orderby modkiek descending select m.Kodas + " " + m.Pavadinimas + " "+ modkiek;
#if LOL
            throw new Exception("DESTROY");
                #endif

        }

        static void Print<type>(string fn, IEnumerable<type> Ae,
string str, string title)
        {
            using (var file = new StreamWriter(fn, true))
            {
                file.WriteLine(str);
                file.WriteLine(new string('-', 28));
                file.WriteLine(title);
                file.WriteLine(new string('-', 28));
                foreach (type one in Ae)
                {
                    file.WriteLine(one);
                }
                file.WriteLine(new string('-', 28));
            }
        }

        void Enter<type>(string fd, IEnumerable<type> Ae, List<type> List)
        {
            using(StreamReader reader = new StreamReader(fd))
            {
                string line = null;
                while(null != (line = reader.ReadLine()))
                {
                    if (Ae.GetType().Equals(typeof(ProtocolLine)))
                    {
                        string[] val = line.Split(' ');
                        ProtocolLine linee = new ProtocolLine(val[0], int.Parse(val[1]), int.Parse(val[2]), int.Parse(val[3]));
                        //List.Add(linee);
                    }
                    if (Ae.GetType().Equals(typeof(Player)))
                    {
                        string[] val = line.Split(' ');
                        Player player = new Player(val[0], val[1], val[2], int.Parse(val[3]));
                    }

                    
                }
            }
        }
    }
}
