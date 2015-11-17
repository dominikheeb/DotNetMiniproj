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

        public Collection<AutoDto> GetAllAutos()
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public AutoDto GetAuto(int autoId)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void AddAuto(AutoDto auto)
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

        public Collection<KundeDto> GetAllKunde()
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto GetKunde(int kundeId)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void AddKunde(KundeDto kunde)
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

        public Collection<ReservationDto> GetAllResevation()
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto GetReservation(int reservationNr)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public void AddReserveration(ReservationDto reservation)
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