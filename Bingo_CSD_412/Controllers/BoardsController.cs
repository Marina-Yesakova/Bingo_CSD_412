using System;
using Microsoft.AspNetCore.Mvc;
using Bingo_CSD_412.Models;

namespace Bingo_CSD_412.Controllers
{
    public class BoardsController : Controller
    {
        //TODO implement connect to Database here and proper dependency injection for BoardManager into BoardsController 
        public static BoardManager boardManager = new BoardManager();

        // GET: Boards
        public ActionResult Index()
        {
            Board[] boards = boardManager.GetAllBoardsForUser("");
            return View(boards);
        }

        // GET: Boards/Generate/CSD_412
        public ActionResult Generate(String category)
        {
            Board board = boardManager.GenerateBoard(5, 5, category);
            // returning the details page of the new board
            return RedirectToAction(nameof(Details), new { boardId = board.BoardId });
        }

        // GET: Boards/Details/5
        public ActionResult Details(int boardId)
        {
            Board board = boardManager.GetBoardById(boardId);
            return View(board);
        }

        //logic for crossing the word in Board
        [HttpPost]
        public ActionResult CrossWord(int boardId, int wordIndex)
        {
            Board board = boardManager.CrossWordInBoard(boardId, wordIndex);
            // returning the details page of the new board
            return RedirectToAction(nameof(Details), new { boardId = board.BoardId });
        }
    }
}