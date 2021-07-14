using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Araba : IEntity
    {
        public int ArabaId { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public string Sanziman { get; set; }
        public string Yakit { get; set; }
        public int Vites { get; set; }
        public int Fiyat { get; set; }
        public string Resim { get; set; }
    }
}
