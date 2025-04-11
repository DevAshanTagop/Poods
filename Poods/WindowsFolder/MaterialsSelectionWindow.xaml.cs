using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Poods.WindowsFolder
{
    public partial class MaterialsSelectionWindow : Window
    {
        public List<MaterialSelection> SelectedMaterials { get; private set; } = new List<MaterialSelection>();

        public MaterialsSelectionWindow(DataTable materials, List<int> currentMaterials = null)
        {
            InitializeComponent();

            var materialList = new List<MaterialSelection>();
            foreach (DataRow row in materials.Rows)
            {
                materialList.Add(new MaterialSelection
                {
                    Id = Convert.ToInt32(row["IdMaterials"]),
                    MaterialName = row["MaterialName"].ToString(),
                    IsSelected = currentMaterials?.Contains(Convert.ToInt32(row["IdMaterials"])) ?? false
                });
            }

            MaterialsListBox.ItemsSource = materialList;
        }
        private bool _confirmed = false;
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedMaterials = ((IEnumerable<MaterialSelection>)MaterialsListBox.ItemsSource)
                .Where(m => m.IsSelected)
                .ToList();
            _confirmed = true;
            DialogResult = true;
            Close();
        }
        public bool IsConfirmed => _confirmed;
    }

    public class MaterialSelection
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public bool IsSelected { get; set; }
    }
}