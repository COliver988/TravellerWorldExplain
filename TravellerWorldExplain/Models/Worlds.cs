using Nogginbox.MyApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravellerWorldExplain.Models
{
    internal class Worlds : ObservableViewModelBase
    {
        private string _atmosphere;
        private string _explanation;

        public string Starport { get; set; }
        public string Size { get; set; }
        public string Atmosphere
        {  get => _atmosphere;
           set => SetProperty(ref _atmosphere, value);
        }
        public string Hydrographics { get; set; }
        public string Population { get; set; }
        public string LawLevel { get; set; }
        public string Government { get; set; }
        public string TechLevel { get; set; }

        [NotMapped]
        public string Explanation
        {
            get => _explanation;
            set => SetProperty(ref _explanation, value);
        }
    }
}
