﻿using System;
using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_UpdateAuto()
        {
            Auto auto = Target.GetAuto(1);
            auto.Tagestarif = 15;
            auto.Marke = "Ferrari";

            Target.UpdateAuto(auto, Target.GetAuto(1));
            Assert.AreEqual(15, Target.GetAuto(1).Tagestarif);
            Assert.AreEqual("Ferrari", Target.GetAuto(1).Marke);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Kunde kunde = Target.GetKunde(1);
            DateTime date = new DateTime(2000, 1, 1);
            kunde.Geburtsdatum = date;
            kunde.Vorname = "Urs";
            kunde.Nachname = "Meier";

            Target.UpdateKunde(kunde, Target.GetKunde(1));
            Assert.AreEqual(date, Target.GetKunde(1).Geburtsdatum);
            Assert.AreEqual("Urs", Target.GetKunde(1).Vorname);
            Assert.AreEqual("Meier", Target.GetKunde(1).Nachname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Reservation reservation = Target.GetReservation(1);
            DateTime von = new DateTime(2000, 1, 1);
            DateTime bis = new DateTime(2010, 1, 1);
            reservation.Von = von;
            reservation.Bis = bis;

            Target.UpdateReservation(reservation, Target.GetReservation(1));
            Assert.AreEqual(von, Target.GetReservation(1).Von);
            Assert.AreEqual(bis, Target.GetReservation(1).Bis);
        }
    }
}
