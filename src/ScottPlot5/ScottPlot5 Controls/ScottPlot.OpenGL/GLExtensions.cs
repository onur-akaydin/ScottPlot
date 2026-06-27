namespace ScottPlot;
using OpenTK.Graphics;
#if NETCOREAPP || NET
using OpenTK.Mathematics;
#endif

public static class GLExtensions
{
    public static Color4 ToTkColor(this ScottPlot.Color color)
    {
        // ScottPlot.Color channels are bytes (0-255); the OpenTK Color4 constructor bound here takes
        // normalized floats (0-1). Passing the raw bytes selects the float constructor with 0-255
        // values, which GL clamps to 1.0 - so every non-zero channel saturates to full. The result
        // is that GL scatter curves collapse to the 6 primary/secondary hues (orange->yellow,
        // violet->magenta, azure->cyan) and light colors wash out to white. Normalize explicitly so
        // GL curves render their true color and mid-tones stay distinct.
        const float s = 1f / 255f;
        return new Color4(color.Red * s, color.Green * s, color.Blue * s, color.Alpha * s);
    }
}
