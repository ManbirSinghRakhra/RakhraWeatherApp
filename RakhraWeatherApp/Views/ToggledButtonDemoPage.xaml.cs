using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RakhraWeatherApp.Views
{
    public partial class ToggledButtonDemoPage : ContentPage
    {
        public ToggledButtonDemoPage()
        {
            InitializeComponent();


            var listgroup = new List<ButtonItem>();
            listgroup.Add(new ButtonItem
            {
                CanSelect = false,
                IsToggled = false,
                Text = "Unit 01"
            });
            listgroup.Add(new ButtonItem
            {
                CanSelect = false,
                IsToggled = false,
                Text = "Unit 02"
            });
            listgroup.Add(new ButtonItem
            {
                CanSelect = false,
                IsToggled = false,
                Text = "Unit 03"
            });
            listgroup.Add(new ButtonItem
            {
                CanSelect = true,
                IsToggled = false,
                Text = "Unit 04"
            });
            listgroup.Add(new ButtonItem
            {
                CanSelect = true,
                IsToggled = false,
                Text = "Unit 05"
            });
            multiSelectToggleButtonGroup.ItemsSource = listgroup;
        }

        void OnItalicButtonToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }
        }

        void OnBoldButtonToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }
        }
    }

    internal class ButtonItem
    {
        public bool CanSelect { get; set; }
        public bool IsToggled { get; set; }
        public string Text { get; set; }
    }
}
