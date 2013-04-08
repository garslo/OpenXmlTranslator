using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXmlTranslate
{
    public interface ElementConverter<FromType, ToType>
    {
        ToType Convert(FromType item);
    }
}
