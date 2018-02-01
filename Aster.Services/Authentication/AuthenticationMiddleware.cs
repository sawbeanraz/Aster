using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Aster.Services.Authentication {

  public class AuthenticationMiddleware {

    private readonly RequestDelegate _next;  

    public AuthenticationMiddleware(RequestDelegate next, IAuthenticationSchemeProvider schemes) {

      _next = next ?? throw new ArgumentNullException(nameof(next));
      Schemes = schemes ?? throw new ArgumentNullException(nameof(schemes));

    }

    public IAuthenticationSchemeProvider Schemes { get; set; }

    public async Task Invoke(HttpContext context) {
      // context.Features.Set<IAuthenticationFeature>(new AuthenticationFeature
      // {
      //     OriginalPath = context.Request.Path,
      //     OriginalPathBase = context.Request.PathBase
      // });

      // // Give any IAuthenticationRequestHandler schemes a chance to handle the request
      // var handlers = context.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
      // foreach (var scheme in await Schemes.GetRequestHandlerSchemesAsync())
      // {
      //     try
      //     {
      //         if (await handlers.GetHandlerAsync(context, scheme.Name) is IAuthenticationRequestHandler handler && await handler.HandleRequestAsync())
      //             return;
      //     }
      //     catch { continue; }
      // }

      // var defaultAuthenticate = await Schemes.GetDefaultAuthenticateSchemeAsync();
      // if (defaultAuthenticate != null)
      // {
      //     var result = await context.AuthenticateAsync(defaultAuthenticate.Name);
      //     if (result?.Principal != null)
      //     {
      //         context.User = result.Principal;
      //     }
      // }

      await _next(context);
    }

  }
  
}