using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RentInterface.Entities
{
    internal class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }




        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public Invoice()
        {
        }

        public double totalPayment
        {
            get
            {
                return BasicPayment + Tax;
            }
        }

        public override string ToString()
        {
            return "INVOICE"
                + "Basic payment: "
                + BasicPayment.ToString(CultureInfo.InvariantCulture)
                + "\nTax: "
                + Tax                
                + "\nTotal Payment: "
                + totalPayment.ToString(CultureInfo.InvariantCulture);
        }
    }
}
