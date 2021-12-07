using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280
{
    /// <summary>
    /// Item Class for item from invoice.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Char for the code
        /// </summary>
        private char code;

        /// <summary>
        /// Description string
        /// </summary>
        private string description;

        /// <summary>
        /// Item cost
        /// </summary>
        private double cost;
        
        /// <summary>
        /// Item constructor for the code, description and cost.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="ItemDescription"></param>
        /// <param name="ItemCost"></param>
        public Item( char ItemCode, string ItemDescription, double ItemCost )
        {
            code = ItemCode;
            description = ItemDescription;
            cost = ItemCost;
        }

        /// <summary>
        /// Cost property
        /// </summary>
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        /// <summary>
        /// Description property
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        /// <summary>
        /// Code property
        /// </summary>
        public char Code
        {
            get { return code; }
            set { code = value; }
        }
     
    }
}
