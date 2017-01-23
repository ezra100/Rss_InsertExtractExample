using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using UWP_Project2017.DTO;
using UWP_Project2017.DAL;

using Nest;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Project2017
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        public MainPage()
        {
            this.InitializeComponent();
            test();
        }
        private async void test()
        {
            string message = "Nothing unusual";
            try
            {
                //inserting 
                insertToES();
                //reading from db and printing to screen
                foreach (RSSChannel chan in EsCRUD.QueryAll())
                {
                    await new MessageDialog(chan.ToString()).ShowAsync();
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        //insert channel record to elastic search 
        private static void insertToES()
        {
            RSSChannel channel = new RSSChannel
            {
                Items = new List<RSSItem>(){
                        new RSSItem()
                {
                    Title = "asdf_title",
                    Description = "desc_xxx",
                    Date = new DateTime(2015, 3, 25,22,53,52)
                }
                    },
                Title = "some_channel_title",
                Description = "some_channel_description"
            };
            EsCRUD.create(channel);
        }
    }
}
