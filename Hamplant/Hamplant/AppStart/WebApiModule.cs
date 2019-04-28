using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Hamplant.AppStart
{
    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.AddMediatR(typeof(Program).Assembly);
        }
    }
}
