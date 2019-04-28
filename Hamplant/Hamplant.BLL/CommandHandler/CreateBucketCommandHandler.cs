using Hamplant.BLL.Command;
using Hamplant.DAL.Model;
using Hamplant.DAL.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hamplant.BLL.CommandHandler
{
    public class CreateBucketCommandHandler : IRequestHandler<CreateBucketCommand, Guid>
    {
        private readonly IGenericRepository<Bucket> bucketRepository;
        public CreateBucketCommandHandler(IGenericRepository<Bucket> bucketRepository)
        {
            bucketRepository = this.bucketRepository;
        }

        public async Task<Guid> Handle(CreateBucketCommand command, CancellationToken cancellationToken)
        {
            Bucket newBucket = new Bucket
            {
                Name = command.Name,
                TeamId = command.TeamId,
                LastWriteTime = DateTimeOffset.Now
            };

            bucketRepository.Add(newBucket);

            bucketRepository.Save();

            return newBucket.Id;
        }
    }
}
