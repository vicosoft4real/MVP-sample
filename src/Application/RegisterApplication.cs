using Application.Features.AgreementManagement.Requests;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class RegisterApplication
{

    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(CreateAgreementHandler).Assembly);
        serviceCollection.AddValidatorsFromAssembly(typeof(AgreementUpdateValidation).Assembly);
    }
    
}