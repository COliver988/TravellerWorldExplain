using Microsoft.Maui.Platform;
using Nogginbox.MyApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace TravellerWorldExplain.Models
{
    public class World : ObservableViewModelBase
    {
        private string _starport;
        private string _size;
        private string _atmosphere;
        private string _hydrographics;
        private string _population;
        private string _government;
        private string _lawlevel;
        private string _techlevel;
        private string _explanation;

        public World() { }

        // assumes A123456-7 formatting
        public World(string UWP = null)
        {
            if (!string.IsNullOrEmpty(UWP))
            {
                _starport = UWP[0].ToString();
                _size = UWP[1].ToString();
                _atmosphere = UWP[2].ToString();
                _hydrographics = UWP[3].ToString();
                _population = UWP[4].ToString();
                _government = UWP[5].ToString();
                _lawlevel = UWP[6].ToString();
                _techlevel = UWP[8].ToString();
            }
        }
        public string Starport
        { 
            get => _starport;
            set => SetProperty(ref _starport, value);
        }
        public string Size
        { 
            get => _size;
            set => SetProperty(ref _size, value);
        }
        public string Atmosphere
        {  
            get => _atmosphere;
            set => SetProperty(ref _atmosphere, value);
        }
        public string Hydrographics
        {
            get => _hydrographics;
            set => SetProperty(ref _hydrographics, value);
        }
        public string Population
        {  
            get => _population;
            set => SetProperty(ref _population, value);
        }
        public string LawLevel
        {  
            get => _lawlevel;
            set => SetProperty(ref _lawlevel, value);
        }
        public string Government
        {  
            get => _government;
            set => SetProperty(ref _government, value);
        }
        public string TechLevel
        {  
            get => _techlevel;
            set => SetProperty(ref _techlevel, value);
        }

        [NotMapped]
        public string Explanation
        {
            get => _explanation;
            set => SetProperty(ref _explanation, value);
        }

        public bool Is_Valid()
        {
            Regex starportRange = new Regex("^[A-F, X]+$");
            if (string.IsNullOrEmpty(this._starport))
                return false;
            if (!starportRange.IsMatch(this._starport))
                return false;
            return true;
        }
    }
}
