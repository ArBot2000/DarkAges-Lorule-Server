﻿#region

using System;

#endregion

namespace Darkages.Types
{
    [Flags]
    public enum SpawnQualifer
    {
        Random = 1 << 1,
        Defined = 1 << 2
    }
}