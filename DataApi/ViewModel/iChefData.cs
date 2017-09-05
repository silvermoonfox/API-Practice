using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace DataApi.ViewModel
{

    //public class Item
    //{
    //    public string category_id { get; set; }
    //    public string category_name { get; set; }
    //    public object external_id { get; set; }
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public double ordered_time { get; set; }
    //    public int original_price { get; set; }
    //    public int quantity { get; set; }
    //    public int sales_price { get; set; }
    //    public object setting_external_id { get; set; }
    //    public List<object> tags { get; set; }

    //}

    //public class OrderItems
    //{
    //    public List<object> combos { get; set; }
    //    public List<Item> items { get; set; }
    //}

    //public class Payment
    //{
    //    public object cash_change { get; set; }
    //    public string credit_card_last_four_digits { get; set; }
    //    public object credit_card_type { get; set; }
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public object note { get; set; }
    //    public string type { get; set; }
    //}

    //public class Invoice
    //{
    //    public object buyer_tax_info_company_address { get; set; }
    //    public object buyer_tax_info_company_name { get; set; }
    //    public object buyer_tax_info_customer_address { get; set; }
    //    public object buyer_tax_info_customer_name { get; set; }
    //    public string buyer_tax_info_tax_id { get; set; }
    //    public int customer_count { get; set; }
    //    public List<object> discounts { get; set; }
    //    public object invoice_cancelled_date { get; set; }
    //    public double invoice_issued_date { get; set; }
    //    public string invoice_number { get; set; }
    //    public string invoice_status { get; set; }
    //    public OrderItems order_items { get; set; }
    //    public List<Payment> payments { get; set; }
    //    public int rounding { get; set; }
    //    public int sales_amount_exclude_tax { get; set; }
    //    public int sales_amount_include_tax { get; set; }
    //    public string serve_type { get; set; }
    //    public int service_charge { get; set; }
    //    public int tax_amount { get; set; }
    //    public double tax_rate { get; set; }
    //}

    //public class Paging
    //{
    //    public int limit { get; set; }
    //    public int page_index { get; set; }
    //    public int total_count { get; set; }
    //}

    //public class iChefData
    //{
    //    public List<Invoice> invoices { get; set; }
    //    public Paging paging { get; set; }
    //    public string store_id { get; set; }
    //}
    public class Invoice
    {
        public object buyer_tax_info_company_address { get; set; }
        public object buyer_tax_info_company_name { get; set; }
        public object buyer_tax_info_customer_address { get; set; }
        public object buyer_tax_info_customer_name { get; set; }
        public string buyer_tax_info_tax_id { get; set; }
        public int customer_count { get; set; }
        public List<object> discounts { get; set; } 
        public object invoice_cancelled_date { get; set; }
        public double invoice_issued_date { get; set; }
        public string invoice_number { get; set; }
        public string invoice_status { get; set; }
    }

    public class Paging
    {
        public int limit { get; set; }
        public int page_index { get; set; }
        public int total_count { get; set; }
    }

    public class iChefData
    {
        //public List<Invoice> invoice { get; set; } = new List<Invoice>();
        public List<Invoice> invoice { get; set; } 
        public Paging paging { get; set; }
        public string store_id { get; set; }
    }

}
