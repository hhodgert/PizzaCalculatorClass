using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalculator
{
    public class PizzaCalculatorService
    {
        private IPhoneDialer _dialer;

        public PizzaCalculatorService(IPhoneDialer dialer)
        {
            _dialer = dialer;
        }
        public string Calculate(string peopleString)
        {
            var people = int.Parse(peopleString);
            var pizzas = people / 3;
            var response = $"You need {pizzas} for your party.";
            return response;
        }
        public void CallPizzaParlor()
        {
            _dialer.Call("5035551212");
        }
    }

}
