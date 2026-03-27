using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    interface IEntity<T>: IEntity
    {
        public T Id { get; set; }
    }
    public interface IEntity
    {
    }
}
