﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public interface IProduct
    {
        decimal Accept(IVisitor visitor);
    }
}
