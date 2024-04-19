using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_Oblig1_255006.Models;

namespace TSD2491_Oblig1_255006.Controllers
{
    public class HomeController : Controller
    {
        private static List<List<string>> emoijList = GameViewModel.emoijLists;
        private static List<string> shuffledAnimals = new List<string>();
        private static int matchesFound = 0;

        public IActionResult Index()
        {
            SetUpGameIfNeeded();

            var gameState = HttpContext.Session.GetString("gameState") ?? "notStarted"; // Get the game state from session

            var model = new GameViewModel
            {
                ShuffledAnimals = shuffledAnimals,
                MatchesFound = matchesFound,
                GameState = gameState, // This is the text "GAME RUNNING", "GAME COMPLETED", "START GAME"
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ButtonClick(string animal, string animalDescription)
        {

            var lastAnimalFound = HttpContext.Session.GetString("lastAnimalFound");
            var lastDescription = HttpContext.Session.GetString("lastDescription");

            if (string.IsNullOrEmpty(lastAnimalFound))
            {
                HttpContext.Session.SetString("gameState", "running");
                // If this is your first click, save the selected animal and its description in the session
                if (!string.IsNullOrEmpty(animal))
                {
                    HttpContext.Session.SetString("lastAnimalFound", animal);
                    HttpContext.Session.SetString("lastDescription", animalDescription);
                }
            }
            else
            {
                // Check if a pair is found
                if (lastAnimalFound == animal && lastDescription != animalDescription)
                {
                    // Logic for finding a pair
                    matchesFound++;
                    HttpContext.Session.SetString("lastAnimalFound", string.Empty); // Restart session
                    HttpContext.Session.SetString("lastDescription", string.Empty); // Restart session

                    // Remove the found animal from the list
                    shuffledAnimals = shuffledAnimals.Select(a => a.Replace(animal, null)).ToList();

                    if (matchesFound == 8)
                    {
                        SetUpGame(); // Restart game
                        HttpContext.Session.SetString("gameState", "completed");

                    }
                    else
                    {
                        // No pair found, reset selected animal
                        HttpContext.Session.SetString("lastAnimalFound", string.Empty);
                        HttpContext.Session.SetString("lastDescription", string.Empty);
                    }
                }
                else
                {
                    HttpContext.Session.SetString("lastAnimalFound", string.Empty);
                    HttpContext.Session.SetString("lastDescription", string.Empty);
                }
            }

            return RedirectToAction("Index");
        }

        private void SetUpGameIfNeeded()
        {
            // Game logic checking if game is set up
            if (HttpContext.Session.GetString("isGameSetUp") == null)
            {
                SetUpGame();
                HttpContext.Session.SetString("isGameSetUp", "true"); // Game is set up 
                HttpContext.Session.SetString("gameState", "notStarted"); // Set game as not started yet "START GAME" text
            }
            else
            {
                var currentState = HttpContext.Session.GetString("gameState") ?? "notStarted";
                HttpContext.Session.SetString("gameState", currentState);
            }
        }

        private void SetUpGame()
        {
            Random random = new Random();
            int randomListNumber = random.Next(0, emoijList.Count);

            shuffledAnimals = emoijList[randomListNumber].OrderBy(item => random.Next()).ToList();

            matchesFound = 0;
            HttpContext.Session.SetString("gameState", "running");
        }

    }
}
