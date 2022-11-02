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
using System.Windows.Shapes;
using System.IO;
using System.ServiceModel.Channels;
using System.Windows.Forms.DataVisualization.Charting;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveCharts;
using System.Collections.ObjectModel;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Diagramm.xaml
    /// </summary>
    public partial class Diagramm : Window
    {
        public ObservableCollection<ISeries> Series { get; set; }
        public Diagramm()
        {
            InitializeComponent();

            string s = "";
            string[] textMass;
            StreamReader sr = new StreamReader("D:\\Сообщения.txt");

            while (sr.EndOfStream != true)
            {
                s += sr.ReadLine();
            }
            textMass = s.Split(' ');
            double[] massLen = new double[textMass.Length];
            for(int i = 0; i < massLen.Length; i++)
            {
                massLen[i] = textMass[i].Length;
            }
            var seriesCollection = new ObservableCollection<ISeries>();
            Series = seriesCollection;
            seriesCollection.Add(new LineSeries<double> { Values=massLen});

            this.DataContext = this;
        }



    }
}
