using System.Threading;
using System.Threading.Tasks;
using Hamplant.BLL.Queries;
using Hamplant.BLL.ViewModels;
using Hamplant.DAL.Model;
using Hamplant.DAL.Repository;
using MediatR;

namespace Hamplant.BLL.QueryHandler
{
    public class BucketQueryHandler : IRequestHandler<BucketQuery, BucketViewModel>
    {
        private readonly IGenericRepository<Bucket> bucketRepository;
        public BucketQueryHandler(IGenericRepository<Bucket> bucketRepository)
        {
            bucketRepository = this.bucketRepository;
        }

        public async Task<BucketViewModel> Handle(BucketQuery query, CancellationToken cancellationToken)
        {
            Bucket bucket = this.bucketRepository.GetById(query.Id);

            return new BucketViewModel { Name = bucket.Name, TeamId = bucket.TeamId };
        }
    }
}
