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
using System.Data.SqlClient;
using MongoDB.Driver.Core.Configuration;

namespace manager_parts_0._1
{
    /// <summary>
    /// Логика взаимодействия для addPage.xaml
    /// </summary>
    public partial class addPage : Page
    {
        private Контер_агенти контер_Агенти = new Контер_агенти();

        public bool update;
      
        public addPage(Контер_агенти selectedAgent)
        {

            InitializeComponent();

            if (selectedAgent != null)
            {
                контер_Агенти = selectedAgent;

                update = true;
            }
            else
            {
                update = false;
            }
            
            
            
            DataContext = контер_Агенти;
        
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(контер_Агенти.Назва_товариства))
                errors.AppendLine("Вкажіть назву товариства");

            if (string.IsNullOrEmpty(контер_Агенти.Номер_телефону))
                errors.AppendLine("Вкажіть номер телефону");

            if (string.IsNullOrEmpty(контер_Агенти.Фізична_адресса))
                errors.AppendLine("Вкажіть фізичну адресу товариства");

            if (string.IsNullOrEmpty(контер_Агенти.Юридична_адресса))
                errors.AppendLine("Вкажіть юридичну адресу товариства");

            if (string.IsNullOrEmpty(контер_Агенти.Єлектронна_пошта))
                errors.AppendLine("Вкажіть Електронну пошту");

            if (string.IsNullOrEmpty(контер_Агенти.ІНН) || контер_Агенти.ІНН.Length !=10)
                errors.AppendLine("Вкажіть номер картки платника податків (довжина 10 символів)");

            if (string.IsNullOrEmpty(контер_Агенти.ЄРДПОУ) || контер_Агенти.ЄРДПОУ.Length != 10 )
                errors.AppendLine("Вкажіть ЄРДПОУ (довжина 10 символів) ");

            if (errors.Length>0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

               if(update == false) {
                parts_managerEntities1.GetContext().Контер_агенти.Add(контер_Агенти);
               }
               else
                {
                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Контер_агенти set Назва_товариства = '{контер_Агенти.Назва_товариства}', Номер_телефону= '{контер_Агенти.Номер_телефону}' , Фізична_адресса='{контер_Агенти.Фізична_адресса}' ,  Юридична_адресса='{контер_Агенти.Юридична_адресса}' , ІНН='{контер_Агенти.ІНН}' , Єлектронна_пошта='{контер_Агенти.Єлектронна_пошта}' , ЄРДПОУ = '{контер_Агенти.ЄРДПОУ}' , Особливі_примітки='{контер_Агенти.Особливі_примітки}' where code = {контер_Агенти.code} ");

            }


            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new Agent();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
             
            }
        }
    }
}
