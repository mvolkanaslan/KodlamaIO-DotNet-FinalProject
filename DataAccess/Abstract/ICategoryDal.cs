﻿
using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //aşağıdaki satır önemli
    public interface ICategoryDal:IEntityRepository<Category>
    {
    }
}
