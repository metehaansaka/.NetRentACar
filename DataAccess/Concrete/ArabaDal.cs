using Core.DataAccess;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class ArabaDal : EntityRepositoryBase<Araba, Context>, IArabaDal
    {
        public ArabaDTO GetAraba(int id)
        {
            using (Context context = new Context())
            {
                var query = from araba in context.Arabalar
                            join marka in context.Markalar on araba.MarkaId equals marka.MarkaId
                            join model in context.Modeller on marka.MarkaId equals model.ModelId
                            where araba.ArabaId == id
                            select new ArabaDTO { Fiyat = araba.Fiyat, Marka = marka.MarkaAdi, Model = model.ModelAdi, Sanziman = araba.Sanziman, Vites = araba.Vites, Yakit = araba.Yakit };
                return query.FirstOrDefault();
            }
        }

    }
}
