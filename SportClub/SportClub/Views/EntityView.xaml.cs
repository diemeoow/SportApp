using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SportClub.Views
{
    public partial class EntityView : UserControl
    {
        public EntityView()
        {
            InitializeComponent();
            this.Loaded += EntityView_Loaded;
        }

        private void EntityView_Loaded(object sender, RoutedEventArgs e)
        {
            if (PART_DataGrid.Columns.Count > 0) return;

            var items = PART_DataGrid.ItemsSource as System.Collections.IEnumerable;
            var firstItem = items?.Cast<object>().FirstOrDefault();
            if (firstItem == null) return;

            var props = firstItem.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var column = new DataGridTextColumn
                {
                    Header = prop.Name,
                    Binding = new Binding(prop.Name)
                };
                PART_DataGrid.Columns.Add(column);
            }
        }
    }
}
