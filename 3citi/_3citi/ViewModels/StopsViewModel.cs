using System;
using System.Diagnostics;
using System.Threading.Tasks;

using _3citi.Helpers;
using _3citi.Models;
using _3citi.Views;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace _3citi.ViewModels
{
    public class StopsViewModel : BaseViewModel
    {
        public ObservableCollection<Stop> StopsCollection { get; set; }
        public ObservableCollection<Stop> StopsBackupCollection { get; set; }
        public Command LoadItemsCommand { get; set; }
        public List<Stop> ToSort { get; set; }

        public StopsViewModel()
        {
            Title = "Przystanki";
            StopsCollection = new ObservableCollection<Stop>();
            StopsBackupCollection = new ObservableCollection<Stop>();
            ToSort = new List<Stop>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }
        public void SearchCommandExecute(string SearchedText)
        {
            var Backup = StopsBackupCollection;
            var tempRecords = Backup.Where(c => c.StopDesc.IndexOf(SearchedText, StringComparison.OrdinalIgnoreCase) >= 0);
            StopsCollection.Clear();
            foreach (var item in tempRecords)
            {
                StopsCollection.Add(item);
            }
            if (StopsCollection.Count == 0)
            {
                foreach (var item in Backup)
                {
                    StopsCollection.Add(item);
                }
            }
        }
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                StopsCollection.Clear();
                var stops = await StopDataStore.GetItemsAsync(true);
                foreach (Stop stop in stops)
                {
                    ToSort.Add(stop);
                }
                ToSort.Sort((x, y) => x.StopDesc.CompareTo(y.StopDesc));
                foreach (Stop stop in ToSort)
                {
                    StopsCollection.Add(stop);
                }
                StopsBackupCollection.Clear();
                foreach (Stop item in StopsCollection)
                {
                    StopsBackupCollection.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}