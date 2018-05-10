using Esri.ArcGISRuntime.Mapping;
using System;
using System.IO;
using System.Windows;

namespace UCRuntimeMMPKDemo
{
    public partial class MainWindow : Window
    {
        // Get the application's parent directory
        DirectoryInfo parent = Directory.GetParent(Environment.CurrentDirectory);

        // Add two maps objects to hold the maps stored in the MMPK
        Map _map1 = new Map();
        Map _map2 = new Map();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // Call a method create to open the MMPK and grab the maps for display in the application
            CreateMMPKLayer();
        }
        private async void CreateMMPKLayer()
        {
            // Path to MMPK
            string sPath_mobile = parent.FullName + "\\MMPK\\NewZealand.mmpk";

            // Open MMPK asynchrously and store in map objects
            MobileMapPackage mmpk = await MobileMapPackage.OpenAsync(sPath_mobile);
            _map1 = mmpk.Maps[0];
            _map2 = mmpk.Maps[1];

            // Add maps to the MapView
            MyMapView.Map = _map1;
            MyMapView.Map = _map2;
        }
        // Switch between maps
        private void SwitchMaps_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MyMapView.Map != _map1)
                {
                    MyMapView.Map = _map1;
                }
                else
                {
                    MyMapView.Map = _map2;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
