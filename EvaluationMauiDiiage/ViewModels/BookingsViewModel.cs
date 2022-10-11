using EvaluationMauiDiiage.Models.Entities;
using EvaluationMauiDiiage.Services;
using Newtonsoft.Json;
using ReactiveUI;

namespace EvaluationMauiDiiage.ViewModels
{
    internal class BookingsViewModel : BaseViewModel
    {

        public BookingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            serviceSource = new ServiceSource();
            GetBookings = new DelegateCommand(async () => await GetBookingsCommand());
        }

        private ServiceSource serviceSource;
        public DelegateCommand GetBookings { get; }
        private IEnumerable<Booking> bookings;
        public IEnumerable<Booking> Bookings
        {
            get => bookings;
            set => this.RaiseAndSetIfChanged(ref bookings, value);
        }

        public async Task GetBookingsCommand()
        {
            string bookingsData = await serviceSource.GetSourceFileContent();
            bookings = JsonConvert.DeserializeObject<IEnumerable<Booking>>(bookingsData);
        }
    }
}
