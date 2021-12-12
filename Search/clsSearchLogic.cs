using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// SQL Object
        /// </summary>
        private clsSearchSQL sSQL;

        /// <summary>
        /// Invoice
        /// </summary>
        public Invoice invoice;

        /// <summary>
        /// Items list
        /// </summary>
        private List<Invoice> invoices;

        /// <summary>
        /// Items list
        /// </summary>
        private List<Invoice> selectInvoices;

        /// <summary>
        /// invoice sent to main
        /// </summary>
        public List<Invoice> selectInvoice;

      /*  /// <summary>
        /// invoice sent to main
        /// </summary>
       // public List<Invoice> selectedInvoice;*/

        /// <summary>
        /// Default constructor
        /// </summary>
        public clsSearchLogic()
        {
            try
            {
                sSQL = new clsSearchSQL();
                invoices = sSQL.GetAllInvoices();
            }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
                }
            }

        /// <summary>
        /// Items list property.
        /// </summary>
        public List<Invoice> InvoiceList
        {
            get { return invoices; }
            set { invoices = value; }
        }
        public List<Invoice> SelInvoiceList
        {
            get { return selectInvoices; }
            set { selectInvoices = value; }
        }

        public List<Invoice> SelectedInvoice
        {
            get { return selectInvoice; }
            set { selectInvoice = value; }
        }


        public void Search(string Invoice_Number_DropBx, string Invoice_Date_DropBx, string Total_Charges_DropBx)
        {
            try
            {
                sSQL = new clsSearchSQL();
                selectInvoices = sSQL.GetSelectedIvoices(Invoice_Number_DropBx, Invoice_Date_DropBx, Total_Charges_DropBx);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

            public Invoice sendInv(object inv)
        {
            invoice = (Invoice)inv;
            return invoice;
            
        }

    }
}
