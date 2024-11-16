using System;

namespace mmc.bootstrap.v5.Common;

public class mmcTagHelperOptions
{
    public Func<string> NullDateFormatter { get; set; } = () => "n/a";

    public Func<DateTime, string> TooltipDateFormatter { get; set; } = d => string.Format("{0:D}, {0:T}", d);

    public Func<DateTime, string> GeneralDateFormatter { get; set; } = d => string.Format("{0:d}, {0:t}", d);

    public Func<DateTime, string> TodayDateFormatter { get; set; } = d => string.Format("today, {0:t}", d);

    public Func<DateTime, string> YesterdayDateFormatter { get; set; } = d => string.Format("yesterday, {0:t}", d);

    public Func<DateTime, string> TomorrowDateFormatter { get; set; } = d => string.Format("tomorrow, {0:t}", d);
}
