using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WU15.DesignPatterns.Facade.Core.MortgageEligibility
{
    public class Mortgage
    {
        private readonly Bank bank = new Bank();
        private readonly Loan loan = new Loan();
        private readonly Credit credit = new Credit();

        public bool IsEligible(Customer customer,double amount)
        {
            Console.WriteLine("{0}{1} is applyng for a {2:c} loan",
                customer.FirstName,
                customer.LastName,
                amount);

            var isEligible = true;

            if (!bank.HasSufficentSavings(customer, amount))
            {
                isEligible = false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                isEligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                isEligible = false;
            }

            return isEligible;
        }
    }
}
