using Microsoft.Practices.ServiceLocation;
using Rimshot.Behaviors;
using Rimshot.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rimshot.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
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

        private void OnImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    var name = (sender as GridView).Name;
        //    var panel = (ItemsWrapGrid)(sender as GridView).ItemsPanelRoot;

        //    double margin = 6.0;
        //    int columns = 3;

        //    switch (name)
        //    {
        //        case "ConcertsGridView":
        //            columns = 3;
        //            panel.ItemWidth = (e.NewSize.Width - margin) / (double)columns;
        //            break;

        //        case "ArtistsGridView":
        //            columns = 6;
        //            panel.ItemWidth = (e.NewSize.Width - margin) / (double)columns;
        //            break;
        //    }
        //}

        private async void OnQuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var query = args.QueryText;
            await Default.Search(query);
        }

        private void OnStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            //foreach (var sbase in e.NewState.Setters)
            //{
            //    var setter = sbase as Setter;
            //    var spath = setter.Target.Path.Path;
            //    var element = setter.Target.Target as FrameworkElement;

            //    if (spath.Contains(nameof(ColumnsBehavior)))
            //    {
            //        string property = spath.Split('.').Last().TrimEnd(')');

            //        var prop = typeof(ColumnsBehavior).GetMethod($"Set{property}");

            //        prop.Invoke(null, new object[] { element, setter.Value });
            //    }
            //}
            switch (e.NewState.Name)
            {
                case "Small":
                    ArtistsGridView.SetValue(ColumnsBehavior.FixedColumnsProperty, 2);
                    break;
                case "Medium":
                    ArtistsGridView.SetValue(ColumnsBehavior.FixedColumnsProperty, 2);
                    break;
                case "Wide":
                    ArtistsGridView.SetValue(ColumnsBehavior.FixedColumnsProperty, 4);
                    break;
                case "SuperWide":
                    ArtistsGridView.SetValue(ColumnsBehavior.FixedColumnsProperty, 6);
                    break;
            }
        }
    }
}
