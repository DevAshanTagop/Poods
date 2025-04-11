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
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для ProvidersBaseWindow.xaml
    /// </summary>
    public partial class ProvidersBaseWindow : Window
    {
        DataBaseHelper db = new DataBaseHelper();
        public ProvidersBaseWindow()
        {
            InitializeComponent();
            LoadProviders();
        }
        private void LoadProviders()
        {
            try
            {
                string query = "SELECT * FROM providers";
                DataTable dt = db.GetData(query);
                DataGridProvider.ItemsSource = dt.DefaultView;
                ComboBoxIdProvider.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ComboBoxIdProvider.Items.Add(row["IdProvider"]);
                }
                if (ComboBoxIdProvider.Items.Count <= 0)
                {
                    string query2 = "ALTER TABLE providers AUTO_INCREMENT = 1";
                    MySqlCommand cmd = new MySqlCommand(query2);
                    db.ExecuteQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}");
            }
        }
        private void AddStaff(string NameTxbx, string ContactPersonTxBx, string PhoneTxBx, string EmailText, string AddressText)
        {
            try
            {
                string query = @"INSERT INTO providers 
                                (ProviderName, ContactPerson, Phone, Email, Address) 
                                VALUES (@name, @contact, @phone, @email, @address)";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@name", NameTxbx);
            cmd.Parameters.AddWithValue("@contact", ContactPersonTxBx);
            cmd.Parameters.AddWithValue("@phone", PhoneTxBx);
            cmd.Parameters.AddWithValue("@email", EmailText);
            cmd.Parameters.AddWithValue("@address", AddressText);
            if (db.ExecuteQuery(cmd))
            {

                    LoadProviders();
                ClearingTextBox();
                MessageBox.Show("Добавление успешно!");

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
            }
        }
        private void ClearingTextBox()
        {
            NameTextBox.Text = string.Empty;
            ContactPersonTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
        }
        private void Add_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields(out var message))
            {
                string EmailText = string.IsNullOrEmpty(EmailTextBox.Text) ? string.Empty : EmailTextBox.Text;
                string AddressText = string.IsNullOrEmpty(AddressTextBox.Text) ? string.Empty : AddressTextBox.Text;

                AddStaff(NameTextBox.Text, ContactPersonTextBox.Text, PhoneTextBox.Text, EmailText, AddressText);


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

            ValidateField(NameTextBox, "Название", errors);
            ValidateField(ContactPersonTextBox, "Контактное лицо", errors);

           
            ValidateField(EmailTextBox, "Номер телефона", errors);

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
        private void UpdateProvider(int selectedId, string NameTxbx, string ContactPersonTxBx, string PhoneTxBx, string EmailText, string AddressText)
        {
            List<string> setClauses = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            if (!string.IsNullOrEmpty(NameTxbx))
            {
                setClauses.Add("ProviderName = @name");
                cmd.Parameters.AddWithValue("@name", NameTxbx);
            }
            if (!string.IsNullOrEmpty(ContactPersonTxBx))
            {
                setClauses.Add("ContactPerson = @contactPerson");
                cmd.Parameters.AddWithValue("@contactPerson", ContactPersonTxBx);
            }
            if (!string.IsNullOrEmpty(PhoneTxBx))
            {
                setClauses.Add("Phone = @phone");
                cmd.Parameters.AddWithValue("@phone", PhoneTxBx);
            }
            if (!string.IsNullOrEmpty(EmailText))
            {
                setClauses.Add("Email = @email");
                cmd.Parameters.AddWithValue("@email", EmailText);
            }
            if (!string.IsNullOrEmpty(AddressText))
            {
                setClauses.Add("Address = @address");
                cmd.Parameters.AddWithValue("@address", AddressText);
            }
            if (setClauses.Count == 0)
            {
                MessageBox.Show("Нет данных для обновления.");
                return;
            }
            string query = $"UPDATE providers SET {string.Join(", ", setClauses)} WHERE IdProvider = @id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", selectedId);

            if (db.ExecuteQuery(cmd))
            {
                MessageBox.Show("Данные обновлены успешно!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных");
            }
        }
        private void Update_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxIdProvider.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ComboBoxIdProvider.SelectedItem);
                string NameTxbx = NameTextBox.Text;
                string ContactPersonTxBx = ContactPersonTextBox.Text;
                string PhoneTxBx = PhoneTextBox.Text;
                string EmailText = EmailTextBox.Text;
                string AddressText = AddressTextBox.Text;
                if (!string.IsNullOrEmpty(NameTxbx) || !string.IsNullOrEmpty(ContactPersonTxBx) ||
                    !string.IsNullOrEmpty(PhoneTxBx) || !string.IsNullOrEmpty(EmailText) ||
                    !string.IsNullOrEmpty(AddressText) )

                {
                    try
                    {
                        UpdateProvider(selectedId, NameTxbx, ContactPersonTxBx, PhoneTxBx, EmailText, AddressText);
                        LoadProviders();
                        ClearingTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                    }
                }
            }
        }
        private void Delet_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxIdProvider.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика для удаления");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить этого поставщика?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int selectedId = (int)ComboBoxIdProvider.SelectedValue;
                DeleteProvider(selectedId);
            }
        }
        private void DeleteProvider(int id)
        {
            try
            {
                string query = "DELETE FROM providers WHERE IdProvider = @id";
                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@id", id);

                if (db.ExecuteQuery(cmd))
                {
                    LoadProviders();
                    MessageBox.Show("Поставщик успешно удален");
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("Нельзя удалить поставщика, так как есть связанные материалы");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }

        private void Update_DataGrid_Provider_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadProviders();
        }
    }
}
