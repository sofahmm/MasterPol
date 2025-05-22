using MasterPolKumyshbaevaApp.ModelsConnection;
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

namespace MasterPolKumyshbaevaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnersListPage.xaml
    /// </summary>
    public partial class PartnersListPage : Page
    {
        public static List<Partner> partners { get; set; }
        public PartnersListPage()
        {
            InitializeComponent();
            partners = new List<Partner>(DbConnection.masterPolEntitites.Partner.ToList());
        
            this.DataContext = this;
        }

        private void AddNewParnerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPartnerPage());
        }
    }
}
