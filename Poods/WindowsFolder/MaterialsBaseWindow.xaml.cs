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
    /// Логика взаимодействия для MaterialsBaseWindow.xaml
    /// </summary>
    public partial class MaterialsBaseWindow : Window
    {
        DataBaseHelper db = new DataBaseHelper();
        public MaterialsBaseWindow()
        {
            InitializeComponent();
            LoadMaterials();
        }
        private void LoadMaterials()
        {
            string query = "SELECT * FROM materials";
            DataTable dt = db.GetData(query);
            DataGridMaterials.ItemsSource = dt.DefaultView;
            IdMatirialCmBx.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                IdMatirialCmBx.Items.Add(row["IdMaterials"]); // Добавляем только ID в ComboBox
            }
            if (IdMatirialCmBx.Items.Count <= 0)
            {
                string query3 = "ALTER TABLE materials AUTO_INCREMENT = 1";
                MySqlCommand cmd = new MySqlCommand(query3);
                db.ExecuteQuery(cmd);
            }
            try
            {
                string query2 = "SELECT IdProvider, CONCAT(IdProvider, ' ',ProviderName ) AS FullName FROM providers";
                DataTable dt2 = db.GetData(query2);

                ProvidersCmBx.ItemsSource = dt2.DefaultView;
                ProvidersCmBx.DisplayMemberPath = "FullName";
                ProvidersCmBx.SelectedValuePath = "IdProvider";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}");
            }
        }
        private void AddMaterials(string NameTxBx, string DescriptionTxBx, string CostTxBx, string QuantityTxBx, int selectedProvider)
        {
            try
            {
                string query = @"INSERT INTO materials 
                        (MaterialName, Description, Cost, Quantity, IdProvider) 
                        VALUES (@materialName, @description, @cost, @quantity, @idProvider)";

                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@materialName", NameTxBx);
                cmd.Parameters.AddWithValue("@description", DescriptionTxBx);
                cmd.Parameters.AddWithValue("@cost", decimal.Parse(CostTxBx));
                cmd.Parameters.AddWithValue("@quantity", int.Parse(QuantityTxBx));
                cmd.Parameters.AddWithValue("@idProvider", selectedProvider);

                if (db.ExecuteQuery(cmd))
                {
                    LoadMaterials();
                    ClearingTextBox();
                    MessageBox.Show("Материал успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении материала");
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
            DescriptionTextBox.Text = string.Empty;
            CostTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
            

        }
        private void Add_Materials_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFields(out var message))
            {
                // Правильное получение выбранного поставщика
                int selectedProviderId = ProvidersCmBx.SelectedValue != null ?
                    Convert.ToInt32(ProvidersCmBx.SelectedValue) : 0;

                if (selectedProviderId <= 0)
                {
                    MessageBox.Show("Выберите поставщика!");
                    return;
                }

                // Проверка числовых полей
                if (!decimal.TryParse(CostTextBox.Text, out decimal cost) || cost <= 0)
                {
                    MessageBox.Show("Введите корректную стоимость (положительное число)");
                    return;
                }

                if (!int.TryParse(QuantityTextBox.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("Введите корректное количество (целое неотрицательное число)");
                    return;
                }

                AddMaterials(
                    NameTextBox.Text,
                    DescriptionTextBox.Text,
                    cost.ToString(),
                    quantity.ToString(),
                    selectedProviderId
                );
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
            ValidateField(DescriptionTextBox, "Время создания", errors);
            ValidateField(CostTextBox, "Стоимость", errors);
            ValidateField(QuantityTextBox, "Количество", errors);

            ValidateFieldCmBX(ProvidersCmBx, "Поставшик", errors);


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
        public void UpdateMaterial(int selectedId, string NameTxBx, string DescriptionTxBx,
                         string CostTxBx, string QuantityTxBx, int? ProviderId)
        {
            List<string> setClauses = new List<string>();
            MySqlCommand cmd = new MySqlCommand();

            if (!string.IsNullOrEmpty(NameTxBx))
            {
                setClauses.Add("MaterialName = @name");
                cmd.Parameters.AddWithValue("@name", NameTxBx);
            }

            if (!string.IsNullOrEmpty(DescriptionTxBx))
            {
                setClauses.Add("Description = @description");
                cmd.Parameters.AddWithValue("@description", DescriptionTxBx);
            }

            if (!string.IsNullOrEmpty(CostTxBx))
            {
                if (decimal.TryParse(CostTxBx, out decimal cost))
                {
                    setClauses.Add("Cost = @cost");
                    cmd.Parameters.AddWithValue("@cost", cost);
                }
                else
                {
                    MessageBox.Show("Некорректное значение стоимости");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(QuantityTxBx))
            {
                if (int.TryParse(QuantityTxBx, out int quantity))
                {
                    setClauses.Add("Quantity = @quantity");
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                }
                else
                {
                    MessageBox.Show("Некорректное значение количества");
                    return;
                }
            }

            if (ProviderId != null)
            {
                setClauses.Add("IdProvider = @providerId");
                cmd.Parameters.AddWithValue("@providerId", ProviderId);
            }

            if (setClauses.Count == 0)
            {
                MessageBox.Show("Нет данных для обновления");
                return;
            }

            string query = $"UPDATE materials SET {string.Join(", ", setClauses)} WHERE IdMaterials = @id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", selectedId);

            if (db.ExecuteQuery(cmd))
            {
                MessageBox.Show("Данные материала обновлены успешно!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных");
            }
        }

        private void Update_Materials_Button_Click(object sender, RoutedEventArgs e)
        {
            if (IdMatirialCmBx.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(IdMatirialCmBx.SelectedItem);
                int? selectedProviderId = ProvidersCmBx.SelectedValue != null ?
                    Convert.ToInt32(ProvidersCmBx.SelectedValue) : (int?)null;

                string NameTxBx = NameTextBox.Text;
                string DescriptionTxBx = DescriptionTextBox.Text;
                string CostTxBx = CostTextBox.Text;
                string QuantityTxBx = QuantityTextBox.Text;

                if (!string.IsNullOrEmpty(NameTxBx) || !string.IsNullOrEmpty(DescriptionTxBx) ||
                    !string.IsNullOrEmpty(CostTxBx) || !string.IsNullOrEmpty(QuantityTxBx) ||
                    selectedProviderId != null)
                {
                    try
                    {
                        UpdateMaterial(selectedId, NameTxBx, DescriptionTxBx, CostTxBx, QuantityTxBx, selectedProviderId);
                        LoadMaterials();
                        ClearingTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Внесите изменения хотя бы в одно поле");
                }
            }
            else
            {
                MessageBox.Show("Выберите ID материала для обновления");
            }
        }

        private void Delet_Materials_Button_Click(object sender, RoutedEventArgs e)
        {
            if (IdMatirialCmBx.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить материал?",
                    "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.OK)
                {
                    int selectedId = Convert.ToInt32(IdMatirialCmBx.SelectedItem);
                    DeleteMaterial(selectedId);
                    LoadMaterials();
                }
            }
            else
            {
                MessageBox.Show("Выберите ID материала");
            }
        }

        public void DeleteMaterial(int id)
        {
            string query = "DELETE FROM materials WHERE IdMaterials = @id";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@id", id);

            if (db.ExecuteQuery(cmd))
            {
                MessageBox.Show("Материал успешно удален");
            }
            else
            {
                MessageBox.Show("Ошибка при удалении материала");
            }
        }

        private void Update_DataGrid_Furniture_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadMaterials();
        }

       
    }
}
