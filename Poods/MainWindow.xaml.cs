using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Poods.WindowsFolder;

namespace Poods
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StaffBaseWindow staffBaseWindow;
        private FurnitureBaseWindow furnitureBaseWindow;
        private CreationOrderWindow creationOrderWindow;
        private ClientsBaseWindow clientsBaseWindow;
        private OrderBaseWindow orderBaseWindow;
        private MaterialsBaseWindow materialsBaseWindow;
        private ProvidersBaseWindow providersBaseWindow;  
        DataBaseHelper db = new DataBaseHelper();
        public MainWindow()
        {
            InitializeComponent();
            LoadOrder();
            this.Closed += MainWindow_Closed;
        }
        private void LoadOrder()
        {
            
                string query = @"SELECT 
    o.IdOrder, 
    o.OrderNumber, 
    o.DateOrder, 
    o.CompletionDate, 
    o.Paid, 
    o.Status, 
    IFNULL(CONCAT('Id:', o.IdStaff, ' ', st.LastName, ' ', st.FirstName, ' ', IFNULL(st.MiddlуName, '')), 'Не назначен') AS StaffInfo,
    o.IdClient, 
    o.TotalCost,
    IFNULL((
        SELECT GROUP_CONCAT(CONCAT(od.ArticleNum, ' (', f.FurnitureName, ')') SEPARATOR ', ')
        FROM orderdetails od 
        LEFT JOIN furniture f ON od.ArticleNum = f.ArticleNum 
        WHERE od.IdOrder = o.IdOrder
    ), 'Нет товаров') AS Structure
FROM `order` o
LEFT JOIN staff st ON o.IdStaff = st.IdStaff
WHERE o.Status IN ('Новый', 'В работе')
ORDER BY o.DateOrder DESC";
                DataTable ordersTable = db.GetData(query);

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM `order` WHERE Status IN ('Новый', 'В работе')");
            object result = db.ExecuteScalar(cmd);

            int countOrder = result != null ? Convert.ToInt32(result) : 0;
            CurrentOrderInfo.Text = $"Количество активных заказов: {countOrder} ";
            DataGridOrder.ItemsSource = ordersTable.DefaultView;
           
        }
        private void Open_StaffBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (staffBaseWindow == null || !staffBaseWindow.IsVisible)
            {
                staffBaseWindow = new StaffBaseWindow();
                staffBaseWindow.Owner = this; // Устанавливаем текущее окно как владельца
                staffBaseWindow.Closed += (s, args) => staffBaseWindow = null; // Очищаем ссылку при закрытии
                staffBaseWindow.Show();
            }
            else
            {
                if (staffBaseWindow.WindowState == WindowState.Minimized)
                {
                    staffBaseWindow.WindowState = WindowState.Normal;
                }
                staffBaseWindow.Activate();
                staffBaseWindow.Topmost = true;
                staffBaseWindow.Topmost = false;
            }
        }

        private void Open_CreationOrderWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (creationOrderWindow == null || !creationOrderWindow.IsVisible)
            {
                creationOrderWindow = new CreationOrderWindow(this.idstaff); // Передаем ID
                creationOrderWindow.Owner = this;
                creationOrderWindow.Closed += (s, args) => creationOrderWindow = null;

                creationOrderWindow.Show();
            }
            else
            {
                if (creationOrderWindow.WindowState == WindowState.Minimized)
                {
                    creationOrderWindow.WindowState = WindowState.Normal;
                }
                creationOrderWindow.Activate();
            }
        }

        private void Open_OrderBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {if (orderBaseWindow == null || !orderBaseWindow.IsVisible)
            {
                orderBaseWindow = new OrderBaseWindow();
                orderBaseWindow.Owner = this;
                orderBaseWindow.Closed += (s, args) => orderBaseWindow = null;
                orderBaseWindow.Show();
            }
            else
            {
                if (orderBaseWindow.WindowState == WindowState.Minimized)
                {
                    orderBaseWindow.WindowState = WindowState.Normal;
                }
                orderBaseWindow.Activate();
                orderBaseWindow.Topmost = true;
                orderBaseWindow.Topmost = false;
            }
        }

        private void Open_ClientsBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (clientsBaseWindow == null || !clientsBaseWindow.IsVisible)
            {
                clientsBaseWindow = new ClientsBaseWindow();
                clientsBaseWindow.Owner = this; // Устанавливаем текущее окно как владельца
                clientsBaseWindow.Closed += (s, args) => clientsBaseWindow = null; // Очищаем ссылку при закрытии
                clientsBaseWindow.Show();
            }
            else
            {
                if (clientsBaseWindow.WindowState == WindowState.Minimized)
                {
                    clientsBaseWindow.WindowState = WindowState.Normal;
                }
                clientsBaseWindow.Activate();
                clientsBaseWindow.Topmost = true;
                clientsBaseWindow.Topmost = false;
            }
        }

        private void Exit_Button_click(object sender, RoutedEventArgs e)
        {
            AuthorizationGrid.Visibility = Visibility.Visible;
            MainManagmendGrid.Visibility = Visibility.Collapsed;
            clientsBaseWindow?.Close();
            staffBaseWindow?.Close();
            creationOrderWindow?.Close();
        }

        private void Authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text;
            string password = TextBoxPassword.Password;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            if (login == "admin" && password == "1")
            {
                AuthorizationGrid.Visibility = Visibility.Collapsed;
                TextBoxLogin.Text = null;
                TextBoxPassword.Password = null;
                // Скрываем первый Grid с полями ввода
                MainManagmendGrid.Visibility = Visibility.Visible;
                LoadCurrentUserInfo(login, password);
            }
            else
            {
                if (db.CheckLogin(login, password))
                {

                    // Обновляем дату последней авторизации
                    db.UpdateLastAuthDate(login);

                    // Скрываем панель авторизации и показываем основную панель
                    AuthorizationGrid.Visibility = Visibility.Collapsed;
                    TextBoxLogin.Text = null;
                    TextBoxPassword.Password = null;
                    // Скрываем первый Grid с полями ввода
                    MainManagmendGrid.Visibility = Visibility.Visible;
                    LoadCurrentUserInfo(login, password);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль, или учетная запись заблокирована");
                }
            }
        }

        public int idstaff = 0;
        private void LoadCurrentUserInfo(string login, string password)
        {
            // Используем параметризованный запрос через GetData
            string query = "SELECT IdStaff, LastName, FirstName, MiddlуName, Position FROM staff WHERE Login = @login";

            // Создаем параметры для запроса
            var parameters = new Dictionary<string, object>
            {
                  { "@login", login }
            };

            // Получаем данные пользователя
            DataTable userInfo = db.GetData2(query, parameters);

            if (login == "admin" && password == "1")
            {
                int idstaff = 777;
                string lastName = "admin";
                string firstName = "admin";
                string middlуName = "admin";
                string position = "admin";

                CurrentUserInfo.Text = $"Вы вошли как: {lastName} {firstName} {middlуName} Номер ID: {idstaff} Должность: {position}";
                this.idstaff = idstaff;

                // Включаем все кнопки для админа
                SetButtonsAccess(true, true, true, true, true, true, true);
                return;
            }

            if (userInfo.Rows.Count > 0)
            {
                DataRow row = userInfo.Rows[0];
                int idstaff = Convert.ToInt32(row["IdStaff"]);
                string lastName = row["LastName"].ToString();
                string firstName = row["FirstName"].ToString();
                string middlуName = row["MiddlуName"]?.ToString() ?? "";
                string position = row["Position"].ToString();

                this.idstaff = idstaff;
                CurrentUserInfo.Text = $"Вы вошли как: {lastName} {firstName} {middlуName} Номер ID: {idstaff} Должность: {position}";

                // Устанавливаем доступ к кнопкам в зависимости от должности
                switch (position)
                {
                    case "Админ":
                    case "Управляюший":
                        SetButtonsAccess(true, true, true, true, true, true, true);
                        break;
                    case "Продовец":
                        SetButtonsAccess(false, true, true, true, true, true, true);
                        break;
                    case "Инжинер":
                        SetButtonsAccess(false, false, true, false, true, true, false);
                        break;
                    default:
                        SetButtonsAccess(false, false, false, false, false, false, false);
                        break;
                }
            }
        }

        // Метод для управления доступом к кнопкам
        private void SetButtonsAccess(bool staff, bool clients, bool order, bool creationOrder,
                                    bool furniture, bool materials, bool providers)
        {
            StaffBaseWindow_Button.IsEnabled = staff;
            ClientsBaseWindow_Button.IsEnabled = clients;
            OrderBaseWindow_Button.IsEnabled = order;
            CreationOrderWindow_Button.IsEnabled = creationOrder;
            FurnitureBaseWindow_Button.IsEnabled = furniture;
            MaterialsBaseWindow_Button.IsEnabled = materials;
            ProvidersBaseWindow_Button.IsEnabled = providers;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // При закрытии главного окна все дочерние окна закроются автоматически
            // благодаря установленному свойству Owner
        }

        private void Open_FurnitureBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (furnitureBaseWindow == null || !furnitureBaseWindow.IsVisible)
            {
                furnitureBaseWindow = new FurnitureBaseWindow();
                furnitureBaseWindow.Owner = this; // Устанавливаем текущее окно как владельца
                furnitureBaseWindow.Closed += (s, args) => furnitureBaseWindow = null; // Очищаем ссылку при закрытии
                furnitureBaseWindow.Show();
            }
            else
            {
                if (furnitureBaseWindow.WindowState == WindowState.Minimized)
                {
                    furnitureBaseWindow.WindowState = WindowState.Normal;
                }
                furnitureBaseWindow.Activate();
                furnitureBaseWindow.Topmost = true;
                furnitureBaseWindow.Topmost = false;
            }
        }

        private void Update_Datagrid_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadOrder();
        }

        private void Open_MaterialsBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            if (materialsBaseWindow == null || !materialsBaseWindow.IsVisible)
            {
                materialsBaseWindow = new MaterialsBaseWindow();
                materialsBaseWindow.Owner = this; // Устанавливаем текущее окно как владельца
                materialsBaseWindow.Closed += (s, args) => materialsBaseWindow = null; // Очищаем ссылку при закрытии
                materialsBaseWindow.Show();
            }
            else
            {
                if (materialsBaseWindow.WindowState == WindowState.Minimized)
                {
                    materialsBaseWindow.WindowState = WindowState.Normal;
                }
                materialsBaseWindow.Activate();
                materialsBaseWindow.Topmost = true;
                materialsBaseWindow.Topmost = false;
            }
        }

        private void Open_ProvidersBaseWindow_Button_Click(object sender, RoutedEventArgs e)
        {

            if (providersBaseWindow == null || !providersBaseWindow.IsVisible)
            {
                providersBaseWindow = new ProvidersBaseWindow();
                providersBaseWindow.Owner = this; // Устанавливаем текущее окно как владельца
                providersBaseWindow.Closed += (s, args) => providersBaseWindow = null; // Очищаем ссылку при закрытии
                providersBaseWindow.Show();
            }
            else
            {
                if (providersBaseWindow.WindowState == WindowState.Minimized)
                {
                    providersBaseWindow.WindowState = WindowState.Normal;
                }
                providersBaseWindow.Activate();
                providersBaseWindow.Topmost = true;
                providersBaseWindow.Topmost = false;
            }
        }
    }           
}
