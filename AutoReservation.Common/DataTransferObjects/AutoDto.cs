using System;
using System.Text;
using AutoReservation.Common.DataTransferObjects.Core;
using AutoReservation.Common.Extensions;

namespace AutoReservation.Common.DataTransferObjects
{
    public class AutoDto : DtoBase<AutoDto>
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                this.OnPropertyChanged(p => p.Id);
            }
        }

        private string _marke;
        public string Marke
        {
            get { return _marke; }
            set
            {
                _marke = value;
                this.OnPropertyChanged(p => p.Marke);
            }
        }

        private int _autoKlasseIndex;
        public int AutoKlasseIndex
        {
            get { return _autoKlasseIndex; }
            set
            {
                _autoKlasseIndex = value;
                this.OnPropertyChanged(p => p.AutoKlasseIndex);
            }
        }

        private int _tagestarif;
        public int Tagestarif
        {
            get { return _tagestarif; }
            set
            {
                _tagestarif = value;
                this.OnPropertyChanged(p => p.Tagestarif);
            }
        }

        private Nullable<int> _basistarif;
        public Nullable<int> Basistarif
        {
            get { return _basistarif; }
            set
            {
                _basistarif = value;
                this.OnPropertyChanged(p => p.Basistarif);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Marke))
            {
                error.AppendLine("- Marke ist nicht gesetzt.");
            }
            if (Tagestarif <= 0)
            {
                error.AppendLine("- Tagestarif muss grösser als 0 sein.");
            }
            if (AutoKlasseIndex == (int) AutoKlasse.Luxusklasse && Basistarif <= 0)
            {
                error.AppendLine("- Basistarif eines Luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override AutoDto Clone()
        {
            return new AutoDto
            {
                Id = Id,
                Marke = Marke,
                Tagestarif = Tagestarif,
                AutoKlasseIndex = AutoKlasseIndex,
                Basistarif = Basistarif
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                Id,
                Marke,
                Tagestarif,
                Basistarif,
                AutoKlasseIndex);
        }
    }
}
