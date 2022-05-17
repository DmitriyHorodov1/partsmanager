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

namespace manager_parts_0._1
{
    /// <summary>
    /// Логика взаимодействия для AddEditEmploees.xaml
    /// </summary>
    public partial class AddEditEmploees : Page
    {
        private Працівники працівники = new Працівники();

        public bool update;

        public AddEditEmploees(Працівники selectedemploee)
        {

            InitializeComponent();

            if (selectedemploee != null)
            {
                працівники = selectedemploee;

                update = true;
            }
            else
            {
                update = false;
            }



            DataContext = працівники;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(працівники.ИПБ))
                errors.AppendLine("Вкажіть назву товариства");

            if (string.IsNullOrEmpty(працівники.Посада))
                errors.AppendLine("Вкажіть номер телефону");

            if (працівники.Дата_працевлаштування == null )
                errors.AppendLine("Вкажіть фізичну адресу товариства");

            if (працівники.Зарплата < 100 || працівники.Зарплата > 9999999)
                errors.AppendLine("Вкажіть юридичну адресу товариства");

           
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (update == false)
            {
                parts_managerEntities1.GetContext().Працівники.Add(працівники);
            }
            else
            {
                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Працівники set ИПБ = '{працівники.ИПБ}' , Посада = '{працівники.Посада}', Дата_працевлаштування = '{працівники.Дата_працевлаштування}', Зарплата = {працівники.Зарплата},  Примітка = '{працівники.Примітка}'  where code = {працівники.code} ");

            }


            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new empoleesPage();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
