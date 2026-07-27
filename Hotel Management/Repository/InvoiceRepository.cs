using Dapper;
using HotelManagement.Data;
using HotelManagement.Models;
using System.Data;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly DapperContext _context;

    public InvoiceRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<InvoiceViewModel> GetInvoice(int checkOutId)
    {
        using var con = _context.CreateConnection();

        return await con.QueryFirstOrDefaultAsync<InvoiceViewModel>(
            "USP_Invoice",
            new
            {
                CheckOutId = checkOutId
            },
            commandType: CommandType.StoredProcedure);
    }
}