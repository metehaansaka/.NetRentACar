using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Marka :IEntity
    {
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
    }
}
