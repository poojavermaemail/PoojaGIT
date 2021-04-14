using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {
           // double totaladdedamount = 0.0;
            Console.WriteLine("Select the product you want");
            Console.WriteLine("Select 1 for COLA Select 2 for Chips Select 3 for Candy");
            int selecteditem=Convert.ToInt16(Console.ReadLine());
            items_VM objitems = new items_VM();
            //Item class
           double getproductvalue= objitems.productdetails(selecteditem);
           //Vending machine class
            VendingMc objVM = new VendingMc();
            double totalamount = objVM.Entercoins();
            //Calculator class
             calculator objcal = new calculator();
            if (totalamount >= getproductvalue)
            {
                objcal.recordpayment(getproductvalue, totalamount);
                Console.WriteLine("THANK YOU !");
                objVM.totaladdedamount = 0.0;
            }
            else
            {
                Console.WriteLine("Value of product selected is "+getproductvalue);
                Console.WriteLine("Insufficient amount for product");
            }

        }
    }
    class items_VM
    {
        public double productdetails(int productcode)
        {
            double productvalue=0.0;
            switch(productcode)
            {
                case (1):
                     productvalue= 1.0;
                    break;

                case (2):
                    productvalue= 0.50;
                    break;

                case (3):
                    productvalue= 0.65;
                    break;
            }
            return productvalue;
        }

    }
    class calculator
    {
         public double recordpayment(double itemprice,double totalamountinVM)
        {

            double totalbill = 0;         
            totalbill = totalamountinVM - itemprice;
            return totalbill;
        }
    }
}
 class VendingMc
{
   public  double amountdeposited =0 , totaladdedamount=0;
     double getcoins(double coinvalue)
    {
        if(coinvalue==0.25 || coinvalue ==0.050 || coinvalue==0.01)
        {
            amountdeposited = amountdeposited + coinvalue;
        }
        else
        {
            Console.WriteLine("Incorrect coin value");
        }
        return amountdeposited;
    }

  public double  Entercoins()
    {
        char userselection = 'N';
        do
        {
            double coinamount = 0.0;
            Console.WriteLine("Insert amount to get the product");
            coinamount = Convert.ToDouble(Console.ReadLine());
            totaladdedamount = getcoins(coinamount);
            Console.WriteLine("Enter Y to add more amount ,else press any key to exit");
            userselection = Convert.ToChar(Console.ReadLine());
        } while (userselection == 'y' || userselection == 'Y');
        return totaladdedamount;
    }

}

