﻿using System;
using System.Collections.Generic;

namespace Bingo_CSD_412.Models
{
    public class Board
    {
        public int NumberOfRows { get; set; } 
        public int NumberOfColumns { get; set; }
        public int BoardId { get; set; }
        public String Category { get; set; }
        public String[] DisplayBoard { get; set; } //Array that the user will see
        private HashSet<int> IdSet { get; set; } //Set used to operate with random selection logic
        private char[] DummyDatabase { get; set; } //place holder DB
        private bool[] FunctionalBoard { get; set; } //Array that tracks if a cell has been selected
        private int Size;

        // TODO: this should be handled by database - it should return us unique id for each Board we insert into database
        private static int nextId = 1;

        public Board()
        {
            BoardId = nextId;
            nextId++;
            NumberOfRows = 5;
            NumberOfColumns = 5;
            Size = NumberOfRows * NumberOfColumns;
            DisplayBoard = new String[Size];
            FunctionalBoard = new bool[Size]; //This array stores values of either 0 for not selected or 1 for select
            IdSet = new HashSet<int>();
            GenerateDummyDatabase();
            FillSet();
            FillBoard();
        }

        /*
        * This is a place holder method to be used while we are not connected to a database
        * This method constructs a char array where the index of the Array represents the ID of the data
        */
        private void GenerateDummyDatabase()
        {
            DummyDatabase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()".ToCharArray();
        }

        //This method creates a set of 25 random non-repeating IDs to be used to pull data from the DB
        private void FillSet()
        {
            Random Rnd = new Random();
            bool ConfirmSize = false;
            while (!ConfirmSize)
            {
                int value = Rnd.Next(40); //40 will be changed to the # of rows in the DB
                IdSet.Add(value);
                if (IdSet.Count == Size)
                {
                    ConfirmSize = true;
                }
            }
        }

        //This populate the array that will be displayed in the view 
        private void FillBoard()
        {
            int Index = 0;
            foreach (int i in IdSet)
            {
                // get value of ID i from database and store it in DisplayBoard[index] 
                DisplayBoard[Index] = DummyDatabase[i].ToString();
                Index++;
            }
        }

        // to be implemented later 
        public void CellSelect(int index)
        {
            FunctionalBoard[index] = true;
            if (CheckForBingo(index))
            {
                GameOver();
            }
        }

        public bool IsCellCrossed(int index)
        {
            return FunctionalBoard[index];
        }

        // to be implemented later
        private bool CheckForBingo(int index)
        {
            //logic will check the current row and column and if applicable the diagnals for bingo
            return false; 
        }

        // to be implemented later
        private void GameOver()
        {
            throw new NotImplementedException();
        }
    }
}