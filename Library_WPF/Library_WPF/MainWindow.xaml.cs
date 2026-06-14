using System;
using System.Windows;
using System.Windows.Controls;
using WpfLibrary.Models;
using WpfLibrary.Repositories;
using WpfLibrary.Services;

namespace WpfLibrary
{
    public partial class MainWindow : Window
    {
        private LibraryService service;

        public MainWindow()
        {
            InitializeComponent();
            service = new LibraryService(new LibraryRepository());
            Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            int year = int.Parse(txtYear.Text);

            if (cmbType.SelectedIndex == 0)
                service.AddBook(title, year, txtExtra.Text);
            else
                service.AddMagazine(title, year, int.Parse(txtExtra.Text));

            Refresh();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is LibraryItem item)
            {
                string title = txtTitle.Text;
                int year = int.Parse(txtYear.Text);
                string extra = txtExtra.Text;

                service.Update(item.Id, title, year, extra);

                Refresh();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is LibraryItem item)
            {
                service.Remove(item.Id);
                Refresh();
            }
        }

        private void BtnStats_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(service.GetStats());
        }

        private void Refresh()
        {
            grid.ItemsSource = null;
            grid.ItemsSource = service.GetAll();
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid.SelectedItem is LibraryItem item)
            {
                txtTitle.Text = item.Title;
                txtYear.Text = item.Year.ToString();

                if (item is Book b)
                    txtExtra.Text = b.Author;
                else if (item is Magazine m)
                    txtExtra.Text = m.Issue.ToString();
            }
        }

    }
    
}