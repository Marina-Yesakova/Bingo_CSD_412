
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo_CSD_412.Models
{
    public class BoardManager
    {
        // TODO: this should be implemented in database
        private static IDictionary<int, Board> boards = new Dictionary<int, Board>();

        public Board GenerateBoard(int numberOfRows, int numberOfColumns, String category, int Size, List<Word> table)
        {
            //TODO implement logic or migrate from Board class
            Board b = new Board(Size, table);
            b.Category = category;
            boards[b.BoardId] = b;
            return b;
        }

        public Board GetBoardById(int boardId)
        {
            return boards[boardId];
        }

        public Board[] GetAllBoardsForUser(String userName)
        {
            //TODO implement logic
            return boards.Values.ToArray<Board>();
        }

        //logic for crossing the word in Board
        public Board CrossWordInBoard(int boardId, int wordIndex)
        {
            Board b = boards[boardId];
            b.CellSelect(wordIndex);
            return b;
        }


    }
}
