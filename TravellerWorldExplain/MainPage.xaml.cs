using System.Text;
using TravellerWorldExplain.Models;
using TravellerWorldExplain.Services;

namespace TravellerWorldExplain;

public partial class MainPage : ContentPage
{
    public WorldService worldService;
	private World _world;

    public MainPage()
	{
		InitializeComponent();
		_world = new World();
		this.BindingContext = _world;
        worldService = new WorldService();
	}

	private bool validateWorld()
	{ 
		if (_world == null)
		{
			DisplayAlert("Traveller World Explainer Error", "World is not set", "OK");
			return false;
		}
		else if (!_world.Is_Valid())
		{
			DisplayAlert("Traveller World Explainer Error", "World is not valid", "OK");
			return false;
		}
        return true;
        }
  
    private void ExplainClicked(object sender, EventArgs e)
    {
		if (validateWorld())
		{
			ExplainWorld(_world);
		}
    }

    private void ExplainWorld(World world)
    {
        List<string> explanation = worldService.explainWorld(world);
        world.Explanation = string.Join("\n", explanation.ToArray());
    }

    private void PassengerClick(object sender, EventArgs e)
    {
		if (validateWorld())
		{
			ExplainWorld(_world);
		}
    }
}

