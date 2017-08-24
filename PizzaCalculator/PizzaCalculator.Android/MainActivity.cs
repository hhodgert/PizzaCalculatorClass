using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PizzaCalculator.Droid
{
	[Activity (Label = "PizzaCalculator.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            System.AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                System.Console.WriteLine($"unhandled exception {sender}");
            };

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var peopleEntry = FindViewById<EditText>(Resource.Id.peopleEntry);
            var calculate = FindViewById<Button>(Resource.Id.calculateButton);
            var pizzaCount = FindViewById<TextView>(Resource.Id.pizzaCountLabel);
            var callButton = FindViewById<Button>(Resource.Id.callButton);
            var phoneDialer = new PhoneDialer(this);
            var pizzaCalculatorService = new PizzaCalculatorService(phoneDialer);

            calculate.Click += delegate 
            {
                 pizzaCount.Text = pizzaCalculatorService.Calculate(peopleEntry.Text);
            };
            callButton.Click += delegate
            {
                pizzaCalculatorService.CallPizzaParlor();
            };


		}
	}
}


