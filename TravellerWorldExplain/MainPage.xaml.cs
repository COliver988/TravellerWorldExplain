using System.Text;
using TravellerWorldExplain.Models;
using TravellerWorldExplain.Services;
using TravellerWorldExplainer.Services;

namespace TravellerWorldExplain;

public partial class MainPage : ContentPage
{
    private WorldService worldService;
	private PassengerService passengerService;
	private FreightService freightService;
	private World _world;

    public MainPage()
	{
		InitializeComponent();
		_world = new World();
		this.BindingContext = _world;
        worldService = new WorldService();
		passengerService = new PassengerService();
		freightService = new FreightService();
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
        _world.Explanation = string.Join("\n", explanation.ToArray());
    }

    private async void PassengerClick(object sender, EventArgs e)
    {
        if (validateWorld())
		{
			int destinationPop = await getDestinationPopulationAsync();
			List<string> population = passengerService.LoadPassengers(_world, destinationPop);
			_world.Explanation = string.Join("\n", population.ToArray());
		}
    }

	private async Task<int> getDestinationPopulationAsync()
	{
		int pop = 0;
		string result = await DisplayPromptAsync("Query", "Destination system population", "OK");
		int.TryParse(result, out pop);
		return pop;
    }

    private async void FreightClick(object sender, EventArgs e)
    {
        if (validateWorld())
		{
			int destinationPop = await getDestinationPopulationAsync();
			List<string> freight = freightService.LoadFreight(_world, destinationPop);
			_world.Explanation = string.Join("\n", freight.ToArray());
		}
    }
}

