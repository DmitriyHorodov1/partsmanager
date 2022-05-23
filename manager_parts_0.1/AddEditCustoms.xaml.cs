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
    /// Логика взаимодействия для AddEditCustoms.xaml
    /// </summary>
    public partial class AddEditCustoms : Page
    {
        private Митниця митниця = new Митниця();
        public bool update;
        public AddEditCustoms( Митниця selectedCustoms)
        {
            InitializeComponent();
            if(selectedCustoms != null)
            {
                митниця = selectedCustoms;
                update = true;
            }
            else
            {
                update = false;
            }
            DataContext = митниця;

           
            var listGoods = new List<int> { };

            var goodsCode = parts_managerEntities1.GetContext().Database.SqlQuery<Поставки_товарів>("select * from Поставки_товарів ");
            foreach (var goods in goodsCode)
            {
                listGoods.Add(goods.code);
            }
            goods.ItemsSource = listGoods;

         

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

            if (string.IsNullOrEmpty(митниця.Cтатус))
                errors.AppendLine("Встановіть статус (Розмитнено або ні)");

            if (митниця.Дата_реєстрації == null)
                errors.AppendLine("Встановіть дату реєстрації");

            if (митниця.Відцоток_додаткової_вартості > 50 || митниця.Відцоток_додаткової_вартості < 0)
                errors.AppendLine("Встановіть відцоток додаткової вартості (границі від 0 до 50 )");

            if (митниця.Кількість == null || митниця.Кількість < 0)
                errors.AppendLine("Встановіть кількість задекларованих одиниц товару");

            if (митниця.Код_працівника == null)
                errors.AppendLine("Встановіть код працівника");

            if (митниця.Код_товару == null )
                errors.AppendLine("Встановіть код товару  ");

            if (митниця.Номер_рахунку == null || митниця.Номер_рахунку < 000000 || митниця.Номер_рахунку > 999999)
                errors.AppendLine("Встановіть номер рахунку (6 знаків)");

            if (митниця.Строк_зберігання_СТЗ == null)
                errors.AppendLine("Встановіть кінцевий строк");



              



                if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (update == false)
            {
                parts_managerEntities1.GetContext().Митниця.Add(митниця);
            }
            else
            {
                parts_managerEntities1.GetContext().Database.ExecuteSqlCommand($"update Митниця set Cтатус = '{митниця.Cтатус}' ,   Дата_реєстрації = '{митниця.Дата_реєстрації}' ,  Відцоток_додаткової_вартості  = {митниця.Відцоток_додаткової_вартості} ,  Кількість = {митниця.Кількість} , Код_працівника = {митниця.Код_працівника } , Код_товару = {митниця.Код_товару} , Номер_рахунку  = {митниця.Номер_рахунку} , Строк_зберігання_СТЗ = '{митниця.Строк_зберігання_СТЗ}' where code = {митниця.code} ");


            }

            try
            {
                parts_managerEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информація додана");
                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.Content = new customsPage();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }
    }
}
