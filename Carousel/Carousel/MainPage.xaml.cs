using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carousel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Temperament";
            var temperaments = new List<Temperament>
            {
                new Temperament
                {
                    Name = "Choleric",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/07/male-3823124_1920-1536x1024.jpg", 
                    MoreInfoUrl = "https://example.com/choleric-test",
                    Description = "Cholerics are energetic, aggressive, and passionate."
                },
                new Temperament
                {
                    Name = "Melancholic",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Melancholy-man.jpg-1536x863.jpg",
                    MoreInfoUrl = "https://example.com/melancholic-test",
                    Description = "Melancholics are analytical, wise, and quiet."
                },
                new Temperament
                {
                    Name = "Sanguine",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Sanguine-temperament-1536x1022.jpg",
                    MoreInfoUrl = "https://example.com/sanguine-test",
                    Description = "Sanguines are social, charismatic, and lively."
                },
                new Temperament
                {
                    Name = "Phlegmatic",
                    ImageUrl = "https://heypersonality.com/wp-content/uploads/2020/08/Phlegmatic-temperament-1536x1024.jpg",
                    MoreInfoUrl = "https://example.com/phlegmatic-test",
                    Description = "Phlegmatics are relaxed, peaceful, and quiet."
                }
            };

            CarouselView carouselView = new CarouselView
            {
                ItemsSource = temperaments,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label { FontSize = 20, HorizontalOptions = LayoutOptions.Center };
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    var imageView = new Image { HeightRequest = 200, WidthRequest = 200, HorizontalOptions = LayoutOptions.Center };
                    imageView.SetBinding(Image.SourceProperty, "ImageUrl");
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        var temp = (Temperament)((Image)s).BindingContext;
                        DisplayAlert("Description", temp.Description, "OK");
                    };
                    imageView.GestureRecognizers.Add(tapGestureRecognizer);

                    var moreInfoLabel = new Label { TextColor = Color.Blue, HorizontalOptions = LayoutOptions.Center };
                    moreInfoLabel.SetBinding(Label.TextProperty, "MoreInfoUrl");

                    return new StackLayout
                    {
                        Children = { nameLabel, imageView, moreInfoLabel },
                        Spacing = 10
                    };
                })
            };

            Content = carouselView;
        }
    }
    public class Temperament
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string MoreInfoUrl { get; set; }
        public string Description { get; set; }
    }
}
