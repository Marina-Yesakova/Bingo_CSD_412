using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo_CSD_412.Models
{
    public class Category
    {
        //static category TODO: have to implement in Database 
        public static readonly Category CSD_412_Category = new Category();
        public String Name { get; set; }
        public String[] Words { get; set; }

        static Category()
        {
            CSD_412_Category.Name = "CSD_412";
            CSD_412_Category.Words = new[] { "HTTP" , "URL", "Data Tier", "N Tier", "Application Settings" };
        }
    }
}
