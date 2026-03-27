using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public record TopicId
    {
        public Guid Value { get; }
        private TopicId(Guid value) 
        { 
            this.Value = value;
        }
        public static TopicId Of(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new DomainException("TopicId не может быть пустым.");
            }
            return new TopicId(value);
        }
    }
}

