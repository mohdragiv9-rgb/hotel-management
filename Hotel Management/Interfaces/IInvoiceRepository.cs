using HotelManagement.Models;

public interface IInvoiceRepository
{
    Task<InvoiceViewModel> GetInvoice(int checkOutId);
}