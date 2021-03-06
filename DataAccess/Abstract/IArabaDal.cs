using Core.DataAccess;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IArabaDal : IEntityRepository<Araba>
    {
        ArabaDTO GetAraba(int id);
    }
}
