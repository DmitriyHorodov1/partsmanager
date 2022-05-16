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
    /// Логика взаимодействия для addEditGoodsPage.xaml
    /// </summary>
    public partial class addEditGoodsPage : Page
    {
        private Найменування_товарів найменування_Товарів = new Найменування_товарів();

        private Контер_агенти контер_Агенти = new Контер_агенти();

         public bool update;
        public addEditGoodsPage(Найменування_товарів selectedGoods)
        {
            
             InitializeComponent();
            if(selectedGoods != null)
            {
                найменування_Товарів = selectedGoods;
                update = true;
            }
            else
            {
                update = false;
            }
            DataContext = найменування_Товарів;

            

             var  list = new List<int> {};


            var comps = parts_managerEntities1.GetContext().Database.SqlQuery<Контер_агенти>("select * from Контер_агенти ");
            foreach (var compony in comps)
                list.Add(compony.code);


            combo1.ItemsSource = list;


           


        } 

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if(найменування_Товарів.Код_товару > 99999)
            {
                errors.AppendLine("Вкажіть код товару довжина якого 5 знаків");
            }
            if (string.IsNullOrEmpty(найменування_Товарів.Назва))
                errors.AppendLine("Вкажіть назву товару");

            if (найменування_Товарів.Каталожний_номер > 99999)
                errors.AppendLine("Вкажіть каталожний номер довжина якого 5 знаків");

            if (найменування_Товарів.Ціна < 1)
                errors.AppendLine("Вкажіть ціну поцизії яка більше 1 у.о");

            if (string.IsNullOrEmpty(найменування_Товарів.Одиниця_виміру))
                errors.AppendLine("Вкажіть одиницю виміру");

            if (найменування_Товарів.Вага > 9999.99 || найменування_Товарів.Вага == null)
                errors.AppendLine("Неприпустима вага (допустима до 9999,99)  , або поле незаповнене");

            if (найменування_Товарів.Країна_виробник == null ||
                найменування_Товарів.Країна_виробник.Length == 20 ||
                найменування_Товарів.Країна_виробник.Contains("!") ||
                найменування_Товарів.Країна_виробник.Contains("@") ||
                найменування_Товарів.Країна_виробник.Contains("%"))
                errors.AppendLine("Поле Країна виробник не заповненне або не відповідає вимогам, а саме довжина 20 символів та заборона викоритсання спец.сивмолів");
            
            if(найменування_Товарів.Бренд == null ||
                найменування_Товарів.Бренд.Length == 20 ||
                найменування_Товарів.Бренд.Contains("!") ||
                найменування_Товарів.Бренд.Contains("@") ||
                найменування_Товарів.Бренд.Contains("%"))
                errors.AppendLine("Поле Бренд не заповненне або не відповідає вимогам, а саме довжина 20 символів та заборона викоритсання спец.сивмолів");


            if (найменування_Товарів.Кількість_товарів < 0 || найменування_Товарів.Кількість_товарів > 99999 || найменування_Товарів.Кількість_товарів == null)
                errors.AppendLine("Поле кількість товарів незавнене або встановлене не віргн значення (межі від 0 до 99999)");

            if (найменування_Товарів.Код_постачальника == null)
                errors.AppendLine("Поле код постачальника не встановлено");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (update == false)
            {
                parts_managerEntities1.GetContext().Найменування_товарів.Add(найменування_Товарів);
            }
            else
            {


                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Найменування_товарів set Код_товару = {найменування_Товарів.Код_товару} ,  Назва = '{найменування_Товарів.Назва}' , Каталожний_номер = {найменування_Товарів.Каталожний_номер} , Одиниця_виміру = '{найменування_Товарів.Одиниця_виміру}' , Вага = {найменування_Товарів.Вага} ,  Країна_виробник = '{найменування_Товарів.Країна_виробник}' , Бренд = '{найменування_Товарів.Бренд}' , Кількість_товарів = {найменування_Товарів.Кількість_товарів} , Код_постачальника = {найменування_Товарів.Код_постачальника} , Примітка = '{найменування_Товарів.Примітка}'  where code = {найменування_Товарів.code} ");
            
                
            }

            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new goodsPage();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }




        }
    }
}
