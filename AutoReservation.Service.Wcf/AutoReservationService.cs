﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ServiceModel;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private readonly AutoReservationBusinessComponent _businessComponent;

        public AutoReservationService() 
        {
            _businessComponent = new AutoReservationBusinessComponent();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public Collection<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();
                return new Collection<AutoDto>(_businessComponent.GetAllAutos().ConvertToDtos());
            }
        }

        public AutoDto GetAuto(int autoId)
        {
            WriteActualMethod();
            return _businessComponent.GetAuto(autoId).ConvertToDto();
        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            _businessComponent.AddAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateAuto(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            _businessComponent.DeleteAuto(auto.ConvertToEntity());
        }

        public Collection<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                return new Collection<KundeDto>(_businessComponent.GetAllKunde().ConvertToDtos());
            }
        }

        public KundeDto GetKunde(int kundeId)
        {
            WriteActualMethod();
            return _businessComponent.GetKunde(kundeId).ConvertToDto();
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            _businessComponent.AddKunde(kunde.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateKunde(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<KundeDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            _businessComponent.DeleteKunde(kunde.ConvertToEntity());
        }

        public Collection<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                return new Collection<ReservationDto>(_businessComponent.GetAllResevation().ConvertToDtos());
            }
        }

        public ReservationDto GetReservation(int reservationNr)
        {
            WriteActualMethod();
            return _businessComponent.GetReservation(reservationNr).ConvertToDto();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            _businessComponent.AddReserveration(reservation.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            try
            {
                _businessComponent.UpdateReservation(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<ReservationDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            _businessComponent.DeleteReservation(reservation.ConvertToEntity());
        }
    }
}