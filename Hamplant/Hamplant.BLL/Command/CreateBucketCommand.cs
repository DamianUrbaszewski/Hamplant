using MediatR;
using System;

namespace Hamplant.BLL.Command
{
    public class CreateBucketCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public Guid TeamId { get; set; }
    }
}
