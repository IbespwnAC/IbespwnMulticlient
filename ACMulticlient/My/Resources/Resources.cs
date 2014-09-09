namespace ACMulticlient.My.Resources
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"), StandardModule, HideModuleName, CompilerGenerated]
    internal sealed class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal static Bitmap BringForwardHS
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("BringForwardHS", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap eventlogError
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("eventlogError", resourceCulture));
            }
        }

        internal static Bitmap idle_BLK_00
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("idle_BLK_00", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager2 = new System.Resources.ResourceManager("ACMulticlient.Resources", typeof(ACMulticlient.My.Resources.Resources).Assembly);
                    resourceMan = manager2;
                }
                return resourceMan;
            }
        }

        internal static Bitmap services
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("services", resourceCulture));
            }
        }
    }
}

