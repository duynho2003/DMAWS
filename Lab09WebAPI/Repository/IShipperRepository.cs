using Lab09Lib;

namespace Lab09WebAPI.Repository
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetShippers();
        Task<bool> PostShipper(Shipper shipper);
        Task<bool> DeleteShipper(int id);
    }
}
