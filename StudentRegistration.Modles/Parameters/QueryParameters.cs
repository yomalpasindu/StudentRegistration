using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Modles.Parameters
{
    public class QueryParameters
    {
        const int maxSize = 10;
        private int size = 5;

        public int Page { get; set; } = 1;
        public int Size { get 
            {
                return size;
            }
            set
            {
                size = Math.Min(maxSize, value);        
            }
        }
    }
}
