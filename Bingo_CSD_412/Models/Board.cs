using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo_CSD_412.Models
{
    public class Board
    {
        public int NumberOfRows { get; set; } 
        public int NumberOfColumns { get; set; }
        public int BoardId { get; set; }
        public String Category { get; set; }
        public bool BingoOccurred { get; set; }
        public String[] DisplayBoard { get; set; } //Array that the user will see
        private HashSet<int> IdSet { get; set; } //Set used to operate with random selection logic
        private bool[] FunctionalBoard { get; set; } //Array that tracks if a cell has been selected
        public int Size { get; }
        private int _ContextSize;
        private List<Word> _WordsList;

        // TODO: this should be handled by database - it should return us unique id for each Board we insert into database
        private static int nextId = 1;
        
        public Board() //Non-database ctor
        {   
            NumberOfRows = 5;
            NumberOfColumns = 5;
            Size = NumberOfRows * NumberOfColumns;
            _ContextSize = Size;
            FunctionalBoard = new bool[Size]; //This array stores values of either 0 for not selected or 1 for select
            IdSet = new HashSet<int>();
            FillSet();
            BingoOccurred = false;
        }
        
        public Board(int ContextSize, List<Word> WordList)
        {
            BoardId = nextId;
            nextId++;
            NumberOfRows = 5;
            NumberOfColumns = 5;
            Size = NumberOfRows * NumberOfColumns;
            DisplayBoard = new String[Size];
            FunctionalBoard = new bool[Size]; //This array stores values of either 0 for not selected or 1 for select
            IdSet = new HashSet<int>();
            _ContextSize = ContextSize;
            _WordsList = WordList;
            FillSet();
            FillBoard();
            BingoOccurred = false;
        }


        //This method creates a set of 25 random non-repeating IDs to be used to pull data from the DB
        private void FillSet()
        {
            Random Rnd = new Random();
            bool ConfirmSize = false;
            while (!ConfirmSize)
            {
                int value = Rnd.Next(_ContextSize); 
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
                DisplayBoard[Index] = _WordsList.ElementAt(i).Label;
                Index++;
            }
        }

        // to be implemented later 
        public void CellSelect(int index)
        {
            FunctionalBoard[index] = (FunctionalBoard[index] == true) ? false : true; //allows users to 'un-check' squares
            BingoOccurred = false;
            if (CheckForBingo())
            {
                GameOver();
            }
        }

        public bool IsCellCrossed(int index)
        {
            return FunctionalBoard[index];
        }

        private bool CheckForBingo()
        {
            int DiagonalCount = 0;

            for (int ir = 0, ic = 0; ic < NumberOfColumns && ir < NumberOfRows; ir++, ic++) //checks left-top:right-bottom Diagonal
            {
                if (IsCellCrossed(ir * NumberOfColumns + ic))
                {
                    DiagonalCount++;
                }
                else
                {
                    break;
                }
            }
            if (DiagonalCount == NumberOfColumns || DiagonalCount == NumberOfRows)
            {
                return true;
            }

            DiagonalCount = 0;
            for (int ir = 0, ic = NumberOfColumns - 1; ic >= 0 && ir < NumberOfRows; ir++, ic--) //checks right-top:left-bottom Diagonal
            {
                if (IsCellCrossed(ir * NumberOfColumns + ic))
                {
                    DiagonalCount++;
                }
                else
                {
                    break;
                }
            }
            if (DiagonalCount == NumberOfColumns || DiagonalCount == NumberOfRows)
            {
                return true;
            }

            int[] CheckedRows = new int[NumberOfRows];
            int[] CheckedCols = new int[NumberOfColumns];
            for (int ir = 0; ir < NumberOfRows; ir++)
            {
                for (int ic = 0; ic < NumberOfColumns; ic++)
                {
                    if (IsCellCrossed(ir * NumberOfColumns + ic))
                    {
                        CheckedRows[ir]++;
                        CheckedCols[ic]++;
                        if (CheckedRows[ir] == NumberOfRows || CheckedCols[ic] == NumberOfColumns)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        // to be implemented later
        private void GameOver()
        {
            BingoOccurred = true;
        }
    }
}

