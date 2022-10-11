using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.ViewModels;

namespace EvaluationMauiDiiage.Views;

public partial class MainPage : ContentPage
{
	public List<RdvEntity> Rdvs { get; set; }
	public MainPage()
	{
		BindingContext = this;
		this.Rdvs = new List<RdvEntity>()
		{
			new RdvEntity()
			{
				Id = 1,
				Name = "Rdv1",
				Date = DateTime.Now

			},
			new RdvEntity()
			{
				Id=2,
				Name= "Rdv2",
				Date = DateTime.Now
			},
			new RdvEntity()
			{
				Id=3,
				Name= "Rdv3",
				Date= DateTime.Now
			}
		};
		InitializeComponent();
	}




}
