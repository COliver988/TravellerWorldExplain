using System.Text;
using TravellerWorldExplain.Models;

namespace TravellerWorldExplain;

public partial class MainPage : ContentPage
{
    public string[] Atmospheres;
    public string[] Starports;
    public string[] Governments;
    public string[] LawLevels;
    public string[] TechLevels;

    public async Task<string[]> LoadData(string filePath)
    {
        // Open the source file
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
        using StreamReader reader = new StreamReader(fileStream);

        // Create a list to store the lines
        List<string> lines = new List<string>();

        // Read the file line by line and add to the list
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }

        // Convert the list to an array and return it
        return lines.ToArray();
    }

    public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new World();
        _ = LoadDefaultData();
	}

    public async Task LoadDefaultData()
    {
        Atmospheres = await LoadData("Atmospheres.txt");
        Governments = await LoadData("Governments.txt");
        Starports = await LoadData("Starports.txt");
        LawLevels = await LoadData("LawLevels.txt");
        TechLevels = await LoadData("TechLevels.txt");
    }

    private void ExplainClicked(object sender, EventArgs e)
    {
		World world = (World)this.BindingContext;
		if (world == null)
		{
			DisplayAlert("Traveller World Explainer Error", "World is not set", "OK");
		}
		else if (!world.Is_Valid())
		{
			DisplayAlert("Traveller World Explainer Error", "World is not valid", "OK");
		}
		else
			ExplainWorld(world);
    }

    private void ExplainWorld(World world)
    {
        List<string> explanation = new List<string>();
        explanation.Add(LoadPortDefinition(world.Starport[0]));
        int size = int.Parse(world.Size, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Size: {size * 1000} km diameter");
        int atmo = int.Parse(world.Atmosphere, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Atmosphere: {Atmospheres[atmo].ToString()}");
        int hydro = int.Parse(world.Hydrographics, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Hydrographics: {hydro * 10}% +/- 5%");
        int pop = int.Parse(world.Population, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Population: {Math.Pow(10, pop)}");
        int govt = int.Parse(world.Government, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Government: {Governments[govt].ToString()}");
        int law = int.Parse(world.LawLevel, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Law Level: {LawLevels[law].ToString()}");
        int tech = int.Parse(world.TechLevel, System.Globalization.NumberStyles.HexNumber);
        explanation.Add($"Tech Level: {TechLevels[tech].ToString()}");
        explanation.Add(LoadTradeCodes(world));
        world.Explanation = string.Join("\n", explanation.ToArray());
    }

    private string LoadTradeCodes(World world)
    {
        return "trade codes here";
    }

    private string LoadPortDefinition(char starport)
    {
        foreach (string portDefinition in Starports)
        {
            if (portDefinition[0] == starport)
                return portDefinition;
        }
        return "Starport definition not found";
    }

    private bool ValidateWorld(World world)
    {
		return true;
    }
}

