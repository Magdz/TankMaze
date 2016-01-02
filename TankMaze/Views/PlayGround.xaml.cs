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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TankMaze.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayGround : Page
    {
        public PlayGround()
        {
            this.InitializeComponent();
        }
        
        private void Ground_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Up)
            {
                if (Grid.GetRow(RedTank) == 0) return;
                RedTank.SetValue(Grid.RowProperty, Grid.GetRow(RedTank) - 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 1);
                RedTank.SetValue(Grid.RowSpanProperty, 2);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankUp.png"));
            }else if (e.Key == Windows.System.VirtualKey.Down)
            {
                RedTank.SetValue(Grid.RowProperty, Grid.GetRow(RedTank) + 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 1);
                RedTank.SetValue(Grid.RowSpanProperty, 2);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankDown.png"));
            }else if(e.Key == Windows.System.VirtualKey.Right)
            {
                RedTank.SetValue(Grid.ColumnProperty, Grid.GetColumn(RedTank) + 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 2);
                RedTank.SetValue(Grid.RowSpanProperty, 1);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankRight.png"));
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                if (Grid.GetColumn(RedTank) == 0) return;
                RedTank.SetValue(Grid.ColumnProperty, Grid.GetColumn(RedTank) - 1);
                RedTank.SetValue(Grid.ColumnSpanProperty, 2);
                RedTank.SetValue(Grid.RowSpanProperty, 1);
                RedTank.Source = new BitmapImage(new Uri("ms-appx:///Assets/RedTankLeft.png"));
            }
        }
    }
}
