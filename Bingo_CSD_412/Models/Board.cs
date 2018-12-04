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
            if (CheckForBingo(index))
            {
                GameOver();
            }
        }

        public bool IsCellCrossed(int index)
        {
            return FunctionalBoard[index];
        }

        private bool CheckForBingo(int index)
        {
            int ColumnCount = 0; //validation varible 
            int RowCount = 0;
            int DiagonalCount = 0;
            int RowPosition = 0;
            int DiagonalPosition = 0;

            while (index >= NumberOfColumns)
            {
                RowPosition++;
                index -= NumberOfColumns; //Sets index to point the earliest value in the column
            }

            int TempIndex = index;
            for (int i = 0; i < NumberOfRows; i++) //Checks columns
            {
                if (IsCellCrossed(TempIndex)) //if column is crossed
                {
                    ColumnCount++;
                }
                TempIndex += NumberOfColumns;
            }

            if (RowPosition == index) //checks right Diagonal
            {
                for (int i = 0; i < NumberOfColumns; i++)
                {
                    if (IsCellCrossed(DiagonalPosition))
                    {
                        DiagonalCount++;
                        DiagonalPosition += NumberOfColumns + 1;
                    }
                }
            }
            else if (RowPosition + index == NumberOfRows - 1) //checks left Diagonal
            {
                DiagonalPosition = Size - NumberOfColumns;
                for (int i = 0; i < NumberOfColumns; i++)
                {
                    if (IsCellCrossed(DiagonalPosition))
                    {
                        DiagonalCount++;
                    }
                    DiagonalPosition -= NumberOfColumns - 1;
                }
            }
            index = RowPosition * NumberOfColumns;

            for (int i = index; i < NumberOfColumns + index; i++) //checks rows
            {
                if (IsCellCrossed(i))
                {
                    RowCount++;
                }
            }

            if (ColumnCount == NumberOfRows || RowCount == NumberOfColumns || DiagonalCount == NumberOfColumns) //if any of the three condition were true return true
            {
                return true;
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

