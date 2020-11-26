using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinanceManagementSystem.ViewModel
{
    public class RecentTransaction
    {
        [Key]
        public int OrderID { get; set; }//OrderDetails.cs
        public string ProductName { get; set; }//Product.cs
        public System.DateTime OrderDate { get; set; }//Order.cs
        public double AmountPayable { get; set; }//Order.cs
    }
}