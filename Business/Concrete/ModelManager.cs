using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public Model Get(int id)
        {
            return _modelDal.Get(m => m.MarkaId == id);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }
    }
}
