using AdminLogApi.Src.Shared.Infrastructure.Security.Token.Dtos;

namespace AdminLogApi.Src.Shared.Infrastructure.Security.Token;

public interface ITokenService
{
    TokenDto Generate(string email, string name);
}
