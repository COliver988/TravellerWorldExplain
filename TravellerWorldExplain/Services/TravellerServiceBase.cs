using System.Security.Cryptography;

namespace TravellerWorldExplainer.Services
{
    public class TravellerServiceBase
    {
        Random rnd = new Random();
        /// <summary>
        /// load text data from the Raw directory
        /// </summary>
        /// <param name="fileName" text name of the file></param>
        /// <returns>array of strings</returns>
        public async Task<string[]> LoadData(string fileName)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
            using StreamReader reader = new StreamReader(fileStream);

            List<string> lines = new();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line[0] != '#') lines.Add(line);
            }

            return lines.ToArray();
        }

        /// <summary>
        /// calculate a die roll based on a text string
        /// format: nD-xD or nD, '-' = no roll
        ///         nD+xD, nD+x
        ///         nD-x where x is a simple number
        /// </summary>
        /// <param name="dieRolls"></param>
        /// <returns>int results</returns>
        public int calculateRoll(string dieRolls)
        {
            int d1, d2 = 0;
            if (dieRolls == "-")
              return 0;
            string[] rolls = dieRolls.Split(new char[] { '-', '+' });
            bool isSubtract = dieRolls.Contains("-");
            Int32.TryParse(string.Concat(rolls[0].Where(char.IsDigit).ToArray()), out d1);
            if (rolls.Length == 2)
                Int32.TryParse(string.Concat(rolls[1].Where(char.IsDigit).ToArray()), out d2);
            if (rolls[1].Contains("D"))
                d2 = rollDice(d2);
            int results = isSubtract ? rollDice(d1) - (d2) : rollDice(d1) + d2;
            if (results < 0)
                return 0;
            else
                return results;
        }

        private int rollDice(int dice)
        {
            int results = 0;
            for (int i = 0; i < dice; i++)
            {
              results += rnd.Next(1, 6);
            }
            return results;
        }
    }
}
