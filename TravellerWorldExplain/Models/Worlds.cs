using Nogginbox.MyApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravellerWorldExplain.Models
{
    internal class Worlds : ObservableViewModelBase
    {
        private string _starport;
        private string _size;
        private string _atmosphere;
        private string _hydrographics;
        private string _population;
        private string _government;
        private string _lawlevel;
        private string _techlevel;
        private List<string> _explanation;

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
        public List<string> Explanation
        {
            get => _explanation;
            set => SetProperty(ref _explanation, value);
        }
    }
}
