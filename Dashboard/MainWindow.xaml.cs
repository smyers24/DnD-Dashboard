using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Dragablz;

namespace Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void openListOfThings(object sender, RoutedEventArgs e)
        {
            openedItemsListBox.Items.Clear();
            string[] files = Array.Empty<string>();
            OpenFileDialog fileDialog = new OpenFileDialog();
            
            //  var fullFilePath = fileDialog.FileName;
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = File.ReadAllLines(fileDialog.FileName);
            }
            foreach (string file in files)
            {
                openedItemsListBox.Items.Add(file);
                openFile(file);
            }
        }

        private void openFile(string fileName)
        {
            Process fileopener = new Process();
            try
            {
                fileopener.StartInfo.FileName = fileName;
                fileopener.Start();
                fileopener.Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Invalid file selection: " + fileName);
            }
        }

        private void reopenItemFromList(object sender, RoutedEventArgs e)
        {
            if (openedItemsListBox.SelectedItem != null)
            {
                openFile(openedItemsListBox.SelectedItem.ToString());
                openedItemsListBox.UnselectAll();
            }
        }
/*
        public INewTabHost GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            var view = new MyWindow();
            return new NewTabHost(view, view.TabablzControl); //TabablzControl is a names control in the XAML
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindow;
        }
        */
    }
}
