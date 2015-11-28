using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            var bind = new BasicHttpBinding();
            var addr = new EndpointAddress("http://localhost:8732/AutoReservationService");
            var factory = new ChannelFactory<IAutoReservationService>(bind, addr);
            // Proxy erzeugen
            return factory.CreateChannel();
        }
    }
}
