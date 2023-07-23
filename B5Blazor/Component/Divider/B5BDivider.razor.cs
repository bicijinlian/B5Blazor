namespace B5Blazor.Component;
public partial class B5BDivider : B5BlazorBase
{
    protected virtual string ClassNamesString => CssBuilder.Default("divider")
            .AddClass("divider-vertical", IsVertical)
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

    /// <summary>
    /// 获得 class 样式集合
    /// </summary>
    protected virtual string? TextClassString => CssBuilder.Default("divider-text")
        .AddClass("is-left", Alignment.Left == Alignment)
        .AddClass("is-center", Alignment.Center == Alignment)
        .AddClass("is-right", Alignment.Right == Alignment)
        .Build();

    /// <summary>
    /// 垂直显示
    /// (默认为 false 即水平显示)
    /// </summary>
    [Parameter]
    public bool IsVertical { get; set; }

    /// <summary>
    /// 组件对齐方式
    /// </summary>
    [Parameter]
    public Alignment Alignment { get; set; } = Alignment.Center;

    /// <summary>
    ///显示文字
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    /// <summary>
    /// 显示图标
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }

    /// <summary>
    /// 子内容 渲染片断
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
