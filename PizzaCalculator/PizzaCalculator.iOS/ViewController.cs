using System;

using UIKit;

namespace PizzaCalculator.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            var dialer = new PhoneDialer(this);
            var pizzaCalculatorService = new PizzaCalculatorService(dialer);
            // Perform any additional setup after loading the view, typically from a nib.
            CalculateButton.TouchUpInside += delegate
            {
                PizzaCountLabel.Text = pizzaCalculatorService.Calculate(PeopleEntry.Text);
                PeopleEntry.ResignFirstResponder();
            };
            CallButton.TouchUpInside += delegate
            {
                pizzaCalculatorService.CallPizzaParlor();
            };

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

