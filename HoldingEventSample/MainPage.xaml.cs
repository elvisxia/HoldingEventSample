using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HoldingEventSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void bt1_Holding(object sender, HoldingRoutedEventArgs e)
        {
            if (e.HoldingState == HoldingState.Started && (((Button)sender).Tag == null || !((Button)sender).Tag.Equals("Marked")))
            {
                setMarked((Button)sender);
            }
            else if (e.HoldingState == HoldingState.Started)
            {
                unmark((Button)sender);
            }
        }

        private void unmark(Button sender)
        {
            sender.Tag = null;
            foreach (UIElement u in canv.Children)
            {
                if (u is Image)
                {
                    if (((Image)u).Tag != null && ((Image)u).Tag.Equals(sender.Content))
                    {
                        canv.Children.Remove(u);
                        break;
                    }
                }
            }
        }

        private void setMarked(Button sender)
        {
            Image img = new Image();
            img.Tag = sender.Content;
            BitmapImage b = new BitmapImage(new Uri(@"ms-appx:///Assets/rotateInside.png"));
            img.Source = b;
            img.Width = 60;
            img.Height = 60;
            Canvas.SetLeft(img, Canvas.GetLeft(sender) + 5);
            Canvas.SetTop(img, Canvas.GetTop(sender));
            Canvas.SetZIndex(img, 4);
            canv.Children.Add(img);
            sender.Tag = "Marked";
        }

        private void numClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
