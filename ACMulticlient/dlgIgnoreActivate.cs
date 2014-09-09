namespace ACMulticlient
{
    using ACMulticlient.My.Resources;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class dlgIgnoreActivate : Form
    {
        [AccessedThroughProperty("Button1")]
        private Button _Button1;
        [AccessedThroughProperty("Cancel_Button")]
        private Button _Cancel_Button;
        [AccessedThroughProperty("Label1")]
        private Label _Label1;
        [AccessedThroughProperty("Label2")]
        private Label _Label2;
        [AccessedThroughProperty("OK_Button")]
        private Button _OK_Button;
        [AccessedThroughProperty("TableLayoutPanel1")]
        private TableLayoutPanel _TableLayoutPanel1;
        private IContainer components;

        [DebuggerNonUserCode]
        public dlgIgnoreActivate()
        {
            this.InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
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
            this.TableLayoutPanel1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 79f));
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Button1, 0, 0);
            Point point = new Point(13, 70);
            this.TableLayoutPanel1.Location = point;
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29f));
            Size size = new Size(0xf5, 0x1d);
            this.TableLayoutPanel1.Size = size;
            this.TableLayoutPanel1.TabIndex = 0;
            this.Cancel_Button.Anchor = AnchorStyles.None;
            this.Cancel_Button.DialogResult = DialogResult.Cancel;
            point = new Point(0xac, 3);
            this.Cancel_Button.Location = point;
            this.Cancel_Button.Name = "Cancel_Button";
            size = new Size(0x43, 0x17);
            this.Cancel_Button.Size = size;
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.OK_Button.Anchor = AnchorStyles.None;
            point = new Point(0x5b, 3);
            this.OK_Button.Location = point;
            this.OK_Button.Name = "OK_Button";
            size = new Size(0x43, 0x17);
            this.OK_Button.Size = size;
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Activate";
            this.Button1.Anchor = AnchorStyles.None;
            this.Button1.DialogResult = DialogResult.Ignore;
            point = new Point(8, 3);
            this.Button1.Location = point;
            this.Button1.Name = "Button1";
            size = new Size(0x43, 0x17);
            this.Button1.Size = size;
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Ignore";
            this.Label1.AutoSize = true;
            point = new Point(0x12, 0x13);
            this.Label1.Location = point;
            this.Label1.Name = "Label1";
            size = new Size(0x87, 13);
            this.Label1.Size = size;
            this.Label1.TabIndex = 1;
            this.Label1.Text = "User is already Logged On.";
            this.Label2.Image = ACMulticlient.My.Resources.Resources.BringForwardHS;
            point = new Point(0xc9, 0x13);
            this.Label2.Location = point;
            this.Label2.Name = "Label2";
            size = new Size(0x27, 0x22);
            this.Label2.Size = size;
            this.Label2.TabIndex = 2;
            this.AcceptButton = this.OK_Button;
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            size = new Size(270, 0x6f);
            this.ClientSize = size;
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TableLayoutPanel1);
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

        internal virtual Button Button1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Button1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Button1 = value;
            }
        }

        internal virtual Button Cancel_Button
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Cancel_Button;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.Cancel_Button_Click);
                if (this._Cancel_Button != null)
                {
                    this._Cancel_Button.Click -= handler;
                }
                this._Cancel_Button = value;
                if (this._Cancel_Button != null)
                {
                    this._Cancel_Button.Click += handler;
                }
            }
        }

        internal virtual Label Label1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label1 = value;
            }
        }

        internal virtual Label Label2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Label2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Label2 = value;
            }
        }

        internal virtual Button OK_Button
        {
            [DebuggerNonUserCode]
            get
            {
                return this._OK_Button;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.OK_Button_Click);
                if (this._OK_Button != null)
                {
                    this._OK_Button.Click -= handler;
                }
                this._OK_Button = value;
                if (this._OK_Button != null)
                {
                    this._OK_Button.Click += handler;
                }
            }
        }

        internal virtual TableLayoutPanel TableLayoutPanel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TableLayoutPanel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TableLayoutPanel1 = value;
            }
        }
    }
}

