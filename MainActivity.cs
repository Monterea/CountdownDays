using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.TextField;
using System;

namespace CountdownDays
{
    [Activity(Label = "CountdownDays", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {
        TextView textViewDays;
        TextView textViewDescription;
        RadioButton rbHalloween;
        RadioButton rbKidsDay;
        RadioButton rbChristmas;
        RadioButton rbOther;
        TextInputEditText textInputCustomDate;
        Button buttonCountDays;
        RadioButton rbDanielBirthday;
        RadioButton rbDanielNameDay;
        RadioButton rbMatejBirthday;
        RadioButton rbMatejNameDay;
        RadioButton rbJiriBirthday;
        RadioButton rbJiriNameDay;
        DateTime today = DateTime.Today;
        DateTime endDate;
        TimeSpan daysToEvent;
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetupReferences();
            SubscribeEvenHandlers();
        }
        private void SetupReferences() {
            textViewDays = FindViewById<TextView>(Resource.Id.textViewDays);
            textViewDescription = FindViewById<TextView>(Resource.Id.textViewDescription);
            rbHalloween = FindViewById<RadioButton>(Resource.Id.radioButtonHalloween);
            rbKidsDay = FindViewById<RadioButton>(Resource.Id.radioButtonKidsDay);
            rbChristmas = FindViewById<RadioButton>(Resource.Id.radioButtonChristmas);
            rbOther = FindViewById<RadioButton>(Resource.Id.radioButtonOther);
            textInputCustomDate = FindViewById<TextInputEditText>(Resource.Id.textInputCustomDate);
            buttonCountDays = FindViewById<Button>(Resource.Id.buttonCountDays);
            rbDanielBirthday = FindViewById<RadioButton>(Resource.Id.radioButtonDanielBirthday);
            rbDanielNameDay = FindViewById<RadioButton>(Resource.Id.radioButtonDanielNameDay);
            rbMatejBirthday = FindViewById<RadioButton>(Resource.Id.radioButtonMatejBirthday);
            rbMatejNameDay = FindViewById<RadioButton>(Resource.Id.radioButtonMatejNameDay);
            rbJiriBirthday = FindViewById<RadioButton>(Resource.Id.radioButtonJiriBirthday);
            rbJiriNameDay = FindViewById<RadioButton>(Resource.Id.radioButtonJiriNameDay);
        }
        private void SubscribeEvenHandlers() {
            rbHalloween.CheckedChange += RbHalloween_CheckedChange;
            rbKidsDay.CheckedChange += RbKidsDay_CheckedChange;
            rbChristmas.CheckedChange += RbChristmas_CheckedChange;
            buttonCountDays.Click += ButtonCountDays_Click;
            rbDanielBirthday.Click += RbDanielBirthday_Click;
            rbDanielNameDay.Click += RbDanielNameDay_Click;
            rbMatejBirthday.Click += RbMatejBirthday_Click;
            rbMatejNameDay.Click += RbMatejNameDay_Click;
            rbJiriBirthday.Click += RbJiriBirthday_Click;
            rbJiriNameDay.Click += RbJiriNameDay_Click;
            textInputCustomDate.Click += TextInputCustomDate_Click;
        }
        private void TextInputCustomDate_Click(object sender, EventArgs e) {
            rbOther.Checked = true;
        }
        private void RbJiriNameDay_Click(object sender, EventArgs e) {
            if (rbJiriNameDay.Checked) {
                CountEndDate(24, 4, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Jiri's NameDay");
            }
        }
        private void RbJiriBirthday_Click(object sender, EventArgs e) {
            if (rbJiriBirthday.Checked) {
                CountEndDate(5, 2, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Jiri's Birthday");
            }
        }
        private void RbMatejNameDay_Click(object sender, EventArgs e) {
            if (rbMatejNameDay.Checked) {
                CountEndDate(24, 2, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Matej's NameDay");
            }
        }
        private void RbMatejBirthday_Click(object sender, EventArgs e) {
            if (rbMatejBirthday.Checked) {
                CountEndDate(8, 9, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Matej's Birthday");
            }
        }
        private void RbDanielNameDay_Click(object sender, EventArgs e) {
            if (rbDanielNameDay.Checked) {
                CountEndDate(17, 12, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Daniel's NameDay");
            }
        }
        private void RbDanielBirthday_Click(object sender, EventArgs e) {
            if (rbDanielBirthday.Checked) {
                CountEndDate(25, 8, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Daniel's Birthday");
            }
        }
        private void ButtonCountDays_Click(object sender, EventArgs e) {
            string[] datum = textInputCustomDate.Text.Split('.');
            int day = Convert.ToInt32(datum[0]);
            int month = Convert.ToInt32(datum[1]);
            int year = Convert.ToInt32(datum[2]);
            endDate = new DateTime(year, month, day);
            CountTimeSpan();
            ViewTheCountOfDays("my event");
        }
        private void RbHalloween_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbHalloween.Checked) {
                CountEndDate(31, 10, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Halloween");
            }
        }
        private void RbKidsDay_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbKidsDay.Checked) {
                CountEndDate(1, 6, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Summer");
            }
        }
        private void RbChristmas_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            if (rbChristmas.Checked) {
                CountEndDate(24, 12, today.Year);
                CountTimeSpan();
                ViewTheCountOfDays("Christmas");
            }
        }   
        private void CountEndDate(int day, int month, int year) {
            endDate = new DateTime(year, month, day);
            if (today.DayOfYear > endDate.DayOfYear) {                                               
                endDate = endDate.AddYears(1);
            }
        }
       private void CountTimeSpan() {
            TimeSpan daysToEvent = endDate - today;
        }
       private void ViewTheCountOfDays(string eventToDisplay) {
            textViewDays.Text = daysToEvent.Days.ToString();
            textViewDescription.Text = $"days until {eventToDisplay}";
        }
    }
}