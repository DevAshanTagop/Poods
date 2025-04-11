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

namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для ClientsBaseWindow.xaml
    /// </summary>
    public partial class ClientsBaseWindow : Window
    {
        DataBaseHelper db = new DataBaseHelper();
        public ClientsBaseWindow()
        {
            InitializeComponent();
            LoadClients();
        }
        private void LoadClients()
        {
            DataTable dt = db.GetData("SELECT * FROM Clients");
            DataGridClients.ItemsSource = dt.DefaultView;
            ComboBoxIdClient.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxIdClient.Items.Add(row["IdClient"]); 
            }
            if (ComboBoxIdClient.Items.Count <= 0)
            {
                string query = "ALTER TABLE Clients AUTO_INCREMENT = 1";
                MySqlCommand cmd = new MySqlCommand(query);
                db.ExecuteQuery(cmd);
            }

        }


        private void Add_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields(out var message))
            {
                string MiddlуNameText = string.IsNullOrEmpty(MiddlуNameTextBox.Text) ? string.Empty : MiddlуNameTextBox.Text;
                string EmailText = string.IsNullOrEmpty(EmailTextBox.Text) ? string.Empty : EmailTextBox.Text;
                AddStaff(LastNameTextBox.Text, FirstNameTextBox.Text, MiddlуNameText, AdressTextBox.Text, PhoneNumberTextBox.Text, EmailText);


            }
            else
            {
                MessageBox.Show(message);
            }
        }
        public bool ValidateFields(out string errorMessage)
        {
            var errors = new List<string>();

            // Проверка обязательных полей с автоматическим подсветом

            ValidateField(FirstNameTextBox, "Имя", errors);
            ValidateField(LastNameTextBox, "Фамилия", errors);

            ValidateField(AdressTextBox, "Адрес", errors);
            ValidateField(PhoneNumberTextBox, "Номер телефона", errors);

            errorMessage = errors.Any() ? $"Не заполнены поля ввода:{string.Join(", ", errors)}" : null;
            return !errors.Any();
        }
        private void ValidateField(TextBox field, string fieldName, List<string> errors)
        {
            if (string.IsNullOrEmpty(field.Text))
            {

                errors.Add(fieldName);
            }

        }
        public void AddStaff(string LastNameTxBx, string FirstNameTxBx, string MiddlуNameTxBx, string AddressTxBx, string PhoneTxBx, string EmailTxBx)
        {
            string query = "INSERT INTO Clients (LastName, FirstName, MiddlуName, Address, Phone, Email) VALUES (@lastName, @firstName, @middlуName, @address,@phone,@email)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@lastName", LastNameTxBx);
            cmd.Parameters.AddWithValue("@firstName", FirstNameTxBx);
            cmd.Parameters.AddWithValue("@middlуName", MiddlуNameTxBx);
            cmd.Parameters.AddWithValue("@address", AddressTxBx);
            cmd.Parameters.AddWithValue("@phone", PhoneTxBx);
            cmd.Parameters.AddWithValue("@email", EmailTxBx);
            
            if (db.ExecuteQuery(cmd))
            {
                
                LoadClients();
                ClearingTextBox();
                MessageBox.Show("Клиент добавлен успешно!");

            }

        }
        private void ClearingTextBox()
        {
            LastNameTextBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            MiddlуNameTextBox.Text = string.Empty;
            AdressTextBox.Text = string.Empty;
            PhoneNumberTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;

        }
        public void UpdateClient(int selectedId, string LastNameTxBx, string FirstNameTxBx, string MiddlуNameTxBx, string AddressTxBx, string PhoneTxBx, string EmailTxBx)
        {
            List<string> setClauses = new List<string>();
            MySqlCommand cmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(LastNameTxBx))
            {
                setClauses.Add("LastName = @lastName");
                cmd.Parameters.AddWithValue("@lastName", LastNameTxBx);
            }

            if (!string.IsNullOrEmpty(FirstNameTxBx))
            {
                setClauses.Add("FirstName = @firstName");
                cmd.Parameters.AddWithValue("@firstName", FirstNameTxBx);
            }

            if (!string.IsNullOrEmpty(MiddlуNameTxBx))
            {
                setClauses.Add("MiddlуName = @middlуName");
                cmd.Parameters.AddWithValue("@middlуName", MiddlуNameTxBx);
            }

            if (!string.IsNullOrEmpty(AddressTxBx))
            {
                setClauses.Add("Position = @position");
                cmd.Parameters.AddWithValue("@position", AddressTxBx);
            }

            
            if (!string.IsNullOrEmpty(PhoneTxBx))
            {
                setClauses.Add("Login = @login");
                cmd.Parameters.AddWithValue("@login", PhoneTxBx);
            }

            if (!string.IsNullOrEmpty(EmailTxBx))
            {
                setClauses.Add("Password = @password");
                cmd.Parameters.AddWithValue("@password", EmailTxBx);
            }

            if (setClauses.Count == 0)
            {
                MessageBox.Show("Нет данных для обновления.");
                return;
            }

            string query = $"UPDATE Clients SET {string.Join(", ", setClauses)} WHERE IdClient = @id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", selectedId);

            if (db.ExecuteQuery(cmd))
            {
                MessageBox.Show("Данные клиента обновлены успешно!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных");
            }
        }
        private void Update_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxIdClient.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ComboBoxIdClient.SelectedItem);
               

                // Исправлено: правильный порядок полей
                string LastNameTxBx = LastNameTextBox.Text;
                string FirstNameTxBx = FirstNameTextBox.Text;
                string MiddlуNameTxBx = MiddlуNameTextBox.Text;
                string AddressTxBx = AdressTextBox.Text;
                string PhoneTxBx = PhoneNumberTextBox.Text;
                string EmailTxBx = EmailTextBox.Text;

                if (!string.IsNullOrEmpty(LastNameTxBx) || !string.IsNullOrEmpty(FirstNameTxBx) ||
                    !string.IsNullOrEmpty(MiddlуNameTxBx) || !string.IsNullOrEmpty(AddressTxBx) ||
                    !string.IsNullOrEmpty(PhoneTxBx) || !string.IsNullOrEmpty(EmailTxBx) )
                    
                {
                    try
                    {
                        UpdateClient(selectedId, LastNameTxBx,  FirstNameTxBx,  MiddlуNameTxBx,  AddressTxBx,  PhoneTxBx, EmailTxBx);
                        LoadClients();
                        ClearingTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Внесите хотя бы в одно поле, информацию.");
                }
            }
            else
            {
                MessageBox.Show("Выберите ID сотрудника для обновления.");
            }
        }

        private void Delet_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный ID из ComboBox
            if (ComboBoxIdClient.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выполнить действие?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    int selectedId = Convert.ToInt32(ComboBoxIdClient.SelectedItem);  

                   
                    DeleteClient(selectedId);

                    
                    LoadClients();
                }

            }
        }
        public bool DeleteClient(int selectedId)
        {
            try
            {
                // 1. Получаем все Id заказов клиента
                var orderIds = new List<int>();
                string selectOrdersQuery = "SELECT IdOrder FROM `order` WHERE IdClient = @clientId";
                var selectCmd = new MySqlCommand(selectOrdersQuery);
                selectCmd.Parameters.AddWithValue("@clientId", selectedId);

                DataTable ordersTable = db.GetData(selectCmd.CommandText);
                foreach (DataRow row in ordersTable.Rows)
                {
                    orderIds.Add(Convert.ToInt32(row["IdOrder"]));
                }

                // 2. Удаляем orderdetails для каждого заказа
                foreach (int orderId in orderIds)
                {
                    string deleteDetailsQuery = "DELETE FROM orderdetails WHERE IdOrder = @orderId";
                    var detailsCmd = new MySqlCommand(deleteDetailsQuery);
                    detailsCmd.Parameters.AddWithValue("@orderId", orderId);

                    if (!db.ExecuteQuery(detailsCmd))
                    {
                        throw new Exception($"Не удалось удалить детали заказа {orderId}");
                    }
                }

                // 3. Удаляем сами заказы
                foreach (int orderId in orderIds)
                {
                    string deleteOrderQuery = "DELETE FROM `order` WHERE IdOrder = @orderId";
                    var orderCmd = new MySqlCommand(deleteOrderQuery);
                    orderCmd.Parameters.AddWithValue("@orderId", orderId);

                    if (!db.ExecuteQuery(orderCmd))
                    {
                        throw new Exception($"Не удалось удалить заказ {orderId}");
                    }
                }

                // 4. Удаляем клиента
                string deleteClientQuery = "DELETE FROM clients WHERE IdClient = @clientId";
                var clientCmd = new MySqlCommand(deleteClientQuery);
                clientCmd.Parameters.AddWithValue("@clientId", selectedId);

                if (!db.ExecuteQuery(clientCmd))
                {
                    throw new Exception("Не удалось удалить клиента");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении клиента: " + ex.Message);
                return false;
            }
        }

        private void Update_DataGrid_Client_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }
    }
}
