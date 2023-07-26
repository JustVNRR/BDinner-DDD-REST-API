using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>(); // Inutile (car identiques) mais contribue à lister tous les mappings

        config.NewConfig<LoginRequest, LoginQuery>(); // Inutile mais contribue à lister tous les mappings

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.FirstName, src => src.User.FirstName.Value)
            .Map(dest => dest.LastName, src => src.User.LastName.Value)
            .Map(dest => dest.Email, src => src.User.Email.Value);
    }
}
