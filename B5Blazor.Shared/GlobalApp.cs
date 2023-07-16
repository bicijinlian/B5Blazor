
namespace B5Blazor.Shared;
/// <summary>
/// B5Blazor.Shared库 全局对象 
/// </summary>
public static class GlobalApp
{ 
    public static readonly string B5BlazorSharedWebRoot = $"_content/{typeof(GlobalApp).Assembly.GetName().Name}";
}