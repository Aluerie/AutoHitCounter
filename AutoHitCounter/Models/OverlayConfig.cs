// 

namespace AutoHitCounter.Models;

public class OverlayConfig(
    bool showAttempts,
    int prevSplits,
    int nextSplits,
    bool showDiff,
    bool showPb,
    bool showIgt,
    int overlayWidth,
    int overlayHeight,
    bool showProgress,
    string fontFamily,
    int fontSize,
    int rowHeight,
    double backgroundOpacity,
    bool tableMode,
    string hitsZeroColor,
    string hitsActiveColor,
    string rowHitColor,
    string rowClearedColor,
    string currentSplitColor,
    string currentSplitBorderColor,
    string currentSplitHitColor,
    string currentSplitHitBorderColor,
    string diffPosColor,
    string diffNegColor,
    string diffZeroColor,
    string attemptsZeroColor,
    string attemptsActiveColor,
    string headerTextColor,
    string igtColor,
    string runCompleteBannerColor,
    bool fontBold,
    bool fontItalic,
    bool fontUnderline,
    string splitNameColor,
    string groupNameColor,
    string pbColor,
    bool showFooterTotals,
    string  igtFontFamily,
    int igtFontSize,
    string alternatingRows)
{
    public bool ShowAttempts { get; } = showAttempts;
    public int PrevSplits { get; } = prevSplits;
    public int NextSplits { get; } = nextSplits;
    public bool ShowDiff { get; } = showDiff;
    public bool ShowPb { get; } = showPb;
    public bool ShowIgt { get; } = showIgt;
    public int OverlayWidth { get; } = overlayWidth;
    public int OverlayHeight { get; } = overlayHeight;
    public bool ShowProgress { get; } = showProgress;
    public string FontFamily { get; } = fontFamily;
    public int FontSize { get; } = fontSize;
    public int RowHeight { get; } = rowHeight;
    public double BackgroundOpacity { get; } = backgroundOpacity;
    public bool TableMode { get; } = tableMode;
    public string HitsZeroColor { get; } = hitsZeroColor;
    public string HitsActiveColor { get; } = hitsActiveColor;
    public string RowHitColor { get; } = rowHitColor;
    public string RowClearedColor { get; } = rowClearedColor;
    public string CurrentSplitColor { get; } = currentSplitColor;
    public string CurrentSplitBorderColor { get; } = currentSplitBorderColor;
    public string CurrentSplitHitColor { get; } = currentSplitHitColor;
    public string CurrentSplitHitBorderColor { get; } = currentSplitHitBorderColor;
    public string DiffPosColor { get; } = diffPosColor;
    public string DiffNegColor { get; } = diffNegColor;
    public string DiffZeroColor { get; } = diffZeroColor;
    public string AttemptsZeroColor { get; } = attemptsZeroColor;
    public string AttemptsActiveColor { get; } = attemptsActiveColor;
    public string HeaderTextColor { get; } = headerTextColor;
    public string IgtColor { get; } = igtColor;
    public string RunCompleteBannerColor { get; } = runCompleteBannerColor;
    public bool FontBold { get; } = fontBold;
    public bool FontItalic { get; } = fontItalic;
    public bool FontUnderline { get; } = fontUnderline;
    public string SplitNameColor { get; } = splitNameColor;
    public string GroupNameColor { get; } = groupNameColor;
    public string PbColor { get; } = pbColor;
    public bool ShowFooterTotals { get; } = showFooterTotals;
    public string IgtFontFamily { get; } = igtFontFamily;
    public string AlternatingRows { get; } = alternatingRows;
    public int IgtFontSize { get; } = igtFontSize;

}