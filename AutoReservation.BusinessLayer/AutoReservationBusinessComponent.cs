using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        private AutoReservationEntities _context;
        public AutoReservationBusinessComponent()
        {
            _context = new AutoReservationEntities();
        }

        DbSet<Auto> GetAllAutos()
        {
            return _context.Auto;
        }

        private Auto GetAuto(int autoId)
        {
            return _context.Auto.SingleOrDefault(x => x.Id == autoId);

        }

        void AddAuto(Auto auto)
        {
            _context.Auto.Add(auto);
        }

        void UpdateAuto(Auto modified, Auto original)
        {
            try
            {
                _context.Auto.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Auto>(_context, original);
            }
        }

        void DeleteAuto(Auto auto)
        {
            _context.Auto.Remove(auto);
        }

        DbSet GetAllKunde()
        {
            return _context.Kunde;
        }

        Kunde GetKunde(int kundeId)
        {
            return _context.Kunde.SingleOrDefault(x => x.Id == kundeId);
        }

        void AddKunde(Kunde kunde)
        {
            _context.Kunde.Add(kunde);
        }

        void UpdateKunde(Kunde modified, Kunde original)
        {
            try
            {
                _context.Kunde.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Kunde>(_context, original);
            }
        }

        void DeleteKunde(Kunde kunde)
        {
            _context.Kunde.Remove(kunde);
        }

        DbSet<Reservation> GetAllResevation()
        {
            return _context.Reservation;
        }

        Reservation GetReservation(int reservationNr)
        {
            return _context.Reservation.SingleOrDefault(x => x.ReservationNr == reservationNr);
        }

        void AddReserveration(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
        }

        void UpdateReservation(Reservation modified, Reservation original)
        {
            try
            {
                _context.Reservation.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Reservation>(_context, original);
            }
        }

        void DeleteReservation(Reservation reservation)
        {
            _context.Reservation.Remove(reservation);
        }
        
        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}