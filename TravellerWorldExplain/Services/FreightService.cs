using TravellerWorldExplain.Models;

namespace TravellerWorldExplainer.Services
{
    public class FreightService : TravellerServiceBase
    {
        private string[] _freightRolls;
        private string[] freightTypes = new string[] { "Major", "Minor", "Incedental" };
        private int[] multiplier = new int[] { 10, 5, 1 };

        public FreightService() => LoadDefaultData();

        /// <summary>
        /// calculate the freight available
        /// </summary>
        /// <param name="world"></param>
        /// <param name="destinationPopulation"></param>
        /// <returns>list of available freights</returns>
        public List<string> LoadFreight(World world, int destinationPopulation)
        {
            List<string> freight = new List<string>();
            int pop = int.Parse(world.Population, System.Globalization.NumberStyles.HexNumber);
            string[] rolls = _freightRolls[pop].Split(new char[] { ',' });
            int freightTons = 0;
            for (int i = 0; i <= 2; i++)
            {
                freightTons = calculateRoll(rolls[i]);
                switch (destinationPopulation)
                {
                    case <= 4:
                        freightTons -= 3;
                        break;
                    case >= 8:
                        freightTons += 3;
                        break;
                   default:
                        break;
                }
                if (freightTons < 0)
                    freightTons = 0;
                freight.Add($"{freightTypes[i]}: {freightTons * multiplier[i]} dTons");
            }

            return freight;
        }

        private async Task LoadDefaultData()
        {
            _freightRolls = await LoadData("CTFreight.txt");
        }
    }
}
