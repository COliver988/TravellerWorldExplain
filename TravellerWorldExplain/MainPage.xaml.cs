using System.Text;
using TravellerWorldExplain.Models;
using TravellerWorldExplain.Services;

namespace TravellerWorldExplain;

public partial class MainPage : ContentPage
{
    public WorldService worldService;

    public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new World();
        worldService = new WorldService();
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
        List<string> explanation = worldService.explainWorld(world);
        world.Explanation = string.Join("\n", explanation.ToArray());
    }
}

