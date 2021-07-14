using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IArabaService
    {
        List<Araba> GetAll();
        ArabaDTO GetAraba(int id);
        void Add(Araba araba);
    }
}
