using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace UnosquareApp.Behaviors
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {

            string onlyLetters = "^[a-zA-Z]+$";
            var entry = sender as Entry;
            if (!string.IsNullOrWhiteSpace(entry.Text))
            {
                if (Regex.IsMatch(entry.Text, onlyLetters,
                     RegexOptions.IgnoreCase))
                {
                    entry.TextColor = Color.Black;
                }
                else
                    entry.TextColor = Color.Red;
            }
            else
            {
                entry.TextColor = Color.Red;
            }
        }
    }
}
