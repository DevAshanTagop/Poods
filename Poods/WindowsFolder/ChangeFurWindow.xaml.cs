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

namespace Poods.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для ChangeFurWindow.xaml
    /// </summary>
    public partial class ChangeFurWindow : Window
    {
        private readonly int _selectedId;
        DataBaseHelper db = new DataBaseHelper();
        public Dictionary<int, string> selectedFurniture2 { get; private set; } = new Dictionary<int, string>();
        public Dictionary<int, string> selectedFurniture2Materials { get; private set; } = new Dictionary<int, string>();

        private Brush defaultButtonBackground;    // Стандартный цвет кнопки
        private Brush selectedButtonBackground = Brushes.LightBlue;  // Цвет выбранной кнопки
        public ChangeFurWindow(int selectedId)
        {
            
            InitializeComponent();
            LoadFurnitureButtons(selectedId);
            _selectedId = selectedId;
        }
       
        
         
           
        
        private void LoadFurnitureButtons(int selectedId)
        {
            try
            {
                FurnitureButtonsPanel.Children.Clear();
                var db = new DataBaseHelper();

                // Загружаем данные мебели и материалы одним запросом с JOIN
                string query = @"
            SELECT f.*, 
                   GROUP_CONCAT(m.MaterialName SEPARATOR ', ') AS MaterialNames
            FROM furniture f
            LEFT JOIN furniturematerials fm ON f.ArticleNum = fm.ArticleNum
            LEFT JOIN materials m ON fm.IdMaterials = m.IdMaterials
            GROUP BY f.ArticleNum";

                DataTable furnitureData = db.GetData(query);

                string query2 = $"SELECT ArticleNum FROM orderdetails WHERE {selectedId}";
                DataTable orderArticles = db.GetData(query2);
                HashSet<int> selectedArticleNums = new HashSet<int>();
                foreach (DataRow row in orderArticles.Rows)
                {
                    selectedArticleNums.Add(Convert.ToInt32(row["ArticleNum"]));
                }

                foreach (DataRow row in furnitureData.Rows)
                {
                    var button = new Button
                    {
                        Content = CreateButtonContent(row),
                        Tag = row["ArticleNum"],
                        Margin = new Thickness(5),
                        Width = 180,
                        Height = 100
                    };

                    button.Click += FurnitureButton_Click;
                    FurnitureButtonsPanel.Children.Add(button);
                    // Проверка, чтобы выделить кнопку с выбранным ID

                    if (selectedArticleNums.Contains(Convert.ToInt32(row["ArticleNum"])))
                    {
                        FurnitureButton_Click(button, null);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мебели: {ex.Message}");
            }
        }
        private UIElement CreateButtonContent(DataRow row)
        {
            var stackPanel = new StackPanel();

            // Название мебели
            var nameText = new TextBlock
            {
                Text = row["FurnitureName"].ToString(),
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap
            };

            stackPanel.Children.Add(nameText);
            stackPanel.Children.Add(new Separator());

            // Артикул
            stackPanel.Children.Add(new TextBlock
            {
                Text = $"Артикул: {row["ArticleNum"]}"
            });

            // Цена
            stackPanel.Children.Add(new TextBlock
            {
                Text = $"Цена: {row["Cost"]} руб."
            });

            // Материалы (теперь из связанной таблицы)
            string materialsText = row["MaterialNames"] != DBNull.Value ?
                                  row["MaterialNames"].ToString() :
                                  "Материалы не указаны";

            stackPanel.Children.Add(new TextBlock
            {
                Text = $"Материалы: {materialsText}",
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap
            });

            // Номер смены
            stackPanel.Children.Add(new TextBlock
            {
                Text = $"Номер смены: {row["ShiftNumber"]}"
            });

            return stackPanel;
        }
        private void FurnitureButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int articleNum = (int)button.Tag;
            var content = (StackPanel)button.Content;
            string name = ((TextBlock)content.Children[0]).Text;

            string materialsText = "";
            foreach (var child in content.Children)
            {
                if (child is TextBlock tb && tb.Text.StartsWith("Материалы:"))
                {
                    materialsText = tb.Text.Replace("Материалы: ", "");
                    break;
                }
            }

            if (selectedFurniture2.ContainsKey(articleNum))
            {
                selectedFurniture2.Remove(articleNum);
                selectedFurniture2Materials.Remove(articleNum);
                button.Background = defaultButtonBackground;
            }
            else
            {
                selectedFurniture2[articleNum] = name;
                selectedFurniture2Materials[articleNum] = materialsText;
                button.Background = selectedButtonBackground;
            }

            UpdateSelectionInfo();
        }
        private bool _confirmed = false;
        private void UpdateSelectionInfo()
        {
            SelectedCountText.Text = $"Выбрано: {selectedFurniture2.Count}";
            
        }
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Поиск мебели...")
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = Brushes.Black;
            }
        }
        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Поиск мебели...";
                SearchTextBox.Foreground = Brushes.Gray;
            }
        }
        private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            // Игнорируем если отображается placeholder
            if (SearchTextBox.Text == "Поиск мебели..." && SearchTextBox.Foreground == Brushes.Gray)
                return;

            string searchText = SearchTextBox.Text.ToLower();

            // Фильтруем кнопки по введенному тексту
            foreach (Button button in FurnitureButtonsPanel.Children)
            {
                var content = (StackPanel)button.Content;
                var nameText = (TextBlock)content.Children[0];
                button.Visibility = nameText.Text.ToLower().Contains(searchText)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем текущий выбор перед обновлением
            var currentSelection = new Dictionary<int, string>(selectedFurniture2);
            selectedFurniture2.Clear();

            // Перезагружаем кнопки
            LoadFurnitureButtons(_selectedId);

            // Восстанавливаем выбор после обновления
            foreach (var item in currentSelection)
            {
                foreach (Button button in FurnitureButtonsPanel.Children)
                {
                    if ((int)button.Tag == item.Key)
                    {
                        selectedFurniture2[item.Key] = item.Value;
                        button.Background = selectedButtonBackground;
                        break;
                    }
                }
            }

            UpdateSelectionInfo();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _confirmed = true;
            this.Close();

        }
        public bool IsConfirmed => _confirmed;
    }
}
