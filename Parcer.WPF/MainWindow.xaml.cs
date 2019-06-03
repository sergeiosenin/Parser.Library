using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Parcer.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CookieContainer cookie = Parcer.Library.Parcer.EnterSite();
            Brand brand_Mercedes = new Brand("683", "Mercedes");
            Model model_Eclass = new Model("5884", "E-class");
            Generation gen_W211 = new Generation("4556", "W211");
            Query query_W211 = new Query() { BrandID = brand_Mercedes.ID, ModelID = model_Eclass.ID, GenerationID = gen_W211.ID };


            int countPages = 13;
            var countPagesActual = Parcer.Library.Parcer.GetCountPage(query_W211, cookie);
        }
    }
}
