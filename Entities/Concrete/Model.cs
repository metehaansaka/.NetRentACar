using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int ModelId { get; set; }
        public int MarkaId { get; set; }
        public string ModelAdi { get; set; }
    }
}
