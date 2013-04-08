﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXmlTranslate
{
    public interface GenericFactory<InType, OutType>
    {
        OutType MakeFrom(InType decidingObject);
    }
}
