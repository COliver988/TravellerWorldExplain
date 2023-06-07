using TravellerWorldExplain.Models;

namespace TravellerWorldExplain.Services
{
    public class WorldService
    {
        private string[] _atmospheres;
        private string[] _starports;
        private string[] _governments;
        private string[] _lawLevels;
        private string[] _techLevels;
        private string[] _tradeCodes;

        public WorldService() => LoadDefaultData();

        public List<string> explainWorld(World world)
        {
            List<string> explanation = new List<string>();
            explanation.Add(LoadPortDefinition(world.Starport[0]));
            int size = int.Parse(world.Size, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Size: {size * 1000} km diameter");
            int atmo = int.Parse(world.Atmosphere, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Atmosphere: {_atmospheres[atmo].ToString()}");
            int hydro = int.Parse(world.Hydrographics, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Hydrographics: {hydro * 10}% +/- 5%");
            int pop = int.Parse(world.Population, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Population: {Math.Pow(10, pop)}");
            int govt = int.Parse(world.Government, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Government: {_governments[govt].ToString()}");
            int law = int.Parse(world.LawLevel, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Law Level: {_lawLevels[law].ToString()}");
            int tech = int.Parse(world.TechLevel, System.Globalization.NumberStyles.HexNumber);
            explanation.Add($"Tech Level: {_techLevels[tech].ToString()}");
            explanation.Add(LoadTradeCodes(world));
            return explanation;
        }

        private string LoadPortDefinition(char starport)
        {
            foreach (string portDefinition in _starports)
            {
                if (portDefinition[0] == starport)
                    return portDefinition;
            }
            return "Starport definition not found";
        }

        private string LoadTradeCodes(World world)
        {
            string results = "";
            foreach (string code in _tradeCodes)
            {
                string[] info = code.Split(new char[] { ' ', ',' });
                string tc = info[0];  // trade code
                string desc = info[1];
            }
            return results;
        }
        private async Task<string[]> LoadData(string fileName)
        {
            if (fileName == "CTTradeCodes.txt")
            {
                var hello = "hi!";
            }
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

        private async Task LoadDefaultData()
        {
            _atmospheres = await LoadData("Atmospheres.txt");
            _governments = await LoadData("Governments.txt");
            _starports = await LoadData("Starports.txt");
            _lawLevels = await LoadData("LawLevels.txt");
            _techLevels = await LoadData("TechLevels.txt");
            _tradeCodes = await LoadData("CTTradeCodes.txt");
        }
    }

}
