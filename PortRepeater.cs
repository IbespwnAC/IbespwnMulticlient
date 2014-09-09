// Decompiled with JetBrains decompiler
// Type: ACMulticlient.PortRepeater
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ACMulticlient
{
  [DesignerGenerated]
  public class PortRepeater : UserControl
  {
    private IContainer components;
    private int mtextbox_x;

    public PortRepeater()
    {
      this.mtextbox_x = 0;
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoScroll = true;
      this.Name = "PortRepeater";
      this.Size = new Size(175, 41);
      this.ResumeLayout(false);
    }

    public List<int> Getports()
    {
      List<int> list = new List<int>();
      try
      {
        foreach (Control control in this.Controls)
        {
          if (control is TextBox)
          {
            int result = 0;
            int.TryParse(((TextBox) control).Text, out result);
            if (result > 0 && !list.Contains(result))
              list.Add(result);
          }
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return list;
    }

    private TextBox addtextbox(int port)
    {
      TextBox textBox = new TextBox();
      textBox.Left = checked (this.mtextbox_x + this.AutoScrollPosition.X);
      this.mtextbox_x = checked (this.mtextbox_x + 42);
      textBox.Size = new Size(36, 20);
      textBox.Text = Conversions.ToString(port);
      this.Controls.Add((Control) textBox);
      return textBox;
    }

    public void Addmore()
    {
      try
      {
        foreach (Control control in this.Controls)
        {
          if (control is TextBox)
          {
            int result = 0;
            int.TryParse(((TextBox) control).Text, out result);
            if (result == 0)
            {
              control.Focus();
              return;
            }
          }
        }
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.addtextbox(0).Focus();
    }

    public void setPorts(int[] value)
    {
      List<int> list1 = new List<int>();
      List<int> list2;
      if (value == null)
      {
        list2 = new List<int>();
        list2.Add(9000);
        list2.Add(9005);
        list2.Add(9010);
      }
      else
      {
        list2 = new List<int>();
        int num1 = 0;
        int num2 = Information.UBound((Array) value, 1);
        int index = num1;
        while (index <= num2)
        {
          list2.Add(value[index]);
          checked { ++index; }
        }
      }
      list2.Sort();
      List<int>.Enumerator enumerator;
      try
      {
        enumerator = list2.GetEnumerator();
        while (enumerator.MoveNext())
          this.addtextbox(enumerator.Current);
      }
      finally
      {
        enumerator.Dispose();
      }
    }
  }
}
