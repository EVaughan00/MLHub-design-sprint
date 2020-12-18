using Autofac;
using Models.Infrastructure;

namespace Models.API.Initializers
{
    public class RepositoryModule : Autofac.Module 
    {
        public RepositoryModule() {}

        protected override void Load(ContainerBuilder builder)
        {  
            builder.RegisterType<ModelsEntityRepository>()
                .As<IModelsEntityRepository>()
                .InstancePerLifetimeScope();
        }
    }
}