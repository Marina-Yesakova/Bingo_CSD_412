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
        public HashSet<string> Words { get; set; }

        static Category() //Kept this for testing purposes
        {
            CSD_412_Category.Name = "CSD_412";
            CSD_412_Category.Words.Add("HTTP");
            CSD_412_Category.Words.Add("URL");
            CSD_412_Category.Words.Add("Date Tier");
            CSD_412_Category.Words.Add("N Tier");
            CSD_412_Category.Words.Add("Application Settings");
        }

        /*public Category()  <-- Real constructor
        {
            Id = GenerateId();
            Name = GetName();
            Words = new HashSet<string>();
        }*/

        private string DefineName()
        {
            //TODO: Add funcationality that allows user to name their category
            //Return that user input as a String
            throw new NotImplementedException();
        }

        private int GenerateId()
        {
            //TODO: Retrive from database the count of categories, and increament by one
            //return CategoryCount++;
            throw new NotImplementedException();
        }


        //TODO: View must implement a GUI for the user to send information to the Model
        public void AddWord(string word) //TODO: Implement an update to database
        {   
            Words.Add(word);
            Size = Words.Count;
        }

        public void RemoveWord(string word) //TODO: Implement an update to database
        {
            Words.Remove(word);
            Size = Words.Count;
        }
    }
}
