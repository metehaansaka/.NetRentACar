using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class ArabaManager : IArabaService
    {
        private IArabaDal _arabaDal;
        public ArabaManager(IArabaDal arabaDal)
        {
            _arabaDal = arabaDal;
        }

        public List<Araba> GetAll()
        {
            return _arabaDal.GetAll();
        }

        public ArabaDTO GetAraba(int id)
        {
            return _arabaDal.GetAraba(id);
        }

        public void Add(Araba araba)
        {
            _arabaDal.Add(araba);
        }

        public void Update(Araba araba)
        {
            _arabaDal.Update(araba);
        }

        public void Delete(int id)
        {
            _arabaDal.Delete(id);
        }

        public Araba Get(int id)
        {
            return _arabaDal.Get(a => a.ArabaId == id);
        }
    }
}
