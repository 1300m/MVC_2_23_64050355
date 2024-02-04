using Microsoft.AspNetCore.Mvc;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class KaraokeController : Controller
    {
        private readonly ApplicationDBContext _db;

        public KaraokeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Karaoke obj)
        {
            //if (ModelState.IsValid)
            //{
                if (obj.Singer3 != null) 
                { 
                    obj.Score = getScore3Singer(obj);
                }
                else if (obj.Singer2 != null)
                {
                    obj.Score = getScore2Singer(obj);
                }
                else
                {
                    obj.Score = getScore1Singer(obj);
                }

                _db.Karaokes.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Detail");
            //}

            //return View(obj);
        }

        public IActionResult Detail()
        {
            IEnumerable<Karaoke> allKaraoke = _db.Karaokes;
            return View(allKaraoke);
        }

        public double getScore1Singer(Karaoke obj)
        {
            IEnumerable<Karaoke> allKaraoke = _db.Karaokes;
            double score = 0;

            foreach (Karaoke k in allKaraoke)
            {
                if (obj.Id == k.Id) { break; }
                    score += k.Score;
            }

            score %= 100;

            return score;
        }

        public double getScore2Singer(Karaoke obj)
        {
            double score = obj.SongDuration * (obj.Singer1.Length + obj.Singer2.Length);
            score %= 100;

            return score;
        }

        public double getScore3Singer(Karaoke obj)
        {
            IEnumerable<Karaoke> allKaraoke = _db.Karaokes;
            int previousCnt = 0;
            int presentCnt = 0;

            foreach (Karaoke k in allKaraoke)
            {
                if (obj.Id == k.Id)
                {
                    presentCnt += k.Singer1.Length + k.Singer2.Length + k.Singer3.Length;
                    break;
                }
                previousCnt += k.Singer1.Length + k.Singer2.Length + k.Singer3.Length;
            }
            
            double score = previousCnt * (previousCnt + presentCnt);
            score %= 100;

            return score;
        }
    }
}
