using System;
using System.Collections;
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

namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для CreationOrderWindow.xaml
    /// </summary>
    public partial class CreationOrderWindow : Window
    {
        

        private OrderFurWindow orderFurWindow;
        private readonly int _staffId;
        DataBaseHelper db = new DataBaseHelper();
        private Dictionary<int, DataRow> selectedFurniture = new Dictionary<int, DataRow>();
        public int DeliveryCost;

        public CreationOrderWindow(int idstaff)
        {
           
            InitializeComponent();
            CheckAndResetAutoIncrement();
            _staffId = idstaff;
            LoadClients();
            UpdateSelectedItemsGrid();
        }
        private void LoadClients()
        {
            try
            {
                string query = "SELECT IdClient, CONCAT(IdClient, ' ',LastName, ' ', FirstName, ' ', MiddlуName ) AS FullName FROM Clients";
                DataTable dt = db.GetData(query);

                ClientComboBox.ItemsSource = dt.DefaultView;
                ClientComboBox.DisplayMemberPath = "FullName";
                ClientComboBox.SelectedValuePath = "IdClient";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}");
            }
        }
        private void Add_Furniture_button_click(object sender, RoutedEventArgs e)
        {
            if (orderFurWindow == null || !orderFurWindow.IsVisible)
            {
                orderFurWindow = new OrderFurWindow();
                orderFurWindow.Owner = this;
                orderFurWindow.Closed += OrderFurWindow_Closed; // Подписываемся на событие закрытия
                orderFurWindow.Show();
            }
            else
            {
                if (orderFurWindow.WindowState == WindowState.Minimized)
                {
                    orderFurWindow.WindowState = WindowState.Normal;
                }
                orderFurWindow.Activate();
                orderFurWindow.Topmost = true;
                orderFurWindow.Topmost = false;
            }
        }
        private void OrderFurWindow_Closed(object sender, EventArgs e)
        {
            if (orderFurWindow != null && orderFurWindow.IsConfirmed)
            {
                try
                {
                    selectedFurniture.Clear();
                    var selectedIds = orderFurWindow.SelectedFurniture.Keys.ToList();

                    if (selectedIds.Count > 0)
                    {
                        string query = "SELECT * FROM furniture WHERE ArticleNum IN (" +
                                      string.Join(",", selectedIds) + ")";

                        DataTable dt = db.GetData(query);
                        foreach(DataRow row in dt.Rows)
{
                            int articleNum = Convert.ToInt32(row["ArticleNum"]);

                            // Создаем копию строки furniture, добавим туда вручную Materials
                            DataRow newRow = dt.NewRow();
                            newRow.ItemArray = row.ItemArray.Clone() as object[];

                            if (!newRow.Table.Columns.Contains("Materials"))
                                newRow.Table.Columns.Add("Materials", typeof(string));

                            if (orderFurWindow.SelectedFurnitureMaterials.ContainsKey(articleNum))
                            {
                                newRow["Materials"] = orderFurWindow.SelectedFurnitureMaterials[articleNum];
                            }
                            else
                            {
                                newRow["Materials"] = "Не указаны";
                            }

                            selectedFurniture[articleNum] = newRow;
                        }
                    }

                    UpdateSelectedItemsGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки выбранной мебели: {ex.Message}");
                }
            }

            orderFurWindow = null;
        }
        private void UpdateSelectedItemsGrid()
        {
            // Создаем новую таблицу
            DataTable dt = new DataTable();
           
            // Добавляем колонки с правильными типами данных
            dt.Columns.Add("ArticleNum", typeof(int));
            dt.Columns.Add("FurnitureName", typeof(string));
            dt.Columns.Add("Cost", typeof(decimal));  // Исправлено на decimal

            if (!dt.Columns.Contains("Materials"))
                dt.Columns.Add("Materials", typeof(string));
            dt.Columns.Add("ProductionTime", typeof(int));
            int maxDays = 0; // Максимальное время среди выбранных позиций
            // Заполняем таблицу данными
            foreach (var item in selectedFurniture.Values)
            {
                int currentDays = Convert.ToInt32(item["ProductionTime"]);
                maxDays = Math.Max(maxDays, currentDays);
                dt.Rows.Add(
                    item["ArticleNum"],
                    item["FurnitureName"],
                    item["Cost"],
                    
                    item["Materials"],
                    item["ProductionTime"]
                );
            }
            decimal totalCost = selectedFurniture.Values.Sum(row => Convert.ToDecimal(row["Cost"]));




            finalyCostBox.Text = $"Итоговая стоимость: {DeliveryCost + totalCost} рублей.";
            // Выводим общий срок в TextBlock
            if (selectedFurniture.Count > 0)
            {
                totalProductionTimeBox.Text = $"Срок поставки: {maxDays + 7} дней.";
            }
            else
            {
                totalProductionTimeBox.Text = "Срок поставки: не выбран ни один товар.";
            }

            // Привязываем данные к DataGrid
            SelectedItemsGrid.ItemsSource = dt.DefaultView;

            // Не очищаем selectedFurniture здесь! (это нужно делать только после сохранения заказа)
        }
        private void CheckAndResetAutoIncrement()
        {
            string query = "SELECT COUNT(*) FROM `order`";
            MySqlCommand cmd = new MySqlCommand(query);
            object result = db.ExecuteScalar(cmd);

            int orderCount = result != null ? Convert.ToInt32(result) : 0;

            if (orderCount == 0)
            {
                string resetOrderQuery = "ALTER TABLE `order` AUTO_INCREMENT = 1";
                MySqlCommand resetOrderCmd = new MySqlCommand(resetOrderQuery);
                db.ExecuteQuery(resetOrderCmd);
                Console.WriteLine("Сброс AUTO_INCREMENT для `order` выполнен");

                string resetDetailsQuery = "ALTER TABLE `orderdetails` AUTO_INCREMENT = 1";
                MySqlCommand resetDetailsCmd = new MySqlCommand(resetDetailsQuery);
                db.ExecuteQuery(resetDetailsCmd);
                Console.WriteLine("Сброс AUTO_INCREMENT для `orderdetails` выполнен");
            }
        }
        private void Create_Order_Button_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {

                // Проверки
                if (ClientComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите клиента!");
                    return;
                }

                if (selectedFurniture.Count == 0)
                {
                    MessageBox.Show("Добавьте хотя бы один товар!");
                    return;
                }

                


                int clientId = (int)ClientComboBox.SelectedValue;
                decimal totalCost = selectedFurniture.Values.Sum(row => Convert.ToDecimal(row["Cost"])) + DeliveryCost;
                string orderNumber = GenerateOrderNumber();

                // 1. Создаем основной заказ
                int orderId = db.CreateOrder(orderNumber, clientId, totalCost, _staffId);

                if (orderId <= 0)
                {
                    throw new Exception("Не удалось создать заказ. Проверьте:\n" +
                                      "- Существует ли клиент с ID " + clientId + "\n" +
                                      "- Корректность данных сотрудника (ID: " + _staffId + ")");
                }

                // 2. Добавляем детали заказа
                foreach (var item in selectedFurniture.Values)
                {
                    int articleNum = Convert.ToInt32(item["ArticleNum"]);

                    if (!db.AddOrderDetail(orderId, articleNum))
                    {
                        throw new Exception($"Ошибка добавления товара {articleNum}. " +
                                          $"Проверьте существование товара с артикулом {articleNum}");
                    }
                }

                MessageBox.Show($"Заказ №{orderNumber} успешно создан! ID: {orderId}");
                selectedFurniture.Clear();
                UpdateSelectedItemsGrid();
                LoadClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании заказа:\n{ex.Message}",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string GenerateOrderNumber()
        {
            // Генерируем номер заказа в формате ORD-YYYYMMDD-XXXX
            return $"ORD-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(DeliveryCostTextBox.Text))
            {
                DeliveryCost = Convert.ToInt32(DeliveryCostTextBox.Text);
                UpdateSelectedItemsGrid();
            }
            else
            {
                DeliveryCost = 0;
                UpdateSelectedItemsGrid();
            }
            
        }
    }
}
