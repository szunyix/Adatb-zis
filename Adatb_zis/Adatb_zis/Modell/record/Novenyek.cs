using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatb_zis.Modell.record
{
    class Novenyek
    {
        private string id_noveny;
        public string Id_noveny
        {
            get { return id_noveny; }
            set
            {
                if (value == null)
                    throw new Exception("Az id nem lehet üres!");
                else if (value.Length != 4)
                    throw new ArgumentOutOfRangeException("Az id-nek 4 karakterből kell állnia!");
                id_noveny = value;
            }
        }

        private string viragzas;
        public string Viragzas
        {
            get { return viragzas; }
            set
            {
                if (value == null)
                    throw new Exception("Nem lehet üres a mező!");
                else if (value.Length > 200)
                    throw new ArgumentOutOfRangeException("A faj maximum 200 karakter hosszú lehet!");
                viragzas = value;
            }
        }

        private string kor;
        public string Kor
        {
            get { return kor; }
            set
            {
                if (value == null)
                    throw new Exception("Nem lehet üres a mező!");
                else if (value.Length > 20)
                    throw new ArgumentOutOfRangeException("A növény kora max 20 karakterből állhat!");
                kor = value;
            }
        }

        private string fajta;
        public string Fajta
        {
            get { return fajta; }
            set
            {
                if (value == null)
                    throw new Exception("A mező nem lehet üres!");
                else if (value.Length > 20)
                    throw new ArgumentOutOfRangeException("A növény fajtája maximum 20 karakterből állhat!");
                fajta = value;
            }
        }

        private int ar;
        public int Ar
        {
            get { return ar; }
            set
            {
                if (value <= 0)
                    throw new Exception("Nincs ingyen Növény és nem lehet negatív!");
                ar = value;
            }
        }

        private int uzletek_id;
        public int Uzletek_id
        {
            get { return uzletek_id; }
            set
            {
                if (value <= 0)
                    throw new Exception("A mező nem lehet üres és nem lehet negatív!");
                uzletek_id = value;
            }
        }
        public string uzletnev
        {
            set;
            get;
        }

    }
}
