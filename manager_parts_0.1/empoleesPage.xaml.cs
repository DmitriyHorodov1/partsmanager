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
    /// Логика взаимодействия для empoleesPage.xaml
    /// </summary>
    public partial class empoleesPage : Page
    {
        public string search; // строка поиска
        public string type; // поле поиска
        public empoleesPage()
        {
            InitializeComponent();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var removeAgent = (sender as Button).DataContext as Працівники;
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new AddEditEmploees(removeAgent);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new AddEditEmploees(null);

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var emploeesToremove = emploeesPAGE.SelectedItems.Cast<Працівники>().ToList();

            if (MessageBox.Show($"Ви точно бажаєте видалити наступні {emploeesToremove.Count()} елементів ?", "Увага",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    parts_managerEntities1.GetContext().Працівники.RemoveRange(emploeesToremove);
                    parts_managerEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Дані видалені ");

                    emploeesPAGE.ItemsSource = parts_managerEntities1.GetContext().Працівники.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Схоже що цей запис використовується в інших таблицях");
                }
            }

        }

        private void emploeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            type = selectedItem.Content.ToString();

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                search = searchValue.Text;

                emploeesPAGE.ItemsSource = parts_managerEntities1.GetContext().Database.SqlQuery<Працівники>($" select * from Працівники where {type} LIKE '{search}%' ").ToList();



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
            emploeesPAGE.ItemsSource = parts_managerEntities1.GetContext().Працівники.ToList();
        }

        private void gotoMainpage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new MainPage();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                parts_managerEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                emploeesPAGE.ItemsSource = parts_managerEntities1.GetContext().Працівники.ToList();
            }

        }
    }
}
