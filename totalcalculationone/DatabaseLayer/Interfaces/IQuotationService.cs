using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DatabaseLayer.Components
{
    public interface IQuotationService
    {
        Response SaveQuotation(Quotation quotation, int UserId, out List<ErrorData> errors);

        Quotation GenerateQuotationNumber();

        Response UpdateQuotation(Quotation quotation, int UserId, out List<ErrorData> errors);

        Quotation GetQuotation(string QuotationNumber);

    }
}
