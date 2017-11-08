using System;
using Xamarin.Forms;

namespace XAM320
{
    public class PersonPage : ContentPage
    {
        readonly Button _blankPageButton;
        readonly PersonViewModel _viewModel = new PersonViewModel();

        public PersonPage()
        {
            BindingContext = _viewModel;

            var firstNameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "First Name"
            };
            firstNameEntry.SetBinding(Entry.TextProperty, nameof(_viewModel.FirstName));

            var lastNameEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Placeholder = "Last Name"
            };
            lastNameEntry.SetBinding(Entry.TextProperty, nameof(_viewModel.LastName));

            var defaultNameButton = new Button
            {
                Text = "Default Name",
                CommandParameter = "Jane"
            };
            defaultNameButton.SetBinding(Button.CommandProperty, nameof(_viewModel.DefaultNameButtonCommand));

            _blankPageButton = new Button
            {
                Text = "Load Blank Page"
            };

            var firstNameCharacterCountLabel = new Label();
            firstNameCharacterCountLabel.SetBinding(Label.TextProperty, nameof(_viewModel.FirstNameCharacterCount));

            var stacklayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    firstNameEntry,
                    lastNameEntry,
                    defaultNameButton,
                    firstNameCharacterCountLabel,
                    _blankPageButton
                }
            };

            Content = stacklayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _blankPageButton.Clicked += HandleBlankPageButtonClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _blankPageButton.Clicked -= HandleBlankPageButtonClicked;
        }

        void HandleBlankPageButtonClicked(object sender, EventArgs e)
        {
            _viewModel.DoSomethingCommand?.Execute(null);

            Device.BeginInvokeOnMainThread(async () => await Navigation.PushAsync(new BlankPage()));
        }
    }
}
