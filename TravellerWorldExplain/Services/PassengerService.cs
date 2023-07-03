using TravellerWorldExplain.Models;

namespace TravellerWorldExplainer.Services
{
    public class PassengerService : TravellerServiceBase
    {
        private string[] _passengerRolls;
        private string[] passengerTypes = new string[] { "High passage: ", "Mid passage: ", "Low passage:" };

        public PassengerService() => LoadDefaultData();

        public List<string> LoadPassengers(World world, int destinationPopulation)
        {
            List<string> passengers = new List<string>();
            int pop = int.Parse(world.Population, System.Globalization.NumberStyles.HexNumber);
            string[] rolls = _passengerRolls[pop].Split(new char[] { ',' });
            int passengerCount = 0;
            for (int i = 0; i <= 2; i++)
            {
                passengerCount = calculateRoll(rolls[i]);
                switch (destinationPopulation)
                {
                    case <= 4:
                        passengerCount -= 3;
                        break;
                    case >= 8:
                        passengerCount += 3;
                        break;
                   default:
                        break;
                }
                passengers.Add($"{passengerTypes[i]} {passengerCount}");
            }

            return passengers;
        }

        private async Task LoadDefaultData()
        {
            _passengerRolls = await LoadData("CTPassengers.txt");
        }
    }
}
