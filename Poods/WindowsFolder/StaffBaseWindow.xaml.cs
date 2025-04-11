using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffBaseWindow.xaml
    /// </summary>
    public partial class StaffBaseWindow : Window
    {
        DataBaseHelper db = new DataBaseHelper();
        public StaffBaseWindow()
        {
            InitializeComponent();
            LoadStaff();
        }
        private void LoadStaff()
        {
            DataTable dt = db.GetData("SELECT * FROM staff");
            DataGridStaff.ItemsSource = dt.DefaultView;
            ComboBoxIdStaff.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ComboBoxIdStaff.Items.Add(row["IdStaff"]); // Добавляем только ID в ComboBox
            }
            if (ComboBoxIdStaff.Items.Count <= 0)
            {
                string query = "ALTER TABLE staff AUTO_INCREMENT = 1";
                MySqlCommand cmd = new MySqlCommand(query);
                db.ExecuteQuery(cmd);
            }

            try
            {
                string query = @"
                        SELECT COLUMN_TYPE 
                        FROM INFORMATION_SCHEMA.COLUMNS 
                        WHERE TABLE_SCHEMA = DATABASE() 
                        AND TABLE_NAME = 'staff' 
                        AND COLUMN_NAME = 'Position'";
                var position = db.GetEnumValues(query);
                position.Insert(0, "");
                ComboBoxPosition.ItemsSource = position;
                ComboBoxPosition.SelectedIndex = 0;
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
                        AND TABLE_NAME = 'staff' 
                        AND COLUMN_NAME = 'StatusOfAccount'";
                var status = db.GetEnumValues(query);
                ComboBoxStatusOfAccount.ItemsSource = status;
                ComboBoxStatusOfAccount.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки Cтатуса: " + ex.Message);
            }
        }
        public void AddStaff(string LastNameTxBx, string FirstNameTxBx, string MiddlуNameTxBx, string PositionCmBx, string ShiftNumberTxBx, string SalaryTxBx, string LoginTxBx, string PasswordTxBx, string StatusOfAccountCmBx)
        {
            string query = "INSERT INTO staff (LastName, FirstName, MiddlуName, Position,ShiftNumber, Salary, Login, Password, StatusOfAccount ) VALUES (@lastName, @firstName, @middlуName, @position,@shiftNumber, @salary,  @login, @password, @statusOfAccount )";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@lastName", LastNameTxBx);
            cmd.Parameters.AddWithValue("@firstName", FirstNameTxBx);
            cmd.Parameters.AddWithValue("@middlуName", MiddlуNameTxBx);
            cmd.Parameters.AddWithValue("@position", PositionCmBx);
            cmd.Parameters.AddWithValue("@shiftNumber", ShiftNumberTxBx);
            cmd.Parameters.AddWithValue("@salary", SalaryTxBx);
            cmd.Parameters.AddWithValue("@login", LoginTxBx);
            cmd.Parameters.AddWithValue("@password", PasswordTxBx);
            cmd.Parameters.AddWithValue("@statusofaccount", StatusOfAccountCmBx);
            if (db.ExecuteQuery(cmd))
            {
                // Обновляем DataGrid после успешного добавления клиента
                LoadStaff();
                ClearingTextBox();
                MessageBox.Show("Сотрудник добавлен успешно!");

            }

        }
        private void ClearingTextBox()
        {
            LastNameTextBox.Text = string.Empty;
            FirstNameTextBox.Text = string.Empty;
            ShiftNumberTextBox.Text = string.Empty;
            MiddlуNameTextBox.Text = string.Empty;
            LoginTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            SalaryTextBox.Text = string.Empty;

        }
        private void Add_Staff_Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedPosition = ComboBoxPosition.SelectedItem as string;
            string selectedStatus = ComboBoxStatusOfAccount.SelectedItem as string;
            if (ValidateFields(out var message))
            {
                AddStaff( LastNameTextBox.Text, FirstNameTextBox.Text, MiddlуNameTextBox.Text, selectedPosition, ShiftNumberTextBox.Text, SalaryTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, selectedStatus);


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
            ValidateField(MiddlуNameTextBox, "Отчество", errors);
            ValidateField(SalaryTextBox, "Зарплата", errors);
            ValidateFieldCmBX(ComboBoxPosition, "Должность", errors);
            ValidateField(ShiftNumberTextBox, "Номер смены", errors);
            ValidateField(LoginTextBox, "Логин", errors);
            ValidateField(PasswordTextBox, "Пароль", errors);

            errorMessage = errors.Any() ? $"Не заполнены поля ввода:{string.Join(", ", errors)}" : null;
            return !errors.Any();
        }

        private void ValidateFieldCmBX(ComboBox field, string fieldName, List<string> errors)
        {
            if (string.IsNullOrEmpty(field.Text))
            {

                errors.Add(fieldName);
            }

        }

        private void ValidateField(TextBox field, string fieldName, List<string> errors)
        {
            if (string.IsNullOrEmpty(field.Text))
            {

                errors.Add(fieldName);
            }

        }


        private void Update_Staff_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxIdStaff.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ComboBoxIdStaff.SelectedItem);
                string PositionCmBx = ComboBoxPosition.SelectedItem as string;
                string StatusOfAccountCmBx = ComboBoxStatusOfAccount.SelectedItem as string;

                // Исправлено: правильный порядок полей
                string LastNameTxBx = LastNameTextBox.Text;
                string FirstNameTxBx = FirstNameTextBox.Text;
                string MiddlуNameTxBx = MiddlуNameTextBox.Text;
                string ShiftNumberTxBx = ShiftNumberTextBox.Text;
                string SalaryTxBx = SalaryTextBox.Text;
                string LoginTxBx = LoginTextBox.Text;
                string PasswordTxBx = PasswordTextBox.Text;

                if (!string.IsNullOrEmpty(LastNameTxBx) || !string.IsNullOrEmpty(FirstNameTxBx) ||
                    !string.IsNullOrEmpty(MiddlуNameTxBx) || !string.IsNullOrEmpty(SalaryTxBx) ||
                    !string.IsNullOrEmpty(LoginTxBx) || !string.IsNullOrEmpty(PasswordTxBx) ||
                    !string.IsNullOrEmpty(PositionCmBx) || !string.IsNullOrEmpty(ShiftNumberTxBx) || !string.IsNullOrEmpty(StatusOfAccountCmBx))
                {
                    try
                    {
                        UpdateStaff(selectedId, LastNameTxBx, FirstNameTxBx, MiddlуNameTxBx,
                                    PositionCmBx, ShiftNumberTxBx, SalaryTxBx, LoginTxBx, PasswordTxBx, StatusOfAccountCmBx);
                        LoadStaff();
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

        public void UpdateStaff(int selectedId, string LastNameTxBx, string FirstNameTxBx, string MiddlуNameTxBx,
                                string PositionCmBx,string ShiftNumberTxBx, string SalaryTxBx, string LoginTxBx, string PasswordTxBx,
                                string StatusOfAccountCmBx)
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

            if (!string.IsNullOrEmpty(PositionCmBx))
            {
                setClauses.Add("Position = @position");
                cmd.Parameters.AddWithValue("@position", PositionCmBx);
            }
            if (!string.IsNullOrEmpty(ShiftNumberTxBx))
            {
                setClauses.Add("ShiftNumber = @shiftNumber");
                cmd.Parameters.AddWithValue("@shiftNumber", ShiftNumberTxBx);
            }


            if (!string.IsNullOrEmpty(SalaryTxBx))
            {
                if (decimal.TryParse(SalaryTxBx, out decimal salaryValue))
                {
                    setClauses.Add("Salary = @salary");
                    cmd.Parameters.AddWithValue("@salary", salaryValue);
                }
                else
                {
                    MessageBox.Show("Некорректное значение зарплаты");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(LoginTxBx))
            {
                setClauses.Add("Login = @login");
                cmd.Parameters.AddWithValue("@login", LoginTxBx);
            }

            if (!string.IsNullOrEmpty(PasswordTxBx))
            {
                setClauses.Add("Password = @password");
                cmd.Parameters.AddWithValue("@password", PasswordTxBx);
            }

            if (!string.IsNullOrEmpty(StatusOfAccountCmBx))
            {
                setClauses.Add("StatusOfAccount = @statusOfAccount");
                cmd.Parameters.AddWithValue("@statusOfAccount", StatusOfAccountCmBx);
            }

            if (setClauses.Count == 0)
            {
                MessageBox.Show("Нет данных для обновления.");
                return;
            }

            string query = $"UPDATE staff SET {string.Join(", ", setClauses)} WHERE IdStaff = @id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", selectedId);

            if (db.ExecuteQuery(cmd))
            {
                MessageBox.Show("Данные сотрудника обновлены успешно!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных");
            }
        }
        private void Delet_Staff_Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный ID из ComboBox
            if (ComboBoxIdStaff.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выполнить действие?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    int selectedId = Convert.ToInt32(ComboBoxIdStaff.SelectedItem);  // Преобразуем выбранный ID в число

                    // Теперь у вас есть ID, и вы можете выполнить действия, например, удалить клиента
                    Deletestaff(selectedId);

                    // Перезагружаем список клиентов после удаления
                    LoadStaff();
                }
                
            }
            else
            {
                MessageBox.Show("Выберите ID.");
            }
        }
        public void Deletestaff(int id)
        {
            // Использование параметрического запроса для безопасности
            string query = "DELETE FROM staff WHERE IdStaff = @id";

            // Создаем команду
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);

            // Выполняем запрос с помощью метода ExecuteQuery
            db.ExecuteQuery(cmd);
        }
        private void Update_Grid_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadStaff();
        }
    }
}
