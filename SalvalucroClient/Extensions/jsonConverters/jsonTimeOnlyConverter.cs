using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvalucroClient.Extensions.jsonConverters
{
    public class jsonTimeOnlyConverter : isoTimeOnlyConverter
    {
        public jsonTimeOnlyConverter()
        {
            TimeFormat = "HH:mm:ss";
        }

        public jsonTimeOnlyConverter(string timeFormat)
        {
            TimeFormat = timeFormat;
        }
    }
}
