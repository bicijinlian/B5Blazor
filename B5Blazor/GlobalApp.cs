
using B5Blazor.Component;
/// <summary>
/// B5Blazor UI库 全局对象 
/// </summary>
public static class GlobalApp
{ 
    public static readonly string B5BlazorUiWebRoot = $"_content/{typeof(B5BlazorBase).Assembly.GetName().Name}";
}