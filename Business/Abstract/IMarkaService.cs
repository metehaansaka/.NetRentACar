using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMarkaService
    {
        List<Marka> GetAll();
        Marka Get(int id);
    }
}
