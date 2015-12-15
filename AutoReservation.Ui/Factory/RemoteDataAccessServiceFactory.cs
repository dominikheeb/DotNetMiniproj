using System.ServiceModel;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessServiceFactory : IServiceFactory
    {
        public IAutoReservationService GetService()
        {
            var factory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            // Proxy erzeugen
            return factory.CreateChannel();
        }
    }
}
