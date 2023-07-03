using Nogginbox.MyApp.ViewModels;
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
        private List<string> _tradeCodes;

        public World() { }

        // assumes A123456-7 formatting
        // TODO: need to verify input if not null!
        public World(string UWP = null)
        {
            if (!string.IsNullOrEmpty(UWP) && UWP.Length == 9)
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

        [NotMapped]
        public List<string> tradeCodes
        {
            get => _tradeCodes;
            set => SetProperty(ref _tradeCodes, value);
        }

        public bool Is_Valid()
        {
            Regex starportRange = new Regex("^[A-F, X]+$");
            Regex worldRange = new Regex("^[A-F0-9]+$");
            Regex hydroRange = new Regex("^[0-9, A]+$");
            Regex techRange = new Regex("^[0-9A-H]+$");
            Regex lawRange = new Regex("^[0-9]+$");
            if (string.IsNullOrEmpty(this._starport))
                return false;
            if (!starportRange.IsMatch(this._starport))
                return false;
            if (string.IsNullOrEmpty(this._size))
                return false;
            if (!worldRange.IsMatch(this._size))
                return false;
            if (string.IsNullOrEmpty(this._atmosphere))
                return false;
            if (!worldRange.IsMatch(this._atmosphere))
                return false;
            if (string.IsNullOrEmpty(this._hydrographics))
                return false;
            if (!hydroRange.IsMatch(this._hydrographics))
                return false;
            if (string.IsNullOrEmpty(this._population))
                return false;
            if (!worldRange.IsMatch(this._population))
                return false;
            if (string.IsNullOrEmpty(this._government))
                return false;
            if (!lawRange.IsMatch(this._lawlevel))
                return false;
            if (string.IsNullOrEmpty(this._lawlevel))
                return false;
            if (!worldRange.IsMatch(this._lawlevel))
                return false;
            if (string.IsNullOrEmpty(this._techlevel))
                return false;
            if (!techRange.IsMatch(this._techlevel))
                return false;
            return true;
        }
    }
}
