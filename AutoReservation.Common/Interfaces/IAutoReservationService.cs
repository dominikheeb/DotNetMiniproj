using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        Collection<AutoDto> Autos { get; }

        [OperationContract]
        AutoDto GetAuto(int autoId);

        [OperationContract]
        void InsertAuto(AutoDto auto);

        [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        Collection<KundeDto> Kunden { get; }

        [OperationContract]
        KundeDto GetKunde(int kundeId);

        [OperationContract]
        void InsertKunde(KundeDto kunde);

        [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        
        Collection<ReservationDto> Reservationen { get; }

        [OperationContract]
        ReservationDto GetReservation(int reservationNr);

        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
