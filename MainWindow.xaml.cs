using ScottPlot;
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
using TransformerLoadLosses;

namespace LoadLossChart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WPFDiagram.Plot.Title("График нагрузочных потерь трансформатора");

            Transformator PRIME = new Transformator(55, 16000, 14805, 18175);
            Transformator SECOND = new Transformator(55, 16000, 9750, 32390);
            int step = 800;
            int lengh = PRIME.Snom;


            double[] dataX = Transformator.LoadLossesTrans(PRIME);
            double[] dataY = Transformator.LoadLossesTrans(PRIME,SECOND);
            double[] sine = DataGen.Sin(600, 3);
            WPFDiagram.Plot.AddScatter(dataX, dataY);
            WPFDiagram.Refresh();
        }
    }
}
