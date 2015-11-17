using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent businessComponent = new AutoReservationBusinessComponent();
        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public Collection<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                throw new NotImplementedException();
            }
        }

        public AutoDto GetAuto(int autoId)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public Collection<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                throw new NotImplementedException();
            }
        }

        public KundeDto GetKunde(int kundeId)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public Collection<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                throw new NotImplementedException();
            }
        }

        public ReservationDto GetReservation(int reservationNr)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }
    }
}