using TravellerWorldExplain.Models;

namespace TravellerWorldExplainer.Services
{
    public class FreightService : TravellerServiceBase
    {
        private string[] _freightRolls;
        private string[] freightTypes = new string[] { "Major", "Minor", "Incidental" };
        private int[] multiplier = new int[] { 10, 5, 1 };

        public FreightService() => LoadDefaultData();

        /// <summary>
        /// calculate the freight available
        /// </summary>
        /// <param name="world"></param>
        /// <param name="destinationPopulation"></param>
        /// <remarks>the freight table indicates the number of lots per size to use</remarks>
        /// <returns>list of available freights</returns>
        public List<string> LoadFreight(World world, int destinationPopulation)
        {
            List<string> freight = new List<string>();
            int pop = int.Parse(world.Population, System.Globalization.NumberStyles.HexNumber);
            string[] rolls = _freightRolls[pop].Split(new char[] { ',' });
            int freightLots;
            for (int i = 0; i <= 2; i++)
            {
                freightLots = calculateRoll(rolls[i]);
                switch (destinationPopulation)
                {
                    case <= 4:
                        freightLots -= 3;
                        break;
                    case >= 8:
                        freightLots += 3;
                        break;
                   default:
                        break;
                }
                if (freightLots < 0)
                    freightLots = 0;
                for (int lots = 0; lots <= freightLots; lots++)
                {
                   freight.Add($"{freightTypes[i]}: {calculateRoll("1D") * multiplier[i]} dTons");
                }
            }

            return freight;
        }

        private async Task LoadDefaultData()
        {
            _freightRolls = await LoadData("CTFreight.txt");
        }
    }
}
