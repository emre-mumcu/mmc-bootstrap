using System;

namespace mmc.bootstrap.v5.Common;

public class AlertTypeAttribute: Attribute
{
    public string Name { get; set; } = null!;

}
