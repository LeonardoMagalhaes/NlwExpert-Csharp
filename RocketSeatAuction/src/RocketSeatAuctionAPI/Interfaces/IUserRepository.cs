using RocketSeatAuctionAPI.Entities;

namespace RocketSeatAuctionAPI.Interfaces
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
