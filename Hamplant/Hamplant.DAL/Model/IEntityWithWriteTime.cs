using System;
using System.Collections.Generic;
using System.Text;

namespace Hamplant.DAL.Model
{
    interface IEntityWithWriteTime
    {
        DateTimeOffset LastWriteTime { get; set; }
    }
}
