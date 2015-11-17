using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        Collection<AutoDto> Autos { get; }

        AutoDto GetAuto(int autoId);

        void InsertAuto(AutoDto auto);

        void UpdateAuto(AutoDto modified, AutoDto original);

        void DeleteAuto(AutoDto auto);

        Collection<KundeDto> Kunden { get; }

        KundeDto GetKunde(int kundeId);

        void InsertKunde(KundeDto kunde);

        void UpdateKunde(KundeDto modified, KundeDto original);

        void DeleteKunde(KundeDto kunde);

        Collection<ReservationDto> Reservationen { get; }

        ReservationDto GetReservation(int reservationNr);

        void InsertReservation(ReservationDto reservation);

        void UpdateReservation(ReservationDto modified, ReservationDto original);

        void DeleteReservation(ReservationDto reservation);
    }
}
