using System.Collections.Generic;
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
        private readonly AutoReservationEntities _context;
        public AutoReservationBusinessComponent()
        {
            _context = new AutoReservationEntities();
        }

        IList<Auto> GetAllAutos()
        {
            return _context.Auto.AsNoTracking().ToList();
        }

        private Auto GetAuto(int autoId)
        {
            return _context.Auto.AsNoTracking().SingleOrDefault(x => x.Id == autoId);

        }

        void AddAuto(Auto auto)
        {
            _context.Auto.Add(auto);
            _context.SaveChanges();

            _context.Entry(auto).State = EntityState.Detached;
        }

        void UpdateAuto(Auto modified, Auto original)
        {
            try
            {
                _context.Auto.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
                _context.SaveChanges();
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Auto>(_context, original);
            }
            _context.Entry(original).State = EntityState.Detached;
        }

        void DeleteAuto(Auto auto)
        {
            _context.Auto.Attach(auto);
            _context.Auto.Remove(auto);
            _context.SaveChanges();
            _context.Entry(auto).State = EntityState.Detached;
        }

        IList<Kunde> GetAllKunde()
        {
            return _context.Kunde.AsNoTracking().ToList();
        }

        Kunde GetKunde(int kundeId)
        {
            return _context.Kunde.AsNoTracking().SingleOrDefault(x => x.Id == kundeId);
        }

        void AddKunde(Kunde kunde)
        {
            _context.Kunde.Add(kunde);
            _context.SaveChanges();

            _context.Entry(kunde).State = EntityState.Detached;
        }

        void UpdateKunde(Kunde modified, Kunde original)
        {
            try
            {
                _context.Kunde.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
                _context.SaveChanges();
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Kunde>(_context, original);
            }
            _context.Entry(original).State = EntityState.Detached;
        }

        void DeleteKunde(Kunde kunde)
        {
            _context.Kunde.Attach(kunde);
            _context.Kunde.Remove(kunde);
            _context.SaveChanges();

            _context.Entry(kunde).State = EntityState.Detached;
        }

        IList<Reservation> GetAllResevation()
        {
            return _context.Reservation.AsNoTracking().ToList();
        }

        Reservation GetReservation(int reservationNr)
        {
            return _context.Reservation.AsNoTracking().SingleOrDefault(x => x.ReservationNr == reservationNr);
        }

        void AddReserveration(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
            _context.SaveChanges();

            _context.Entry(reservation).State = EntityState.Detached;
        }

        void UpdateReservation(Reservation modified, Reservation original)
        {
            try
            {
                _context.Reservation.Attach(original);
                _context.Entry(original).CurrentValues.SetValues(modified);
                _context.SaveChanges();
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                HandleDbConcurrencyException<Reservation>(_context, original);
            }
            _context.Entry(original).State = EntityState.Detached;
        }

        void DeleteReservation(Reservation reservation)
        {
            _context.Reservation.Attach(reservation);
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();

            _context.Entry(reservation).State = EntityState.Detached;
        }
        
        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>($"Update {typeof (T).Name}: Concurrency-Fehler", original);
        }
    }
}