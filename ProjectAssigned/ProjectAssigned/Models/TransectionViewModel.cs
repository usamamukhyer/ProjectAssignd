using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAssigned.Models
{
    public class TransectionViewModel
    {
        public int TransecId { get; set; }
        public string CashType { get; set; }
        public string Date { get; set; }
        public string Discription { get; set; }
        public string IncomeCollectFrom { get; set; }
        public string IncomeSpentTo { get; set; }
        public string Amount { get; set; }
    }
}