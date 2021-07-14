using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ArabaDTO
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Sanziman { get; set; }
        public string Yakit { get; set; }
        public int Vites { get; set; }
        public int Fiyat { get; set; }
        public string Resim { get; set; }
    }
}
