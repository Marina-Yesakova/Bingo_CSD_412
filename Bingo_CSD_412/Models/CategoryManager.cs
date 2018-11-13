using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo_CSD_412.Models
{
    public class CategoryManager
    {
        public Category[] ListAllCategories()
        {
            //TODO: Implement logic to return all caterories from a Database
            Category[] result = new[] { Category.CSD_412_Category };
            return result;
        }

        public String[] ListAllWordsForCategory(String categoryName)
        {
            //TODO: Implement logic to return all words for a category from a Database
            String[] result = Category.CSD_412_Category.Words;
            return result;
        }

        public void AddWordToCategory(String categoryName, String word)
        {
            //TODO: Implement logic
        }
    }
}
