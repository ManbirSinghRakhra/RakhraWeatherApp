using System;
using Xamarin.Forms;

namespace RakhraWeatherApp.Controls
{
    class ToggleButton : Button
    {
        public event EventHandler<ToggledEventArgs> Toggled;

        public static BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(ToggleButton), false,
                                    propertyChanged: OnIsToggledChanged, defaultBindingMode: BindingMode.TwoWay);

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }

        public static BindableProperty IsActiveProperty =
    BindableProperty.Create("IsActive", typeof(bool), typeof(ToggleButton), true,
                            propertyChanged: OnIsActiveChanged, defaultBindingMode: BindingMode.TwoWay);

        private static void OnIsActiveChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton toggleButton = (ToggleButton)bindable;
            var isActive = (bool)newValue;
            CheckButtonViewState(toggleButton, toggleButton.IsToggled, isActive);
        }

        public bool IsActive
        {
            set { SetValue(IsActiveProperty, value); }
            get { return (bool)GetValue(IsActiveProperty); }
        }

        public ToggleButton()
        {
            Clicked += (sender, args) => IsToggled ^= true;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            CheckButtonViewState(this, IsToggled, IsActive);
        }

        static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
           
            ToggleButton toggleButton = (ToggleButton)bindable;

            if(!toggleButton.IsActive)
            {
                return;
            }

            bool isToggled = (bool)newValue;

            // Fire event
            toggleButton.Toggled?.Invoke(toggleButton, new ToggledEventArgs(isToggled));

            // Set the visual state
            CheckButtonViewState(toggleButton, isToggled, toggleButton.IsActive);
        }

        private static void CheckButtonViewState(ToggleButton toggleButton, bool isToggled, bool isActive)
        {
            if(!isActive)
            {
                VisualStateManager.GoToState(toggleButton, "InActive");
                return;
            }
            VisualStateManager.GoToState(toggleButton, isToggled ? "ToggledOn" : "ToggledOff");
        }
    }
}
