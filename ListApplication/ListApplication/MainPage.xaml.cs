using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ListApplication.Models;
using Windows.Media.SpeechSynthesis;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<People> Peoples;

        public MainPage()
        {
            this.InitializeComponent();
            Peoples = PeopleManager.GetPeople();
            ListView_Sort();
        }


        public void SortByLocation()
        {
            this.Refresh();
            Peoples.Sort((x, y) => x.Locale.LocationName.CompareTo(y.Locale.LocationName));
        }

        public void ListView_Sort()
        {
            Peoples.Sort((x, y) => x.LastName.CompareTo(y.LastName));
        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedPerson = (People)e.ClickedItem;

            DetailNameTextBlock.Text = selectedPerson.Name;
            DetailAgeTextBlock.Text = selectedPerson.Age.ToString();
            DetailColourTextBlock.Text = selectedPerson.FavouriteColor;
            DetailRelationshipTextBlock.Text = selectedPerson.Relationship;
            DetailSexTextBox.Text = selectedPerson.Sex;
            DetailLocaltionTextBlock.Text = selectedPerson.Locale.LocationName;

            LabelAge.Visibility = Visibility.Visible;
            LabelColour.Visibility = Visibility.Visible;
            LabelLocale.Visibility = Visibility.Visible;
            LabelRel.Visibility = Visibility.Visible;
            LabelSex.Visibility = Visibility.Visible;

        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var storageFile =
                await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///ListifyCommands.xml"));
            await Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager
                .InstallCommandDefinitionsFromStorageFileAsync(storageFile);
        }

        public void Refresh()
        {
            Peoples = PeopleManager.GetPeople();
        }

        public async void CountTheAmount(string itemToCount)
        {
            int count = 0;
            if (itemToCount == "Male")
            {
                count = Peoples.Count(x => x.Sex == "Male");
            }
            else if(itemToCount == "Female")
            {
                count = Peoples.Count(x => x.Sex == "Female");
            }

            MediaElement media = new MediaElement();

            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("There are " + count + " " + itemToCount);

            media.SetSource(stream, stream.ContentType);
            media.Play();
        }

        public void OmniSort(string itemToSort)
        {
            this.Refresh();
            switch (itemToSort)
            {
                case "Age":
                    Peoples.Sort((x, y) => x.Age.CompareTo(y.Age));
                    break;
                case "Sex":
                    Peoples.Sort((x, y) => x.Sex.CompareTo(y.Sex));
                    break;
                case "FavouriteColor":
                    Peoples.Sort((x, y) => x.FavouriteColor.CompareTo(y.FavouriteColor));
                    break;
                case "LastName":
                    Peoples.Sort((x, y) => x.LastName.CompareTo(y.LastName));
                    break;
                case "FirstName":
                    Peoples.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
                    break;
            }
        }

        public async void HowMany(string itemToCount)
        {
            int count = 0;
            switch (itemToCount)
            {
                case "Blenheim":
                    count = Peoples.Count(x => x.Locale == Locations.Blenheim);
                    break;
                case "Toronto":
                    count = Peoples.Count(x => x.Locale == Locations.Toronto);
                    break;
                case "Windsor":
                    count = Peoples.Count(x => x.Locale == Locations.Windsor);
                    break;
                case "London":
                    count = Peoples.Count(x => x.Locale == Locations.London);
                    break;
                case "Caledonia":
                    count = Peoples.Count(x => x.Locale == Locations.Caledonia);
                    break;
                case "Chatham":
                    count = Peoples.Count(x => x.Locale == Locations.Chatham);
                    break;
                case "Welland":
                    count = Peoples.Count(x => x.Locale == Locations.Welland);
                    break;
            }
            MediaElement media = new MediaElement();

            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(count + " people live in " +itemToCount);

            media.SetSource(stream, stream.ContentType);
            media.Play();
        }

        public async void BestFriend()
        {
            //var bestFriend = PeopleManager.GetPeople().Where(x => x.Relationship == "Best Friend");
            
            MediaElement media = new MediaElement();

            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

            SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Your best friend is Jesse Wheeler." /*+ bestFriend.ToString()*/);

            media.SetSource(stream, stream.ContentType);
            media.Play();
        }
    }
}
