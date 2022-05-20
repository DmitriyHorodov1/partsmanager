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
    /// Логика взаимодействия для AddEditsuppliesPage.xaml
    /// </summary>
    public partial class AddEditsuppliesPage : Page
    {
        private Поставки_товарів поставки_Товарів = new Поставки_товарів();
        public bool update;
        public AddEditsuppliesPage(Поставки_товарів selectedSupplies)
        {
            InitializeComponent();
            if(selectedSupplies != null)
            {
                поставки_Товарів = selectedSupplies;
                update = true;
            }
            else 
            {
                update = false;
            }
            DataContext = поставки_Товарів;

            //кодПостачальників

             var listSuppliers = new List<int> { };

            var suppliersCode = parts_managerEntities1.GetContext().Database.SqlQuery<Контер_агенти>("select * from Контер_агенти ");
            foreach (var supplier in suppliersCode)
            {
                listSuppliers.Add(supplier.code);
            }

            suppliers.ItemsSource = listSuppliers;
            // goods
            var listGoods = new List<int> { };

            var goodsCode = parts_managerEntities1.GetContext().Database.SqlQuery<Найменування_товарів>("select * from Найменування_товарів ");
            foreach (var goods in goodsCode)
            {
                listGoods.Add(goods.code);
            }
            goods.ItemsSource = listGoods;

            //emploers

            var listEmploers = new List<int> { };

            var emploerCode = parts_managerEntities1.GetContext().Database.SqlQuery<Працівники>("select * from Працівники ");
            foreach (var emploers in emploerCode)
            {
                listEmploers.Add(emploers.code);
            }

            emploers.ItemsSource = listEmploers;



        }

       





        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (поставки_Товарів.Кількість < 0)
                errors.AppendLine("Вкажіть кількість ");

            if(поставки_Товарів.код_Постачальника == null)
                errors.AppendLine("Вкажіть код постачальника");

            if(поставки_Товарів.Код_працівника == null)
                errors.AppendLine("Вкажіть код працівника");

            if(поставки_Товарів.код_Товару==null)
                errors.AppendLine("Вкажіть код товару ");

            if(поставки_Товарів.Час_поставки_товару == null)
                errors.AppendLine("Вкажіть час_поставки");

            if(string.IsNullOrEmpty(поставки_Товарів.Статус_митниці))
                errors.AppendLine("Вкажіть вкажіть статус митниці (Розмитнено/НеРозмитнено)");

            if(string.IsNullOrEmpty(поставки_Товарів.Назва_компанії_перевізника) || поставки_Товарів.Назва_компанії_перевізника.Length == 50)
                errors.AppendLine("Вкажіть компанію перевізника, або довжина більше 50");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (update == false)
            {
                parts_managerEntities1.GetContext().Поставки_товарів.Add(поставки_Товарів);
            }
            else
            {


                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Поставки_товарів set Кількість = {поставки_Товарів.Кількість} , код_Постачальника  = {поставки_Товарів.код_Постачальника} ,  Код_працівника = {поставки_Товарів.Код_працівника} , код_Товару = {поставки_Товарів.код_Товару} , Час_поставки_товару = '{поставки_Товарів.Час_поставки_товару}' , Статус_митниці = '{поставки_Товарів.Статус_митниці}', Назва_компанії_перевізника = '{поставки_Товарів.Назва_компанії_перевізника}'   where code = {поставки_Товарів.code} ");


            }

            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new suppliesPage();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }


        }
    }
}
