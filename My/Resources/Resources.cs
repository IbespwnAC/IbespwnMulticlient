// Decompiled with JetBrains decompiler
// Type: ACMulticlient.My.Resources.Resources
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ACMulticlient.My.Resources
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [StandardModule]
  [HideModuleName]
  [CompilerGenerated]
  internal sealed class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Resources.resourceMan, (object) null))
          Resources.resourceMan = new ResourceManager("ACMulticlient.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resources.resourceCulture;
      }
      set
      {
        Resources.resourceCulture = value;
      }
    }

    internal static Bitmap BringForwardHS
    {
      get
      {
        return (Bitmap) RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("BringForwardHS", Resources.resourceCulture));
      }
    }

    internal static Bitmap eventlogError
    {
      get
      {
        return (Bitmap) RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("eventlogError", Resources.resourceCulture));
      }
    }

    internal static Bitmap idle_BLK_00
    {
      get
      {
        return (Bitmap) RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("idle_BLK_00", Resources.resourceCulture));
      }
    }

    internal static Bitmap services
    {
      get
      {
        return (Bitmap) RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("services", Resources.resourceCulture));
      }
    }
  }
}
