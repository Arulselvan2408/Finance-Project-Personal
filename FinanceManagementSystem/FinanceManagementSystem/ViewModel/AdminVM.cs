using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceManagementSystem.ViewModel
{
    public class AdminVM
    {
        [Key]
        public string UserName { get; set; }
        public string Name { get; set; }
        public System.DateTime DateofBirth { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string CardType { get; set; }
        public string SelectBank { get; set; }
        public string IFSC_Code { get; set; }
        public Nullable<long> AccountNumber { get; set; }

        public bool ActivationStatus { get; set; }
    }
}