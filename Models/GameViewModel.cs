using System.Numerics;

namespace TSD2491_Oblig1_255006.Models
{
    public class GameViewModel
    {
        public static List<string> animalEmoij = new List<string>
        {
            "🐶", "🐶",
            "🐺", "🐺",
            "🐮", "🐮",
            "🦊", "🦊",
            "🐱", "🐱",
            "🦁", "🦁",
            "🐯", "🐯",
            "🐭", "🐭",
        };

        public static List<List<string>> emoijLists = new List<List<string>>
        {
            animalEmoij,
        };

        public List<string> ShuffledAnimals { get; set; }
    }
}
