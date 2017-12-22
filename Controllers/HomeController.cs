using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetcore_img.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace dotnetcore_img.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult generate(int width, int height, string color)
        {
            Brush bColor = Brushes.White;
            color = color.ToUpper().Trim();
            switch (color)
            {
                case "RED":
                    bColor = Brushes.Red;
                    break;
                //put more cases for chosing brush for perticular color   
                default:
                    break;
            }

            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            Bitmap image1 = new Bitmap(width, height);

            using (Graphics grp = Graphics.FromImage(image1))
            {
                grp.FillRectangle(
                    bColor, 0, 0, image1.Width, image1.Height);
            }
            image1.Save(ms,ImageFormat.Jpeg);
            return new FileContentResult(ms.ToArray(),"image/jpg");
        }
    }  
}
