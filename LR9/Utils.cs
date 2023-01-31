using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9
{
    class Utils
    {
        public static List<char> mBadSymbols = new List<char>()
        { 
            ';', ',', '.', '!', '@', '#', '$',
            '%', '^', '&', '*', '(', ')', '-', 
            '_', '/', '\\', '>', '<', ':', '?', 
            '[', ']', '{', '}'
        };

        public static string ConvertColorToString(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return "Белый";

                case Color.Red:
                    return "Красный";

                case Color.Purple:
                    return "Фиолетовый";

                case Color.Green:
                    return "Зеленый";

                case Color.Grey:
                    return "Серый";

                case Color.Unknown:
                default:
                    return "Неопознанный";
            }
        }

        public static bool IsNumberValid(string number)
        {
            if(number.Length == 0)
            {
                return false;
            }

            foreach(var a in mBadSymbols)
            {
                if (number.Contains(a))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
