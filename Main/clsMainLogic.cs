using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_3280.Main
{
    class clsMainLogic
    {
        /// <summary>
        /// SQL Object
        /// </summary>
        private clsMainSQL sql;

        /// <summary>
        /// Invoice
        /// </summary>
        private Invoice invoice;

        /// <summary>
        /// Items list
        /// </summary>
        private List<Item> items;

        /// <summary>
        /// Default constructor
        /// </summary>
        public clsMainLogic()
        {
            try
            {
                sql = new clsMainSQL();

                items = sql.GetAllItems();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        #region Properties

        /// <summary>
        /// Items list property.
        /// </summary>
        public List<Item> ItemsList
        {
            get { return items; }
            set { items = value; }
        }

        /// <summary>
        /// Current invoice property.
        /// </summary>
        public Invoice CurrentInvoice
        {
            get { return invoice; }
            set { invoice = value; }
        }

        #endregion

        #region CRUD methods
        /// <summary>
        /// Reset items list when new item is added.
        /// </summary>
        public void ResetItemsList()
        {
            try
            {
                ItemsList.Clear();
                foreach (Item item in sql.GetAllItems())
                {
                    ItemsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Resets the current invoice list
        /// </summary>
        public void ResetSelectedInvoice()
        {
            try
            {
                CurrentInvoice.Items.Clear();

                CurrentInvoice.Items = sql.GetItemsByInvoiceNum(CurrentInvoice.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Sets current invoice to new to create a new invoice. 
        /// </summary>
        public void CreateInvoice()
        {
            try
            {
                invoice = new Invoice();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes the current invoice.
        /// </summary>
        public void DeleteInvoice()
        {
            try
            {
                sql.DeleteInvoice(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes item from invoice
        /// </summary>
        /// <param name="ItemSelected"></param>
        public void DeleteItem( Item ItemSelected )
        {
            try
            {
                CurrentInvoice.Items.Remove(ItemSelected);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Save current invoice
        /// </summary>
        /// <param name="Date"></param>
        public void SaveInvoice( string Date )
        {
            int newInvoiceNumber;

            try
            {
                // give date if user doesn't specify one themselves.
                if (Date == "")
                {
                    CurrentInvoice.Date = DateTime.Now.ToString("MM/dd/yyy");
                }
                else
                {
                    CurrentInvoice.Date = Date;
                }

                if (CurrentInvoice.Number == 0) // 0 means the invoice is new
                {
                    newInvoiceNumber = sql.InsertNewInvoice(CurrentInvoice);
                    CurrentInvoice.Number = newInvoiceNumber;
                }
                else // if it's not new, update existing invoice Date and item(s).
                {
                    sql.UpdateInvoiceDate(CurrentInvoice);
                    sql.UpdateInvoiceItem(CurrentInvoice);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }

        /// <summary>
        /// Add Item(s) to the current invoice.
        /// </summary>
        /// <param name="ItemSelected">The item to add.</param>
        /// <param name="ItemQuantity">The number of ItemsSelected to add.</param>
        public void AddItem( Item ItemSelected, int ItemQuantity )
        {
            try
            {
                for (int i = 0; i < ItemQuantity; i++)
                {
                    CurrentInvoice.Items.Add(new Item(ItemSelected.Code, ItemSelected.Description, ItemSelected.Cost));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " --> " + ex.Message);
            }
        }
        #endregion
    }
}
