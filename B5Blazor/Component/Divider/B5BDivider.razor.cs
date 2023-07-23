namespace B5Blazor.Component;
public partial class B5BDivider : B5BlazorBase
{
    protected virtual string ClassNamesString => CssBuilder.Default("divider")
            .AddClass("divider-vertical", IsVertical)
            .AddClassFromAttributes(AdditionalAttributes)
            .Build();

    /// <summary>
    /// ��� class ��ʽ����
    /// </summary>
    protected virtual string? TextClassString => CssBuilder.Default("divider-text")
        .AddClass("is-left", Alignment.Left == Alignment)
        .AddClass("is-center", Alignment.Center == Alignment)
        .AddClass("is-right", Alignment.Right == Alignment)
        .Build();

    /// <summary>
    /// ��ֱ��ʾ
    /// (Ĭ��Ϊ false ��ˮƽ��ʾ)
    /// </summary>
    [Parameter]
    public bool IsVertical { get; set; }

    /// <summary>
    /// ������뷽ʽ
    /// </summary>
    [Parameter]
    public Alignment Alignment { get; set; } = Alignment.Center;

    /// <summary>
    ///��ʾ����
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    /// <summary>
    /// ��ʾͼ��
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }

    /// <summary>
    /// ������ ��ȾƬ��
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
