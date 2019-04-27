using Autofac;
using Hamplant.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hamplant.BLL
{
    public class BusinessLogicModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        }
    }
}
