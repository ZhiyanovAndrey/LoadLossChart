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
            int length = (int)PRIME.Snom * 2 + 1;


            double[] dataX = Transformator.LoadLossesTrans(step, length);
            double[] dataY = Transformator.LoadLossesTrans(step, PRIME);
            double[] dataTwoY = Transformator.LoadLossesTrans(step, PRIME, SECOND);


            WPFDiagram.Plot.AddScatter(dataX, dataY);
            WPFDiagram.Plot.AddScatter(dataX, dataTwoY);

            WPFDiagram.Refresh();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Transformator PRIME = new Transformator(55, 16000, 14805, 18175);
            Transformator SECOND = new Transformator(55, 16000, 9750, 32390);

            StringBuilder sb = new StringBuilder();
            double[] arr = Transformator.LoadLossesTrans(800, PRIME.Snom*2);
            double[] arr1 = Transformator.LoadLossesTrans(800, PRIME, SECOND);

            int[] s =  {10, 4, 4, 4, 5 };
            foreach (var item in arr1)
            {
                Textblock.Text += item.ToString()+" ";
            }

        }
    }
}
