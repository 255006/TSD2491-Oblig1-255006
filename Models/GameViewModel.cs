using System.Numerics;

namespace WebApplicationTest.Models
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
    }
}
