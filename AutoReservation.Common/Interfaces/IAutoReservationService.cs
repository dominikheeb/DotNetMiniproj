﻿using System.Collections.ObjectModel;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        Collection<AutoDto> Autos
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        AutoDto GetAuto(int autoId);

        [OperationContract]
        void InsertAuto(AutoDto auto);

        [OperationContract, FaultContract(typeof(AutoDto))]
        void UpdateAuto(AutoDto modified, AutoDto original);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        Collection<KundeDto> Kunden
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        KundeDto GetKunde(int kundeId);

        [OperationContract]
        void InsertKunde(KundeDto kunde);

        [OperationContract, FaultContract(typeof(KundeDto))]
        void UpdateKunde(KundeDto modified, KundeDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        Collection<ReservationDto> Reservationen
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        ReservationDto GetReservation(int reservationNr);

        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        [OperationContract, FaultContract(typeof(ReservationDto))]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
