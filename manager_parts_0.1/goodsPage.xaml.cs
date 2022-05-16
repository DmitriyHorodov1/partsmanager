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
    /// Логика взаимодействия для goodsPage.xaml
    /// </summary>
    public partial class goodsPage : Page
    {

        public string search; // строка поиска
        public string type; // поле поиска
        public goodsPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                parts_managerEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Pagegoods.ItemsSource = parts_managerEntities1.GetContext().Найменування_товарів.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new addEditGoodsPage(null);
        }

       

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                search = searchValue.Text;

                Pagegoods.ItemsSource = parts_managerEntities1.GetContext().Database.SqlQuery<Найменування_товарів>($" select * from Найменування_товарів where {type} LIKE '{search}%' ").ToList();

            }
            catch (Exception ex)
            {
                StringBuilder errors = new StringBuilder();

                if (search == "")
                    errors.AppendLine("Введіть пошуковий запит");

                if (type == null)
                    errors.AppendLine("Оберіть категорію пошуку");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

            }

        }

        private void btn_reaload_Click(object sender, RoutedEventArgs e)
        {
            Pagegoods.ItemsSource = parts_managerEntities1.GetContext().Найменування_товарів.ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var goodsTORemove = Pagegoods.SelectedItems.Cast<Найменування_товарів>().ToList();

            if (MessageBox.Show($"Ви точно бажаєте видалити наступні {goodsTORemove.Count()} елементів ?", "Увага",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    parts_managerEntities1.GetContext().Найменування_товарів.RemoveRange(goodsTORemove);
                    parts_managerEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Дані видалені ");

                    Pagegoods.ItemsSource = parts_managerEntities1.GetContext().Найменування_товарів.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void GoodsPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            type = selectedItem.Content.ToString();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var removeGoods = (sender as Button).DataContext as Найменування_товарів;
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new addEditGoodsPage(removeGoods);
          //  parts_managerEntities1.GetContext().Найменування_товарів.Remove(removeGoods);
           // parts_managerEntities1.GetContext().SaveChanges();
        }

        private void gotoMainpage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new MainPage();


        }

        private void Pagegoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
