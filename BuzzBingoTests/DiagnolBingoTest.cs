using Bingo_CSD_412.Models;
using System;
using Xunit;

namespace BuzzBingoTests
{
    public class DiagnolBingoTest
    {
        [Fact]
        public void RightDiagonal()
        {
            Board board = new Board();
            board.CellSelect(0);
            board.CellSelect(6);
            board.CellSelect(12);
            board.CellSelect(18);
            board.CellSelect(24);

            Assert.True(board.BingoOccurred);
        }
    }

}
