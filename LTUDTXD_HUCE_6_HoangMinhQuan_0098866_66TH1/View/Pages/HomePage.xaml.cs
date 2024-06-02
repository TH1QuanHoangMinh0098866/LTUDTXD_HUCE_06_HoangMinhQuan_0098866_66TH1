using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Wpf;
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
using System.Web.UI.WebControls;

namespace LTUDTXD_HUCE_6_HoangMinhQuan_0098866_66TH1.View.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            plotview_1.Model = Worldpopulationbycontinent();
        }
        public static PlotModel Worldpopulationbycontinent()
        {
            var plotModel1 = new PlotModel();
            plotModel1.Title = "World population by continent";
            var pieSeries1 = new PieSeries();
            pieSeries1.InsideLabelColor = OxyColors.White;
            pieSeries1.InsideLabelPosition = 0.8;
            pieSeries1.StrokeThickness = 2;
            pieSeries1.Slices.Add(new PieSlice("Africa", 1030));
            pieSeries1.Slices.Add(new PieSlice("Americas", 929));
            pieSeries1.Slices.Add(new PieSlice("Asia", 4157));
            pieSeries1.Slices.Add(new PieSlice("Europe", 739));
            pieSeries1.Slices.Add(new PieSlice("Oceania", 35));
            plotModel1.Series.Add(pieSeries1);
            return plotModel1;
        }

        private void UC_GanttExample_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
