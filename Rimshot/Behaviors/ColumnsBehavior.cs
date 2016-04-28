using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rimshot.Behaviors
{
    public class ColumnsBehavior : DependencyObject
    { 
        public static int GetTargetItemWidth(UIElement element)
        {
            return (int)element.GetValue(TargetItemWidthProperty);
        }

        public static void SetTargetItemWidth(UIElement element, int value)
        {
            element.SetValue(TargetItemWidthProperty, value);
        }

        public static readonly DependencyProperty TargetItemWidthProperty =
                  DependencyProperty.RegisterAttached("TargetItemWidth",
                  typeof(int), typeof(ColumnsBehavior),
                  new PropertyMetadata(10, OnTargetItemWidthChanged));

        private static void OnTargetItemWidthChanged(object sender,
                          DependencyPropertyChangedEventArgs e)
        {
            (sender as GridView).SizeChanged += ColumnsBehavior_SizeChanged;
        }

        private static void ColumnsBehavior_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double margin = 6.0;

            var panel = (sender as GridView)?.ItemsPanelRoot;
            double columns = Math.Floor(e.NewSize.Width / (int)(sender as GridView).GetValue(TargetItemWidthProperty));

            if (panel != null)
            {
                var width = (e.NewSize.Width - margin) / columns;

                if (panel.GetType() == typeof(VariableSizedWrapGrid))
                {
                    if (width > 20) (panel as VariableSizedWrapGrid).ItemWidth = width;
                    if (width > 20) (panel as VariableSizedWrapGrid).ItemHeight = width / 4;
                }
                else
                {
                    if (width > 20) (panel as ItemsWrapGrid).ItemWidth = width;
                }
            }
        }
    }
}
