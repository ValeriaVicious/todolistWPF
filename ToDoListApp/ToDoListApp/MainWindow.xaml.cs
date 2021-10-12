using System;
using System.ComponentModel;
using System.Windows;
using ToDoListApp.Models;
using ToDoListApp.Services;


namespace ToDoListApp
{
    public partial class MainWindow : Window
    {
        #region Fields

        private BindingList<ToDoModel> _toDoDataList;
        private FileIoServices _fileIoServices;
        private readonly string _path = $"{Environment.CurrentDirectory}\\todoDataList.json";

        #endregion


        #region Methods

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIoServices = new FileIoServices(_path);

            try
            {
                _toDoDataList = _fileIoServices.LoadData();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }

            DataGridToDoList.ItemsSource = _toDoDataList;
            _toDoDataList.ListChanged += ToDoDataList_ListChanged;
        }

        private void ToDoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (e.ListChangedType == ListChangedType.ItemDeleted ||
                    e.ListChangedType == ListChangedType.ItemAdded ||
                    e.ListChangedType == ListChangedType.ItemChanged)
                {
                    _fileIoServices.SaveData(sender);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Close();
            }
        }

        #endregion
    }
}
