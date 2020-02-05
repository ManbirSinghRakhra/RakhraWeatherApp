using System;
using System.Collections;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace RakhraWeatherApp.Controls
{
    public class MultiSelectToggleButtonGroup: FlexLayout
    {

		public static readonly BindableProperty ItemsSourceProperty =
	BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(MultiSelectToggleButtonGroup), default(IEnumerable), propertyChanged: ItemsSourcePropertyChanged);



		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		private static void ItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
			var multiSelectToggleButtonGroup = bindable as MultiSelectToggleButtonGroup;
			multiSelectToggleButtonGroup.populateList();

		}


		public static readonly BindableProperty SelectedItemsProperty =
BindableProperty.Create("SelectedItems", typeof(IEnumerable), typeof(MultiSelectToggleButtonGroup), new List<object>());


		public IEnumerable SelectedItems
		{
			get { return (IEnumerable)GetValue(SelectedItemsProperty); }
			set { SetValue(SelectedItemsProperty, value); }
		}

		public static readonly BindableProperty ItemTemplateProperty =
			BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(MultiSelectToggleButtonGroup), default(DataTemplate));

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}


		public MultiSelectToggleButtonGroup()
        {

        }

        public void populateList()
        {
			if (this.ItemTemplate == null || this.ItemsSource == null)
				return;

			foreach (var item in this.ItemsSource)
			{
				var viewCell = this.ItemTemplate.CreateContent() as ViewCell;
				viewCell.View.BindingContext = item;
				Children.Add(viewCell.View);
				var toggleButtonGroup = (ToggleButton)viewCell.View;
                toggleButtonGroup.Toggled += ToggleButtonGroup_Toggled;
			}
		}

        private void ToggleButtonGroup_Toggled(object sender, ToggledEventArgs e)
        {
			var bindingContext = ((ToggleButton)sender).BindingContext;

            if(e.Value)
            {
				var selectitems = SelectedItems.Cast<object>();
				var list = selectitems.ToList();
				list.Add(bindingContext);
				SelectedItems = list;
			} else
            {
				var selectitems = SelectedItems.Cast<object>();
				var list = selectitems.ToList();
				list.Remove(bindingContext);
				SelectedItems = list;
			}
		}
    }
}
