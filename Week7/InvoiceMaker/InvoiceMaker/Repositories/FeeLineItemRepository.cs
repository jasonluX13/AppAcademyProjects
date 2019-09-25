using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class FeeLineItemRepository
    {
        private Context context;

        public FeeLineItemRepository(Context context)
        {
            this.context = context;
        }

        public void Insert(FeeLineItem feeLineItem)
        {
            context.FeeLineItems.Add(feeLineItem);
            context.SaveChanges();
        }
    }
}