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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterPolKumyshbaevaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPartnerPage.xaml
    /// </summary>
    public partial class AddPartnerPage : Page
    {
        //создали динамический массив
        public static List<TypePartner> typePartners { get; set; }
        public AddPartnerPage()
        {
            InitializeComponent();
            //заполняем динамический массив
            typePartners = new List<TypePartner>(DbConnection.masterPolEntitites.TypePartner.ToList());

            //строка, чтобы все работало
            this.DataContext = this;
        }

        private void SavePartnerBtn_Click(object sender, RoutedEventArgs e)
        {
            Partner partner = new Partner();

            if (AddresTb.Text.Trim() != string.Empty && EmailTb.Text.Trim() != string.Empty 
                && NamePartnerTb.Text.Trim() != string.Empty && NumberPhoneTb.Text.Trim() != string.Empty
                && RaitingTb.Text.Trim() != string.Empty && SNPdirectorTb.Text.Trim() != string.Empty
                && TypePartnerCmb.SelectedItem != null)
            {
                if (int.TryParse(RaitingTb.Text, out int t))
                {
                    if (t >= 0)
                    {
                        partner.Raiting = t.ToString();
                        partner.NameCompany = NamePartnerTb.Text.Trim();
                        partner.IdTypePartner = (TypePartnerCmb.SelectedItem as TypePartner).Id;
                        partner.Address = AddresTb.Text.Trim();
                        partner.SNPdirector = SNPdirectorTb.Text.Trim();
                        partner.PhoneNumber = NumberPhoneTb.Text.Trim();
                        partner.Email = EmailTb.Text.Trim();

                        DbConnection.masterPolEntitites.Partner.Add(partner);
                        DbConnection.masterPolEntitites.SaveChanges();
                        MessageBox.Show("Сохранение прошло успешно!");
                    }
                    else
                        MessageBox.Show("Рейтинг не может быть отрицательным!");


                }
                else
                {
                    MessageBox.Show("Рейтинг может быть только целым числом!!");
                }
                
            }
            else
                MessageBox.Show("Сначала заполните все поля!");
            
        }
    }
}
