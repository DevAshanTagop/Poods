using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для OrderBaseWindow.xaml
    /// </summary>
    public partial class OrderBaseWindow : Window
    {
        private ChangeFurWindow changeFurWindow;
        private Dictionary<int, DataRow> selectedFurniture2 = new Dictionary<int, DataRow>();

        DataBaseHelper db = new DataBaseHelper();

        public OrderBaseWindow()
        {
            InitializeComponent();
            LoadOrder();
        }
        private void LoadOrder()
        {
            try
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

ORDER BY o.DateOrder DESC";

                DataTable ordersTable = db.GetData(query);


                DataGridOrder.ItemsSource = ordersTable.DefaultView;

                ComboBoxIdOrder.Items.Clear();
                foreach (DataRow row in ordersTable.Rows)
                {
                    ComboBoxIdOrder.Items.Add(row["IdOrder"]);
                }
                if (ComboBoxIdOrder.Items.Count <= 0)
                {
                    string cmquery = "ALTER TABLE staff AUTO_INCREMENT = 1";
                    MySqlCommand cmd = new MySqlCommand(cmquery);
                    db.ExecuteQuery(cmd);
                }
                LoadEnumCmbx();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}");
            }
        }
        private void LoadEnumCmbx()
        {
            try
            {
                string query = @"
                        SELECT COLUMN_TYPE 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_SCHEMA = DATABASE() 
                        AND TABLE_NAME = 'order' 
                        AND COLUMN_NAME = 'Paid'";
                var position = db.GetEnumValues(query);
                position.Insert(0, "");
                ComboBoxPaidStatus.ItemsSource = position;
                ComboBoxPaidStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки Должности: " + ex.Message);
            }
            try
            {
                string query = @"
                        SELECT COLUMN_TYPE 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_SCHEMA = DATABASE() 
                        AND TABLE_NAME = 'order' 
                        AND COLUMN_NAME = 'Status'";
                var position = db.GetEnumValues(query);
                position.Insert(0, "");
                ComboBoxStatusOfOrder.ItemsSource = position;
                ComboBoxStatusOfOrder.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки Должности: " + ex.Message);
            }
        }
        private void Update_Grid_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadOrder();
        }
        private void DeletOrder(int selectedId)
        {
            try
            {
                // Сначала удаляем детали заказа
                string deleteDetailsQuery = "DELETE FROM orderdetails WHERE IdOrder = @orderId";
                var cmd = new MySqlCommand(deleteDetailsQuery);
                cmd.Parameters.AddWithValue("@orderId", selectedId);

                if (db.ExecuteQuery(cmd))
                {
                    // Затем удаляем сам заказ
                    string deleteOrderQuery = "DELETE FROM `order` WHERE IdOrder = @orderId";
                    cmd.CommandText = deleteOrderQuery;

                    if (db.ExecuteQuery(cmd))
                    {
                        MessageBox.Show("Заказ успешно удален");
                        LoadOrder(); // Обновляем список заказов
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
        private void Delet_Order_Button_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxIdOrder.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выполнить действие?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    int selectedId = Convert.ToInt32(ComboBoxIdOrder.SelectedItem);
                    DeletOrder(selectedId);
                    LoadOrder();
                }
            }
            else
            {
                MessageBox.Show("Выберите ID.");
            }
        }
        private void UpdateOrder(int selectedId, string statusOfOrderCmbx, string paidStatusCmbx)
        {
            try
            {
                List<string> setClauses = new List<string>();
                MySqlCommand cmd = new MySqlCommand();

                // Добавляем параметры для оплаты
                if (!string.IsNullOrEmpty(paidStatusCmbx))
                {
                    setClauses.Add("Paid = @paid");
                    cmd.Parameters.AddWithValue("@paid", paidStatusCmbx);
                }

                // Добавляем параметры для статуса
                if (!string.IsNullOrEmpty(statusOfOrderCmbx))
                {
                    setClauses.Add("Status = @status");
                    cmd.Parameters.AddWithValue("@status", statusOfOrderCmbx);

                    if (statusOfOrderCmbx == "Выполнен")
                    {
                        setClauses.Add("CompletionDate = @completionDate");
                        cmd.Parameters.AddWithValue("@completionDate", DateTime.Now);
                    }
                }

                // Если нечего обновлять
                if (setClauses.Count == 0)
                {
                    MessageBox.Show("Нет данных для обновления");
                    return;
                }

                // Формируем окончательный запрос
                string query = $"UPDATE `order` SET {string.Join(", ", setClauses)} WHERE IdOrder = @id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", selectedId);

                // Выполняем запрос
                if (db.ExecuteQuery(cmd))
                {
                    MessageBox.Show("Данные обновлены успешно!");
                    LoadOrder(); // Обновляем данные в интерфейсе
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void Update_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (ComboBoxIdOrder.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ComboBoxIdOrder.SelectedItem);
                string statusOfOrderCmbx = ComboBoxStatusOfOrder.SelectedItem as string;
                string paidStatusCmbx = ComboBoxPaidStatus.SelectedItem as string;
                if (!string.IsNullOrEmpty(statusOfOrderCmbx) || !string.IsNullOrEmpty(paidStatusCmbx))
                {
                    UpdateOrder(selectedId, statusOfOrderCmbx, paidStatusCmbx);
                    LoadOrder();
                }
                else
                {
                    MessageBox.Show("Внесите хотя бы в одно поле, информацию.");
                }
            }
            else
            {
                MessageBox.Show("Выберите ID.");
            }



        }
        private void ChangeFurWindow_Closed(object sender, EventArgs e)
        {
            if (changeFurWindow != null && changeFurWindow.IsConfirmed)
            {
                try
                {
                    int selectedId = Convert.ToInt32(ComboBoxIdOrder.SelectedItem);
                    string deleteDetailsQuery = "DELETE FROM orderdetails WHERE IdOrder = @orderId";
                    var cmd = new MySqlCommand(deleteDetailsQuery);
                    cmd.Parameters.AddWithValue("@orderId", selectedId);

                    if (db.ExecuteQuery(cmd))
                    {
                        foreach (var item in changeFurWindow.selectedFurniture2.Keys)
                        {
                            int articleNum = item;

                            if (!db.AddOrderDetail(selectedId, articleNum))
                            {
                                throw new Exception($"Ошибка добавления товара {articleNum}. " +
                                                  $"Проверьте существование товара с артикулом {articleNum}");
                            }
                        }
                    }
                  

                    LoadOrder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки выбранной мебели: {ex.Message}");
                }
            }

            changeFurWindow = null;
        }


        public int selectedId = 0;
        private void Add_Furniture_In_Order_Button_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxIdOrder.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ComboBoxIdOrder.SelectedItem);
                this.selectedId = selectedId;
                if (changeFurWindow == null || !changeFurWindow.IsVisible)
                {
                    changeFurWindow = new ChangeFurWindow(this.selectedId);
                    changeFurWindow.Owner = this;
                    changeFurWindow.Closed += ChangeFurWindow_Closed; // Подписываемся на событие закрытия
                    changeFurWindow.Show();
                }
                else
                {
                    if (changeFurWindow.WindowState == WindowState.Minimized)
                    {
                        changeFurWindow.WindowState = WindowState.Normal;
                    }
                    changeFurWindow.Activate();
                    changeFurWindow.Topmost = true;
                    changeFurWindow.Topmost = false;
                }
            }
            else
            {
                MessageBox.Show("Выберите ID.");
            }
        }
    }
}
