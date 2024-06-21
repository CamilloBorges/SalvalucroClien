using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class jsonDateOnlyConverter : isoDateOnlyConverter
    {
        public jsonDateOnlyConverter() 
        {
            DateFormat = "yyyy'-'MM'-'dd";
        }
        
        public jsonDateOnlyConverter(string inter) 
        {
            DateFormat = inter;
        }

    }
}
