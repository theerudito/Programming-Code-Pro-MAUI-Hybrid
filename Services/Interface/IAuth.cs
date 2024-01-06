using ProgrammingCodePro.Models;

namespace ProgrammingCodePro.Service.Interface
{
    public interface IAuth
    {
        Task<bool> RegisterAuth(AuthDto userDto);
        Task<bool> LoginAuth(AuthDto idUserDto);
    }
}
