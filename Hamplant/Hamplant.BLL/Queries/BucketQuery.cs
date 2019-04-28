using Hamplant.BLL.ViewModels;
using MediatR;
using System;

namespace Hamplant.BLL.Queries
{
    public class BucketQuery: IRequest<BucketViewModel>
    {
        public Guid Id { get; set; }
    }
}
