using Hamplant.BLL.Command;
using Hamplant.BLL.Queries;
using Hamplant.BLL.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hamplant.Controllers
{
    public class BucketController : Controller
    {
        private readonly IMediator mediator;

        public BucketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<BucketViewModel> GetBucket(Guid id)
        {
            BucketViewModel bucket = await mediator.Send(new BucketQuery { Id = id });

            return bucket;
        }

        [HttpPost]
        public async Task<Guid> CreateBucket(CreateBucketCommand command)
        {
            Guid bucketId = await mediator.Send(command);

            return bucketId;
        }
    }
}