using HotelManagement.Models;

namespace HotelManagement.Interfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAll();

        Task<Payment?> GetById(int id);

        Task<int> Save(Payment payment);

        Task<int> Delete(int id);
    }
}