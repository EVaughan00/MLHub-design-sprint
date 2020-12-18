using Autofac;
using BuildingBlocks.Common.Events.Bus;

namespace Models.API.Initializers
{
    public class EventBusModule : Autofac.Module 
    {
        public EventBusModule() {}

        protected override void Load(ContainerBuilder builder)
        {  
            builder.RegisterType<RabbitMQBus>()
                .As<IEventBus>()
                .InstancePerLifetimeScope();
        }
    }
}