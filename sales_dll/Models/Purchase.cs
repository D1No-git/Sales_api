using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_dll.Models
{
    public class Purchase
    {
        public string? PurchaseId { get; set; }
        public string? ArticleNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedUTC { get; set; }
    }
}
