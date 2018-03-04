#if NET35
using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS1591
namespace Konscious.Security.Cryptography
{
    internal static class Vector
    {
        public static bool IsHardwareAccelerated
        {
            get => false;
        }
    }
}
#pragma warning restore CS1591
#endif
