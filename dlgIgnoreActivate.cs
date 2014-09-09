// Decompiled with JetBrains decompiler
// Type: ACMulticlient.dlgIgnoreActivate
// Assembly: ACMulticlient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DCF484C-62A7-4E4F-971B-CBCDD7B9F32E
// Assembly location: C:\games\ACMulticlient\ACMulticlient.exe

using ACMulticlient.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACMulticlient
{
  [DesignerGenerated]
  public class dlgIgnoreActivate : Form
  {
    private IContainer components;
    [AccessedThroughProperty("TableLayoutPanel1")]
    private TableLayoutPanel _TableLayoutPanel1;
    [AccessedThroughProperty("OK_Button")]
    private Button _OK_Button;
    [AccessedThroughProperty("Cancel_Button")]
    private Button _Cancel_Button;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("Label2")]
    private Label _Label2;

    internal virtual TableLayoutPanel TableLayoutPanel1
    {
      [DebuggerNonUserCode] get
      {
        return this._TableLayoutPanel1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._TableLayoutPanel1 = value;
      }
    }

    internal virtual Button OK_Button
    {
      [DebuggerNonUserCode] get
      {
        return this._OK_Button;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OK_Button_Click);
        if (this._OK_Button != null)
          this._OK_Button.Click -= eventHandler;
        this._OK_Button = value;
        if (this._OK_Button == null)
          return;
        this._OK_Button.Click += eventHandler;
      }
    }

    internal virtual Button Cancel_Button
    {
      [DebuggerNonUserCode] get
      {
        return this._Cancel_Button;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Cancel_Button_Click);
        if (this._Cancel_Button != null)
          this._Cancel_Button.Click -= eventHandler;
        this._Cancel_Button = value;
        if (this._Cancel_Button == null)
          return;
        this._Cancel_Button.Click += eventHandler;
      }
    }

    internal virtual Button Button1
    {
      [DebuggerNonUserCode] get
      {
        return this._Button1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Button1 = value;
      }
    }

    internal virtual Label Label1
    {
      [DebuggerNonUserCode] get
      {
        return this._Label1;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label1 = value;
      }
    }

    internal virtual Label Label2
    {
      [DebuggerNonUserCode] get
      {
        return this._Label2;
      }
      [DebuggerNonUserCode, MethodImpl(MethodImplOptions.Synchronized)] set
      {
        this._Label2 = value;
      }
    }

    [DebuggerNonUserCode]
    public dlgIgnoreActivate()
    {
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
      this.TableLayoutPanel1 = new TableLayoutPanel();
      this.Cancel_Button = new Button();
      this.OK_Button = new Button();
      this.Button1 = new Button();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.TableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.TableLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TableLayoutPanel1.ColumnCount = 3;
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 79f));
      this.TableLayoutPanel1.Controls.Add((Control) this.Cancel_Button, 2, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.OK_Button, 1, 0);
      this.TableLayoutPanel1.Controls.Add((Control) this.Button1, 0, 0);
      TableLayoutPanel tableLayoutPanel1_1 = this.TableLayoutPanel1;
      Point point1 = new Point(13, 70);
      Point point2 = point1;
      tableLayoutPanel1_1.Location = point2;
      this.TableLayoutPanel1.Name = "TableLayoutPanel1";
      this.TableLayoutPanel1.RowCount = 1;
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
      TableLayoutPanel tableLayoutPanel1_2 = this.TableLayoutPanel1;
      Size size1 = new Size(245, 29);
      Size size2 = size1;
      tableLayoutPanel1_2.Size = size2;
      this.TableLayoutPanel1.TabIndex = 0;
      this.Cancel_Button.Anchor = AnchorStyles.None;
      this.Cancel_Button.DialogResult = DialogResult.Cancel;
      Button cancelButton1 = this.Cancel_Button;
      point1 = new Point(172, 3);
      Point point3 = point1;
      cancelButton1.Location = point3;
      this.Cancel_Button.Name = "Cancel_Button";
      Button cancelButton2 = this.Cancel_Button;
      size1 = new Size(67, 23);
      Size size3 = size1;
      cancelButton2.Size = size3;
      this.Cancel_Button.TabIndex = 1;
      this.Cancel_Button.Text = "Cancel";
      this.OK_Button.Anchor = AnchorStyles.None;
      Button okButton1 = this.OK_Button;
      point1 = new Point(91, 3);
      Point point4 = point1;
      okButton1.Location = point4;
      this.OK_Button.Name = "OK_Button";
      Button okButton2 = this.OK_Button;
      size1 = new Size(67, 23);
      Size size4 = size1;
      okButton2.Size = size4;
      this.OK_Button.TabIndex = 0;
      this.OK_Button.Text = "Activate";
      this.Button1.Anchor = AnchorStyles.None;
      this.Button1.DialogResult = DialogResult.Ignore;
      Button button1_1 = this.Button1;
      point1 = new Point(8, 3);
      Point point5 = point1;
      button1_1.Location = point5;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(67, 23);
      Size size5 = size1;
      button1_2.Size = size5;
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Ignore";
      this.Label1.AutoSize = true;
      Label label1_1 = this.Label1;
      point1 = new Point(18, 19);
      Point point6 = point1;
      label1_1.Location = point6;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      size1 = new Size(135, 13);
      Size size6 = size1;
      label1_2.Size = size6;
      this.Label1.TabIndex = 1;
      this.Label1.Text = "User is already Logged On.";
      this.Label2.Image = (Image) Resources.BringForwardHS;
      Label label2_1 = this.Label2;
      point1 = new Point(201, 19);
      Point point7 = point1;
      label2_1.Location = point7;
      this.Label2.Name = "Label2";
      Label label2_2 = this.Label2;
      size1 = new Size(39, 34);
      Size size7 = size1;
      label2_2.Size = size7;
      this.Label2.TabIndex = 2;
      this.AcceptButton = (IButtonControl) this.OK_Button;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.Cancel_Button;
      size1 = new Size(270, 111);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.TableLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "dlgIgnoreActivate";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Info";
      this.TableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void OK_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void Cancel_Button_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
  }
}
