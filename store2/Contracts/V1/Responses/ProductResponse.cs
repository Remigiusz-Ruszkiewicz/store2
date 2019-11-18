using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Contracts.V1.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
