using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            Assert.AreEqual(3, Target.Autos.Count);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            Assert.AreEqual(4, Target.Kunden.Count);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            Assert.AreEqual(3, Target.Reservationen.Count);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            AutoDto auto = Target.GetAuto(1);
            Assert.AreEqual(AutoKlasse.Standard, auto.AutoKlasse);
            Assert.AreEqual(0, auto.Basistarif);
            Assert.AreEqual(50, auto.Tagestarif);
            Assert.AreEqual(1, auto.Id);
            Assert.AreEqual("Fiat Punto", auto.Marke);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            KundeDto kunde = Target.GetKunde(1);
            Assert.AreEqual(1, kunde.Id);
            Assert.AreEqual("Anna", kunde.Vorname);
            Assert.AreEqual("Nass", kunde.Nachname);
            Assert.AreEqual(new DateTime(1961, 5, 5), kunde.Geburtsdatum);
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            ReservationDto reservation = Target.GetReservation(1);
            Assert.AreEqual(1, reservation.ReservationNr);
            Assert.AreEqual(1, reservation.AutoId);
            Assert.AreEqual(1, reservation.KundeId);
            Assert.AreEqual(new DateTime(2020, 1, 10), reservation.Von);
            Assert.AreEqual(new DateTime(2020, 1, 20), reservation.Bis);
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            ReservationDto reservation = Target.GetReservation(5);
            Assert.IsNull(reservation);
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            AutoDto newAuto = new AutoDto
            {
                AutoKlasse = AutoKlasse.Mittelklasse,
                Tagestarif = 10,
                Marke = "Ferrari Enzo"
            };
            Target.InsertAuto(newAuto);

            // check if auto exists
            Assert.AreEqual(4, Target.Autos.Count);

            Assert.IsNotNull(Target.Autos.FirstOrDefault(auto => auto.AutoKlasse.Equals(AutoKlasse.Mittelklasse) 
            && auto.Marke.Equals("Ferrari Enzo") && auto.Tagestarif == 10));
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            KundeDto newKunde = new KundeDto
            {
                Vorname = "Max",
                Nachname = "Muster",
                Geburtsdatum = new DateTime(2000, 1, 1)
            };

            Target.InsertKunde(newKunde);
            // Check if kunde exists
            Assert.AreEqual(5, Target.Kunden.Count);

            Assert.IsNotNull(Target.Kunden.FirstOrDefault(kun => kun.Vorname.Equals("Max") && kun.Nachname.Equals("Muster")));
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            AutoDto auto = Target.GetAuto(1);
            KundeDto kunde = Target.GetKunde(1);
            ReservationDto newReservation = new ReservationDto
            {
                Auto = auto,
                Kunde = kunde,
                Von = new DateTime(2010, 1, 1),
                Bis = new DateTime(2010, 1, 2)
            };

            Target.InsertReservation(newReservation);
            // Check if reservation exists
            Assert.AreEqual(4, Target.Reservationen.Count);

            Assert.IsNotNull(Target.Reservationen.FirstOrDefault(res => res.Kunde.Id == kunde.Id && res.Auto.Id == auto.Id));
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            AutoDto auto = Target.GetAuto(1);
            auto.Marke = "Lamborghini Gallardo";
            Target.UpdateAuto(auto, Target.GetAuto(1));

            // Check if update worked
            AutoDto updatedAuto = Target.GetAuto(1);
            Assert.AreEqual("Lamborghini Gallardo", updatedAuto.Marke);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            KundeDto kunde = Target.GetKunde(1);
            kunde.Vorname = "Fabian";
            Target.UpdateKunde(kunde, Target.GetKunde(1));

            // Check if updated worked
            KundeDto updatedKunde = Target.GetKunde(1);
            Assert.AreEqual("Fabian", updatedKunde.Vorname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            ReservationDto reservation = Target.GetReservation(1);
            reservation.Von = new DateTime(2000, 10, 10);
            Target.UpdateReservation(reservation, Target.GetReservation(1));

            // Check if update worked
            ReservationDto updatedReservation = Target.GetReservation(1);
            Assert.AreEqual(new DateTime(2000, 10, 10), updatedReservation.Von);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            AutoDto originalAuto1 = Target.GetAuto(1);
            AutoDto originalAuto2 = Target.GetAuto(1);

            AutoDto auto1 = new AutoDto
            {
                AutoKlasse = originalAuto1.AutoKlasse,
                Basistarif = originalAuto1.Basistarif,
                Id = originalAuto1.Id,
                Marke = originalAuto1.Marke,
                Tagestarif = originalAuto1.Tagestarif + 10
            };

            AutoDto auto2 = new AutoDto
            {
                AutoKlasse = originalAuto2.AutoKlasse,
                Basistarif = originalAuto2.Basistarif,
                Id = originalAuto2.Id,
                Marke = originalAuto2.Marke,
                Tagestarif = originalAuto2.Tagestarif + 20
            };

            Target.UpdateAuto(auto1, originalAuto1);
            Target.UpdateAuto(auto2, originalAuto2);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            KundeDto kunde = Target.GetKunde(1);
            Target.DeleteKunde(kunde);
            
            Assert.AreEqual(3, Target.Kunden.Count);
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            AutoDto auto = Target.GetAuto(1);
            Target.DeleteAuto(auto);

            Assert.AreEqual(2, Target.Autos.Count);
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            ReservationDto reservation = Target.GetReservation(1);
            Target.DeleteReservation(reservation);

            Assert.AreEqual(2, Target.Reservationen.Count);
        }
    }
}
