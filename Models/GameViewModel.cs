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

        public static List<string> foodEmoij = new List<string>
        {
            "🍎", "🍎",
            "🍌", "🍌",
            "🍓", "🍓",
            "🍇", "🍇",
            "🍉", "🍉",
            "🍒", "🍒",
            "🍍", "🍍",
            "🥑", "🥑",
        };

        public static List<string> thingsEmoij = new List<string>
        {
            "⚽", "⚽",
            "🏀", "🏀",
            "🚗", "🚗",
            "🚲", "🚲",
            "🏍", "🏍",
            "🎸", "🎸",
            "📱", "📱",
            "💻", "💻",
        };

        private static List<string> vehicleEmoji = new List<string>
        {
            "🚂", "🚂",
            "🚀", "🚀",
            "🚁", "🚁",
            "⛵", "⛵",
            "🚜", "🚜",
            "🛴", "🛴",
            "🚲", "🚲",
            "🛵", "🛵",
        };

        private static List<string> natureEmoji = new List<string>
        {
            "🌳", "🌳",
            "🌻", "🌻",
            "🌷", "🌷",
            "🍁", "🍁",
            "🌵", "🌵",
            "🌊", "🌊",
            "🌑", "🌑",
            "🌞", "🌞",
        };

        private static List<string> professionEmoji = new List<string>
        {
            "👩‍⚕️", "👩‍⚕️",
            "👨‍🍳", "👨‍🍳",
            "👩‍🏫", "👩‍🏫",
            "👨‍🚒", "👨‍🚒",
            "👷‍", "👷‍",
            "👨‍🔧", "👨‍🔧",
            "👩‍💼", "👩‍💼",
            "👨‍💻", "👨‍💻",
        };


        public static List<List<string>> emoijLists = new List<List<string>>
        {
            animalEmoij, foodEmoij, thingsEmoij, vehicleEmoji, natureEmoji, professionEmoji,
        };

        public List<string> ShuffledAnimals { get; set; }
        public int MatchesFound { get; set; }
    }
}
