using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using B5Blazor;

var builder = WebApplication.CreateBuilder(args);

#region IoC服务注册
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddB5Blazor();
#endregion

var app = builder.Build();

#region 中间件注册
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
#endregion

app.Run();
