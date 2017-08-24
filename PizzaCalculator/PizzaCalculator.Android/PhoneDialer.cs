using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PizzaCalculator.Droid
{
    public class PhoneDialer : IPhoneDialer
    {
        private readonly Context _context;

        public PhoneDialer(Context context)
        {
            _context = context;
        }

        public void Call(string phoneNumber)
        {
            var uri = Android.Net.Uri.Parse($"tel:{phoneNumber}");
            var intent = new Intent(Intent.ActionDial, uri);
            _context.StartActivity(intent);
        }
    }
}