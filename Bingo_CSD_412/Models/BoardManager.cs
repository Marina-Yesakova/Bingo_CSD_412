using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo_CSD_412.Models
{
    public class BoardManager
    {
        public Board GenerateBoard(int numberOfRows, int numberOfColumns, String category)
        {
            //TODO implement logic or migrate from Board class
            return new Board();
        }

        public Board GetBoardById(int boardId)
        {
            //TODO implement logic
            return new Board();
        }

        public Board[] GetAllBoardsForUser(String userName)
        {
            //TODO implement logic

            return new[] { new Board() };
        }

        //logic for crossing the word in Board
        public Board CrossWordInBoard(int boardId, int wordIndex)
        {
            //TODO implement logic
            return new Board();
        }
    }
}
