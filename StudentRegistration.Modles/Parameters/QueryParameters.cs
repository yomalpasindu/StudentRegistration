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
        private string sortBy="asc";

        public int Page { get; set; } = 1;
        public int Size
        {
            get 
            {
                return size;
            }
            set
            {
                size = Math.Min(maxSize, value);        
            }
        }
        public string Sort {
            get 
            {
                return sortBy;
            }
            set
            {
                if (value == "asc" || value == "desc")
                    sortBy = value;
            }
        }

    }
}
