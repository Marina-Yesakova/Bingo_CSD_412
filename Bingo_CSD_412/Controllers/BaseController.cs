using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Bingo_CSD_412.Controllers
{
    public abstract class BaseController : Controller
    {
        public bool ReturnJson()
        {
            StringValues acceptEncoding;
            bool returnJson = false;
            if (Request.Headers.TryGetValue("accept", out acceptEncoding))
            {
                foreach (String a in acceptEncoding)
                {
                    if (a.ToLower().Equals("application/json"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}