using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorSyncTask;
using BlazorSyncTask.Auth;
using BlazorSyncTask.Services;
using BlazorSyncTask.Services.Http;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IFriendsInterface, FriendsHttpService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services
        .AddBlazorise( options =>
        {
            options.Immediate = true;
        })
        .AddBootstrapProviders()
       .AddFontAwesomeIcons();
await builder.Build().RunAsync();