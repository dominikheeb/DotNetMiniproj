using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        public IList<Auto> GetAllAutos()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Auto.AsNoTracking().ToList();
            }
        }

        public Auto GetAuto(int autoId)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Auto.AsNoTracking().SingleOrDefault(x => x.Id == autoId);
            }
        }

        public void AddAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Auto.Add(auto);
                context.SaveChanges();
            }

        }

        public void UpdateAuto(Auto modified, Auto original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Auto.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Auto.Attach(auto);
                context.Auto.Remove(auto);
                context.SaveChanges();
            }
        }

        public IList<Kunde> GetAllKunde()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Kunde.AsNoTracking().ToList();
            }
        }

        public Kunde GetKunde(int kundeId)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Kunde.AsNoTracking().SingleOrDefault(x => x.Id == kundeId);
            }
        }

        public void AddKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunde.Add(kunde);
                context.SaveChanges();
            }
        }

        public void UpdateKunde(Kunde modified, Kunde original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunde.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunde.Attach(kunde);
                context.Kunde.Remove(kunde);
                context.SaveChanges();
            }
        }

        public IList<Reservation> GetAllResevation()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Reservation.Include(r => r.Auto).Include(r => r.Kunde).AsNoTracking().ToList();
            }
        }

        public Reservation GetReservation(int reservationNr)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Reservation.Include(r => r.Auto).Include(r => r.Kunde).AsNoTracking().SingleOrDefault(x => x.ReservationNr == reservationNr);
            }
        }

        public void AddReserveration(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservation.Add(reservation);
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Reservation modified, Reservation original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservation.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservation.Attach(reservation);
                context.Reservation.Remove(reservation);
                context.SaveChanges();
            }
        }
        
        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>($"Update {typeof (T).Name}: Concurrency-Fehler", original);
        }
    }
}