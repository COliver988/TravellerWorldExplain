using System.Security.Cryptography;

namespace TravellerWorldExplainer.Services
{
    public class TravellerServiceBase
    {
        Random rnd = new Random();
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

        // calculate a die roll
        // format: nD-xD or nD, '-' = no roll
        public int calculateRoll(string dieRolls)
        {
            int d1, d2 = 0;
            if (dieRolls == "-")
              return 0;
            string[] rolls = dieRolls.Split(new char[] { '-' });
            Int32.TryParse(string.Concat(rolls[0].Where(char.IsDigit).ToArray()), out d1);
            if (rolls.Length == 2)
                Int32.TryParse(string.Concat(rolls[1].Where(char.IsDigit).ToArray()), out d2);
            int results = rollDice(d1) - rollDice(d2);
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
