using System;
using System.Runtime.Serialization;
using System.Text;
using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class KundeDto : DtoBase<KundeDto>
    {
        [DataMember]
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

        [DataMember]
        private string _nachname;
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                _nachname = value;
                this.OnPropertyChanged(p => p.Nachname);
            }
        }

        [DataMember]
        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                _vorname = value;
                this.OnPropertyChanged(p => p.Vorname);
            }
        }

        [DataMember]
        private DateTime _geburtsdatum;
        public System.DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                _geburtsdatum = value;
                this.OnPropertyChanged(p => p.Geburtsdatum);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Nachname))
            {
                error.AppendLine("- Nachname ist nicht gesetzt.");
            }
            if (string.IsNullOrEmpty(Vorname))
            {
                error.AppendLine("- Vorname ist nicht gesetzt.");
            }
            if (Geburtsdatum == DateTime.MinValue)
            {
                error.AppendLine("- Geburtsdatum ist nicht gesetzt.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override KundeDto Clone()
        {
            return new KundeDto
            {
                Id = Id,
                Nachname = Nachname,
                Vorname = Vorname,
                Geburtsdatum = Geburtsdatum
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}",
                Id,
                Nachname,
                Vorname,
                Geburtsdatum);
        }
    }
}
