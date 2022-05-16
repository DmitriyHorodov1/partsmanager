using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Agent.xaml
    /// </summary>
    public partial class Agent : Page
    {

        public string search; // строка поиска
        public string type; // поле поиска



        public Agent()
        {
            InitializeComponent();


        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var removeAgent = (sender as Button).DataContext as Контер_агенти;
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new addPage(removeAgent);
           
        }

        private void AgentPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //навигация на другую страницу
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new addPage(null);

        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            var agentsToremove = AgentPage.SelectedItems.Cast<Контер_агенти>().ToList();

            if (MessageBox.Show($"Ви точно бажаєте видалити наступні {agentsToremove.Count()} елементів ?", "Увага",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    parts_managerEntities1.GetContext().Контер_агенти.RemoveRange(agentsToremove);
                    parts_managerEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Дані видалені ");

                    AgentPage.ItemsSource = parts_managerEntities1.GetContext().Контер_агенти.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                parts_managerEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                AgentPage.ItemsSource = parts_managerEntities1.GetContext().Контер_агенти.ToList();
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try {

                search = searchValue.Text;

                AgentPage.ItemsSource = parts_managerEntities1.GetContext().Database.SqlQuery<Контер_агенти>($" select * from Контер_агенти where {type} LIKE '{search}%' ").ToList();
               


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

        private void agentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
             type=  selectedItem.Content.ToString();
        }

        private void btn_reaload_Click(object sender, RoutedEventArgs e)
        {
            AgentPage.ItemsSource = parts_managerEntities1.GetContext().Контер_агенти.ToList();
        }

        private void gotoMainPage_click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Content = new MainPage();
        }
    }
}
