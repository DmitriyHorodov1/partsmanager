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
    /// Логика взаимодействия для AddEditSale.xaml
    /// </summary>
    public partial class AddEditSale : Page
    {
        private Продаж_товарів продаж_Товарів = new Продаж_товарів();
        public bool update;

        public AddEditSale(Продаж_товарів selectedSales)
        {
            InitializeComponent();
            if (selectedSales != null)
            {
                продаж_Товарів = selectedSales;
                update = true;
            }
            else
            {
                update = false;
            }
            DataContext = продаж_Товарів;

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

            emploeers.ItemsSource = listEmploers;
        }



        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (продаж_Товарів.Кількість < 0)
                errors.AppendLine("Вкажіть кількість ");

            if (продаж_Товарів.Код_контрагента == null)
                errors.AppendLine("Вкажіть код постачальника");

            if (продаж_Товарів.Код_працівника == null)
                errors.AppendLine("Вкажіть код працівника");

            if (продаж_Товарів.Код_товару == null)
                errors.AppendLine("Вкажіть код товару ");

            if (продаж_Товарів.Дата_продажу == null)
                errors.AppendLine("Вкажіть дату продажу");

            if (string.IsNullOrEmpty(продаж_Товарів.Cтатус_доставки))
                errors.AppendLine("Вкажіть статус Доставки");

            if (string.IsNullOrEmpty(продаж_Товарів.Cтатус_проплати))
                errors.AppendLine("Вкажіть статус проплати");

            if (продаж_Товарів.Знижка > 50 || продаж_Товарів.Знижка < 0)
                errors.AppendLine("Вкажіть відцоток знижнижки в діапазоні 0 до 50");

            if (продаж_Товарів.Вартість_купленого == null || продаж_Товарів.Вартість_купленого > 999999  || продаж_Товарів.Вартість_купленого < 1)
            {
                errors.AppendLine("Вкажіть вартість купленого або вартість перевищує ліміт у 999999 у.о");
            }
            else
            {
                if (update == false)
                {
                    int sum = ((int)System.Math.Round((double)(продаж_Товарів.Вартість_купленого * продаж_Товарів.Знижка / 100)));
                    продаж_Товарів.Вартість_купленого = продаж_Товарів.Вартість_купленого - sum;
                }

            }





            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (update == false)
            {
                parts_managerEntities1.GetContext().Продаж_товарів.Add(продаж_Товарів);
            }
            else
            {
                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Продаж_товарів set Кількість = {продаж_Товарів.Кількість} , Код_контрагента = {продаж_Товарів.Код_контрагента} ,  Код_працівника = {продаж_Товарів.Код_працівника} , Дата_продажу = '{продаж_Товарів.Дата_продажу}' ,    Код_товару = { продаж_Товарів.Код_товару } , Cтатус_доставки = '{продаж_Товарів.Cтатус_доставки}' ,  Знижка  = '{продаж_Товарів.Знижка}' , Вартість_купленого  = {продаж_Товарів.Вартість_купленого} , Коментар = '{продаж_Товарів.Коментар }'   where code = {продаж_Товарів.code} ");


            }

            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new salePage();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }



    }


}
