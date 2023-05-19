using TravellerWorldExplain.Models;

namespace TravellerWorldExplain;

public partial class MainPage : ContentPage
{
    public string[] Atmospheres;

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
		this.BindingContext = new Worlds();
        _ = LoadDefaultData();
	}

    public async Task LoadDefaultData()
    {
        Atmospheres = await LoadData("Atmospheres.txt");
    }

    private void ExplainClicked(object sender, EventArgs e)
    {
		Worlds world = (Worlds)this.BindingContext;
		if (world == null)
		{
			DisplayAlert("Traveller World Explainer Error", "World is not set", "OK");
		}
		else if (!ValidateWorld(world))
		{
			DisplayAlert("Traveller World Explainer Error", "World is not valid", "OK");
		}
		else
			ExplainWorld(world);
    }

    private void ExplainWorld(Worlds world)
    {
        int size = int.Parse(world.Size, System.Globalization.NumberStyles.HexNumber);
        int atmo = int.Parse(world.Atmosphere, System.Globalization.NumberStyles.HexNumber);
        string atmosphere = Atmospheres[atmo].ToString();
        world.Explanation = $"Size: {size * 1000} km diameter\nAtmosphere: {atmosphere}";
    }

    private bool ValidateWorld(Worlds world)
    {
		return true;
    }
}

