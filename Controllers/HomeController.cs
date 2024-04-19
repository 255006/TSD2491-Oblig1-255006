using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_Oblig1_255006.Models;

namespace TSD2491_Oblig1_255006.Controllers
{
    public class HomeController : Controller
    {
        private static List<List<string>> emoijList = GameViewModel.emoijLists;
        private static List<string> shuffledAnimals = new List<string>();

        public IActionResult Index()
        {
            SetUpGameIfNeeded();
            var model = new GameViewModel
            {
                ShuffledAnimals = shuffledAnimals,
            };

            return View(model);
        }

        private void SetUpGameIfNeeded()
        {
            // Check if the game is set up
            if (HttpContext.Session.GetString("isGameSetUp") == null)
            {
                SetUpGame();
                HttpContext.Session.SetString("isGameSetUp", "true"); // Set the game as started
            }
        }

        private void SetUpGame()
        {
            Random random = new Random();
            int randomListNumber = random.Next(0, emoijList.Count);

            shuffledAnimals = emoijList[randomListNumber].OrderBy(item => random.Next()).ToList();
        }

    }
}
