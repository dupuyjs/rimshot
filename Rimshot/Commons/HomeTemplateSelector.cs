using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rimshot.Commons
{
    public class HomeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OriginalTemplate { get; set; }
        public DataTemplate OnTourTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var dataItem = item as ArtistExt;
            var uiElement = container as UIElement;

            if (!string.IsNullOrEmpty(dataItem.OnTourUntil))
            {
                VariableSizedWrapGrid.SetRowSpan(uiElement, 8);
                return OnTourTemplate;
            }

            VariableSizedWrapGrid.SetRowSpan(uiElement, 6);
            return OriginalTemplate;
        }
    }
}
