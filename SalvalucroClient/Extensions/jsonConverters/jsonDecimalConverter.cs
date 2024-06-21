using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class jsonDecimalConverter : isoDecimalConverter
    {
        public jsonDecimalConverter()
        {
            CutureInfo = "pt-BR";
        }

        public jsonDecimalConverter(string Culture)
        {
            CutureInfo = Culture;
        }

    }
}
