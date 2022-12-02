using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;

namespace WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MapPoint mapCenterPoint = new MapPoint(59.8693, 58.6296, SpatialReferences.Wgs84);
            MainMapView.SetViewpoint(new Viewpoint(mapCenterPoint, 100000));
            //MainMapView.LocationDisplay.IsEnabled = true;
            //MainMapView.LocationDisplay.AutoPanMode = Esri.ArcGISRuntime.UI.LocationDisplayAutoPanMode.Recenter;
            
        }

        private void MainMapView_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void mainGrid_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Text = Mouse.GetPosition(mainGrid).ToString();
            textBox2.Text = MainMapView.PointToScreen(MainMapView.LocationToScreen(new MapPoint(59.8693, 58.6296, SpatialReferences.Wgs84))).ToString();
            
        }

        private void MainMapView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var x = Mouse.GetPosition(mainGrid);
            TextOutBox.Text = MainMapView.PointFromScreen(x).ToString();
            var mr = MainMapView.Map.AllLayers.ToList();
            listboxone.Items.Add(mr.ToString());
            
        }
    }
}
