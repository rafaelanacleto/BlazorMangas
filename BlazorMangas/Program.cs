using BlazorMangas;
using BlazorMangas.Services.Autentica;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("ApiMangas", options =>
{
    options.BaseAddress = new Uri("http://localhost:5094/");
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenServerAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => 
            provider.GetRequiredService<TokenServerAuthenticationStateProvider>());

builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
