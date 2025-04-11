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
    /// Логика взаимодействия для FurnitureBaseWindow.xaml
    /// </summary>
    public partial class FurnitureBaseWindow : Window
    {
        private List<int> selectedMaterialIds = new List<int>();
        DataBaseHelper db = new DataBaseHelper();
        public FurnitureBaseWindow()
        {
            InitializeComponent();
            LoadFurniture();
        }
        private void LoadFurniture()
        {
            string query = @"SELECT 
    f.ArticleNum,
    f.FurnitureName,

    f.Cost,
    f.ProductionTime,
    f.ShiftNumber,
    IFNULL(
        (SELECT GROUP_CONCAT(m.MaterialName SEPARATOR ', ') 
         FROM furniturematerials fm
         JOIN materials m ON fm.IdMaterials = m.IdMaterials
         WHERE fm.ArticleNum = f.ArticleNum),
        'Материалы не указаны'
    ) AS MaterialsList
FROM furniture f
ORDER BY f.ArticleNum";

            DataTable dt = db.GetData(query);
            DataGridFurniture.ItemsSource = dt.DefaultView;
            ArticleNumCmBx.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ArticleNumCmBx.Items.Add(row["ArticleNum"]); 
            }
            if (ArticleNumCmBx.Items.Count <= 0)
            {
                string query2 = "ALTER TABLE furniture AUTO_INCREMENT = 1";
                MySqlCommand cmd = new MySqlCommand(query2);
                db.ExecuteQuery(cmd);
            }
            DataTable dt2 = db.GetData("SELECT DISTINCT ShiftNumber FROM staff WHERE ShiftNumber IS NOT NULL");
            foreach (DataRow row in dt2.Rows)
            {
                ShiftNumberCmBx.Items.Add(row["ShiftNumber"]);
            }


        }
        private void Add_Furniture_Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedShiftNumber = Convert.ToInt32(ShiftNumberCmBx.SelectedItem);
            
            if (ValidateFields(out var message))
            {
                if (!decimal.TryParse(CostTextBox.Text, out decimal cost) || cost <= 0)
                {
                    MessageBox.Show("Введите корректную стоимость (положительное число)");
                    return;
                }
                if (!int.TryParse(ProductionTimeTextBox.Text, out int productionTime) || productionTime <= 0)
                {
                    MessageBox.Show("Введите корректное время производства (целое положительное число)");
                    return;
                }
                AddFurniture(NameTextBox.Text, CostTextBox.Text, ProductionTimeTextBox.Text, selectedShiftNumber);


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
            ValidateField(CostTextBox, "Стоимость", errors);
            ValidateField(ProductionTimeTextBox, "Время создания", errors);
            
            ValidateFieldCmBX(ShiftNumberCmBx, "Номер смены", errors);
            

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
        public void AddFurniture(string FurnitureNameTxBx, string CostTxBx, string ProductionTimeTxBx, int? ShiftNumberCmBx)
        {
            // Проверка выбранных материалов ДО добавления мебели
            if (selectedMaterialIds == null || selectedMaterialIds.Count == 0)
            {
                MessageBox.Show("Выберите материалы перед добавлением мебели!");
                return;
            }

            // Добавляем мебель
            string query = @"INSERT INTO furniture (FurnitureName, Cost, ProductionTime, ShiftNumber) 
                    VALUES (@furnitureName, @cost, @productionTime, @shiftNumber); 
                    SELECT LAST_INSERT_ID();";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@furnitureName", FurnitureNameTxBx);
            cmd.Parameters.AddWithValue("@cost", decimal.Parse(CostTxBx)); // Явное преобразование
            cmd.Parameters.AddWithValue("@productionTime", int.Parse(ProductionTimeTxBx));
            cmd.Parameters.AddWithValue("@shiftNumber", ShiftNumberCmBx ?? (object)DBNull.Value);

            int articleNum = Convert.ToInt32(db.ExecuteScalar(cmd));
            MessageBox.Show($"Добавлена мебель с ArticleNum: {articleNum}");
            // Добавляем материалы с транзакцией
            bool success = true;
            foreach (int materialId in selectedMaterialIds)
            {
                string insertMaterial = @"INSERT INTO furniturematerials (ArticleNum, IdMaterials) 
                                VALUES (@id, @matId)";
                var matCmd = new MySqlCommand(insertMaterial);
                matCmd.Parameters.AddWithValue("@id", articleNum);
                matCmd.Parameters.AddWithValue("@matId", materialId);

                if (!db.ExecuteQuery(matCmd))
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                LoadFurniture();
                ClearingTextBox();
                MessageBox.Show("Мебель и материалы успешно добавлены!");
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении материалов!");
            }
        }


        private void ClearingTextBox()
        {
            NameTextBox.Clear();
            
            CostTextBox.Clear();
            ProductionTimeTextBox.Clear();
            ShiftNumberCmBx.SelectedIndex = -1;
            selectedMaterialIds.Clear();
        }
        private void UpdateFurniture(int selectedId, string FurnitureNameTxBx, string CostTxBx, string ProductionTimeTxBx, int? ShiftNumberCmBx)
        {
            List<string> setClauses = new List<string>();
            MySqlCommand cmd = new MySqlCommand();
            if (!string.IsNullOrEmpty(FurnitureNameTxBx))
            {
                setClauses.Add("FurnitureName = @furnitureName");
                cmd.Parameters.AddWithValue("@furnitureName", FurnitureNameTxBx);
            }

            if (!string.IsNullOrEmpty(CostTxBx))
            {
                if (!decimal.TryParse(CostTextBox.Text, out decimal cost) || cost <= 0)
                {
                    MessageBox.Show("Введите корректную стоимость (положительное число)");
                    return;
                }

                setClauses.Add("Cost = @cost");
                cmd.Parameters.AddWithValue("@cost", CostTxBx);
            }

            if (!string.IsNullOrEmpty(ProductionTimeTxBx))
            {
                if (!int.TryParse(ProductionTimeTextBox.Text, out int productionTime) || productionTime <= 0)
                {
                    MessageBox.Show("Введите корректное время производства (целое положительное число)");
                    return;
                }
                setClauses.Add("ProductionTime = @productionTime");
                cmd.Parameters.AddWithValue("@productionTime", ProductionTimeTxBx);
            }
            if (ShiftNumberCmBx.HasValue && ShiftNumberCmBx.Value > 0)
            {
                setClauses.Add("ShiftNumber = @shiftNumber");
                cmd.Parameters.AddWithValue("@shiftNumber", ShiftNumberCmBx.Value);
            }
            else
            {
                setClauses.Add("ShiftNumber = NULL");
            }
            string query = $"UPDATE furniture SET {string.Join(", ", setClauses)} WHERE ArticleNum = @id";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@id", selectedId);

            if (db.ExecuteQuery(cmd))
            {
                // Обновляем материалы только если они были выбраны
                if (selectedMaterialIds.Count > 0)
                {
                    string querycn = "SELECT COUNT(*) FROM furniturematerials WHERE ArticleNum = @id";
                   
                    MySqlCommand cmd2 = new MySqlCommand(querycn);
                    cmd2.Parameters.AddWithValue("@id", selectedId);
                    object result = db.ExecuteScalar(cmd2);

                    int orderCount = result != null ? Convert.ToInt32(result) : 0;

                    if (orderCount > 0)
                    {
                        // Удаляем старые материалы
                        string deleteMaterials = "DELETE FROM furniturematerials WHERE ArticleNum = @id";
                        var delCmd = new MySqlCommand(deleteMaterials);
                        delCmd.Parameters.AddWithValue("@id", selectedId);
                        if (!db.ExecuteQuery(delCmd))
                        {
                            MessageBox.Show("Ошибка при удалении старых материалов");
                            return;
                        }
                    }
                        

                    

                    // Добавляем новые материалы
                    foreach (int materialId in selectedMaterialIds)
                    {
                        string insertMaterial = "INSERT INTO furniturematerials (ArticleNum, IdMaterials) VALUES (@id, @matId)";
                        var matCmd = new MySqlCommand(insertMaterial);
                        matCmd.Parameters.AddWithValue("@id", selectedId);
                        matCmd.Parameters.AddWithValue("@matId", materialId);

                        if (!db.ExecuteQuery(matCmd))
                        {
                            MessageBox.Show($"Ошибка при добавлении материала ID {materialId}");
                            return;
                        }
                    }
                }
                MessageBox.Show("Данные успешно обновлены!");
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении данных мебели");
            }
        }

        private void Update_Furniture_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ArticleNumCmBx.SelectedItem != null)
            {
                int selectedId = Convert.ToInt32(ArticleNumCmBx.SelectedItem);
                int? selectedShiftNumber = ShiftNumberCmBx.SelectedItem != null ?
    Convert.ToInt32(ShiftNumberCmBx.SelectedItem) : (int?)null;


                string FurnitureNameTxBx = NameTextBox.Text;
                string CostTxBx = CostTextBox.Text;
                string ProductionTimeTxBx = ProductionTimeTextBox.Text;
                if (!string.IsNullOrEmpty(FurnitureNameTxBx) || !string.IsNullOrEmpty(CostTxBx) ||
                    !string.IsNullOrEmpty(ProductionTimeTxBx) || selectedShiftNumber < 0 )
                {
                    try
                    {
                        Console.WriteLine($"Updating: ID={selectedId}, Name={NameTextBox.Text}, " +
                 $"Cost={CostTextBox.Text}, Time={ProductionTimeTextBox.Text}, " +
                 $"Shift={ShiftNumberCmBx.SelectedItem}");
                        UpdateFurniture(selectedId, FurnitureNameTxBx, CostTxBx, ProductionTimeTxBx, selectedShiftNumber);
                        LoadFurniture();
                        ClearingTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите данные для обновления");

                }
            }
            else
            {
                MessageBox.Show("Выберите артикул для обновления.");
            }

            
        }
        private void DeletFurniture(int selectedId)
        {
            try
            {
                
                string deleteDetailsQuery = "DELETE FROM furniturematerials WHERE ArticleNum = @id";
                var cmd = new MySqlCommand(deleteDetailsQuery);
                cmd.Parameters.AddWithValue("@id", selectedId);

                if (db.ExecuteQuery(cmd))
                {
                    
                    string deleteOrderQuery = "DELETE FROM `furniture` WHERE ArticleNum = @id";
                    cmd.CommandText = deleteOrderQuery;

                    if (db.ExecuteQuery(cmd))
                    {
                        MessageBox.Show("Успешно удален");
                        LoadFurniture(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }
        private void Delet_Furniture_Button_Click(object sender, RoutedEventArgs e)
        {

            if (ArticleNumCmBx.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выполнить действие?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    int selectedId = Convert.ToInt32(ArticleNumCmBx.SelectedItem);
                    DeletFurniture(selectedId);
                    LoadFurniture();
                }
            }
            else
            {
                MessageBox.Show("Выберите ID.");
            }

        }

        private void Update_DataGrid_Furniture_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadFurniture();
        }

        private void Select_Materials_Button_Click(object sender, RoutedEventArgs e)
        {
            var materialsWindow = new MaterialsSelectionWindow(db.GetMaterials(), selectedMaterialIds);
            if (materialsWindow.ShowDialog() == true)
            {
                selectedMaterialIds = materialsWindow.SelectedMaterials.Select(m => m.Id).ToList();
                MessageBox.Show($"Выбрано материалов: {selectedMaterialIds.Count}"); // Добавьте для проверки
            }
        }
    }
}
