using System.Collections.ObjectModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        Collection<AutoDto> GetAllAutos();

        AutoDto GetAuto(int autoId);

        void AddAuto(AutoDto auto);

        void UpdateAuto(AutoDto modified, AutoDto original);

        void DeleteAuto(AutoDto auto);

        Collection<KundeDto> GetAllKunde();

        KundeDto GetKunde(int kundeId);

        void AddKunde(KundeDto kunde);

        void UpdateKunde(KundeDto modified, KundeDto original);

        void DeleteKunde(KundeDto kunde);

        Collection<ReservationDto> GetAllResevation();

        ReservationDto GetReservation(int reservationNr);

        void AddReserveration(ReservationDto reservation);

        void UpdateReservation(ReservationDto modified, ReservationDto original);

        void DeleteReservation(ReservationDto reservation);
    }
}
