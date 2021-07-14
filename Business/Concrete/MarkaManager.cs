using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MarkaManager : IMarkaService
    {

        private IMarkaDal _markaDal;
        public MarkaManager(IMarkaDal markaDal)
        {
            _markaDal = markaDal;
        }

        public Marka Get(int id)
        {
            return _markaDal.Get(m => m.MarkaId == id);
        }

        public List<Marka> GetAll()
        {
            return _markaDal.GetAll();
        }

    }
}
