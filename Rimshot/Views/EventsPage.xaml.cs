using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;
using Rimshot.Services;
using Rimshot.ViewModels;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rimshot.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class EventsPage : Page
    {
        public EventsPage()
        {
            this.InitializeComponent();
        }

        public MainViewModel Default
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventExt concert = MasterListEvents.SelectedItem as EventExt;
            await Default.LoadConcertDetails(concert);

            //Default.Artist = concert.Performances[0].Artist;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var item = ListPerformances.SelectedItem;
            this.Frame.Navigate(typeof(ArtistsPage), item);
        }

        private void OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            var image = new BitmapImage(new Uri("ms-appx:///Assets/Common/event.jpg", UriKind.Absolute));
            ((ImageBrush)sender).ImageSource = image;
        }
    }
}
