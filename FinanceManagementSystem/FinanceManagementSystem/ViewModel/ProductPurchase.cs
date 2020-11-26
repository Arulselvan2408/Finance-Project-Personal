using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagementSystem.ViewModel
{
    public class ProductPurchase
    {
        [Key]
        public int OrderID { get; set; }//OrderDetails.cs
        public string ProductName { get; set; }//Product.cs
        public int CostPerUnit { get; set; }//Product.cs
        public double AmountPayable { get; set; }//Order.cs
        public double Balance { get; set; }
    }
}