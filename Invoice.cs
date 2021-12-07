using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280
{
    /// <summary>
    /// Invoice Class
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Invoice date
        /// </summary>
        private string date;

        /// <summary>
        /// Invoice Number
        /// </summary>
        private int num;        

        /// <summary>
        /// Invoice Total
        /// </summary>
        private double total;

        /// <summary>
        /// List representing Items associated with an Invoice
        /// </summary>        
        private List<Item> items;

        /// <summary>
        /// Blank invoice to initiate.
        /// </summary>
        public Invoice()
        {
            items = new List<Item>();
        }

        /// <summary>
        /// Invoice constructor.
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="InvoiceDate"></param>
        /// <param name="InvoiceTotalCost"></param>
        public Invoice( int InvoiceNum, string InvoiceDate, double InvoiceTotalCost )
        {
            num = InvoiceNum;
            date = InvoiceDate;
            total = InvoiceTotalCost;
            items = new List<Item>();
        }

        /// <summary>
        /// Date property.
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// Number property.
        /// </summary>
        public int Number
        {
            get { return num; }
            set { num = value; }
        }        

        /// <summary>
        /// Total property.
        /// </summary>
        public double Total
        {
            get
            {
                double dTotal = 0;
                foreach (Item item in items)
                {
                    dTotal += item.Cost;
                    total = dTotal;
                }
                return total;
            }
            set
            {
                double dTotal = 0;
                foreach (Item item in items)
                {
                    dTotal += item.Cost;
                    total = dTotal;
                }

            }

        }

        /// <summary>
        /// Items property.
        /// </summary>
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }        
    }
}
