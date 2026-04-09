namespace CakeTime.Presentation.Drawable;

internal sealed class TextOutlineDrawable : BindableObject, IDrawable
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(TextOutlineDrawable), default(string));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(int), typeof(TextOutlineDrawable), default(int));

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(string), typeof(TextOutlineDrawable), default(string));

    public string TextColor
    {
        get => (string)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty OutlineColorProperty =
        BindableProperty.Create(nameof(OutlineColor), typeof(string), typeof(TextOutlineDrawable), default(string));

    public string OutlineColor
    {
        get => (string)GetValue(OutlineColorProperty);
        set => SetValue(OutlineColorProperty, value);
    }

    public static readonly BindableProperty OutlineThicknessProperty =
        BindableProperty.Create(nameof(OutlineThickness), typeof(float), typeof(TextOutlineDrawable), default(float));

    public float OutlineThickness
    {
        get => (float)GetValue(OutlineThicknessProperty);
        set => SetValue(OutlineThicknessProperty, value);
    }

    public static readonly BindableProperty HorizontalAlignmentProperty =
        BindableProperty.Create(
            nameof(HorizontalAlignment),
            typeof(HorizontalAlignment),
            typeof(TextOutlineDrawable),
            HorizontalAlignment.Left);

    public HorizontalAlignment HorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
        set => SetValue(HorizontalAlignmentProperty, value);
    }

    public static readonly BindableProperty VerticalAlignmentProperty =
        BindableProperty.Create(
            nameof(VerticalAlignment),
            typeof(VerticalAlignment),
            typeof(TextOutlineDrawable),
            VerticalAlignment.Top);

    public VerticalAlignment VerticalAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalAlignmentProperty);
        set => SetValue(VerticalAlignmentProperty, value);
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (string.IsNullOrEmpty(Text))
        {
            return;
        }

        canvas.Font = Microsoft.Maui.Graphics.Font.Default;
        canvas.FontSize = FontSize;

        var x = dirtyRect.Left;
        var y = dirtyRect.Top;

        var width = dirtyRect.Width;
        var height = dirtyRect.Height;

        // Массив смещений для имитации обводки
        var offsets = new[]
        {
            new PointF(-OutlineThickness, 0),
            new PointF(OutlineThickness, 0),
            new PointF(0, -OutlineThickness),
            new PointF(0, OutlineThickness),
            new PointF(-OutlineThickness, -OutlineThickness),
            new PointF(OutlineThickness, -OutlineThickness),
            new PointF(-OutlineThickness, OutlineThickness),
            new PointF(OutlineThickness, OutlineThickness),
        };

        // Рисуем обводку
        canvas.FontColor = Color.FromArgb(OutlineColor);
        foreach (var offset in offsets)
        {
            canvas.DrawString(
                Text,
                x + offset.X,
                y + offset.Y,
                width,
                height,
                HorizontalAlignment,
                VerticalAlignment);
        }

        // Рисуем заливку
        canvas.FontColor = Color.FromArgb(TextColor);
        canvas.DrawString(
            Text,
            x,
            y,
            width,
            height,
            HorizontalAlignment,
            VerticalAlignment);
    }
}