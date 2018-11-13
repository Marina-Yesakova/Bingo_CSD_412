using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bingo_CSD_412.Models;

namespace Bingo_CSD_412.Controllers
{
    public class BoardsController : Controller
    {
        // GET: Boards/Create
        public ActionResult Generate()
        {
            Board board = new Board();
            return View(board);
        }

        // GET: Boards/Index/5
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}