using System;
using System.Text;
using AutoReservation.Common.Extensions;
using AutoReservation.Common.DataTransferObjects.Core;

namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto : DtoBase<ReservationDto>
    {
        private int _reservationNr;
        public int ReservationNr
        {
            get { return _reservationNr; }
            set
            {
                _reservationNr = value;
                this.OnPropertyChanged(p => p.ReservationNr);
            }
        }

        private int _autoId;
        public int AutoId
        {
            get { return _autoId; }
            set
            {
                _autoId = value;
                this.OnPropertyChanged(p => p.AutoId);
            }
        }

        private int _kundeId;
        public int KundeId
        {
            get { return _kundeId; }
            set
            {
                _kundeId = value;
                this.OnPropertyChanged(p => p.KundeId);
            }
        }

        private DateTime _von;
        public System.DateTime Von
        {
            get { return _von; }
            set
            {
                _von = value;
                this.OnPropertyChanged(p => p.Von);
            }
        }

        private DateTime _bis;
        public System.DateTime Bis
        {
            get { return _bis; }
            set
            {
                _bis = value;
                this.OnPropertyChanged(p => p.Bis);
            }
        }

        private AutoDto _auto;
        public virtual AutoDto Auto
        {
            get { return _auto; }
            set
            {
                _auto = value;
                _autoId = value.Id;
                this.OnPropertyChanged(p => p.Auto);
            }
        }

        private KundeDto _kunde;
        public virtual KundeDto Kunde {
            get { return _kunde; }
            set
            {
                _kunde = value;
                _kundeId = value.Id;
                this.OnPropertyChanged(p => p.Kunde);
            }
        }

        public override string Validate()
        {
            StringBuilder error = new StringBuilder();
            if (Von == DateTime.MinValue)
            {
                error.AppendLine("- Von-Datum ist nicht gesetzt.");
            }
            if (Bis == DateTime.MinValue)
            {
                error.AppendLine("- Bis-Datum ist nicht gesetzt.");
            }
            if (Von > Bis)
            {
                error.AppendLine("- Von-Datum ist grösser als Bis-Datum.");
            }
            if (Auto == null)
            {
                error.AppendLine("- Auto ist nicht zugewiesen.");
            }
            else
            {
                string autoError = Auto.Validate();
                if (!string.IsNullOrEmpty(autoError))
                {
                    error.AppendLine(autoError);
                }
            }
            if (Kunde == null)
            {
                error.AppendLine("- Kunde ist nicht zugewiesen.");
            }
            else
            {
                string kundeError = Kunde.Validate();
                if (!string.IsNullOrEmpty(kundeError))
                {
                    error.AppendLine(kundeError);
                }
            }


            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override ReservationDto Clone()
        {
            return new ReservationDto
            {
                ReservationNr = ReservationNr,
                Von = Von,
                Bis = Bis,
                Auto = Auto.Clone(),
                Kunde = Kunde.Clone()
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                ReservationNr,
                Von,
                Bis,
                Auto,
                Kunde);
        }
    }
}
