using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBIX_WEBAPI.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int ClientId { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public int InvoiceAmount { get; set; }
    }
}