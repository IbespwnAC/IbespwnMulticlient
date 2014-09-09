namespace ACMulticlient
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class PortRepeater : UserControl
    {
        private IContainer components;
        private int mtextbox_x = 0;

        public PortRepeater()
        {
            this.InitializeComponent();
        }

        public void Addmore()
        {
            IEnumerator enumerator;
            try
            {
                enumerator = this.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    if (current is TextBox)
                    {
                        int result = 0;
                        int.TryParse(((TextBox) current).Text, out result);
                        if (result == 0)
                        {
                            current.Focus();
                            return;
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.addtextbox(0).Focus();
        }

        private TextBox addtextbox(int port)
        {
            TextBox box2 = new TextBox {
                Left = this.mtextbox_x + this.AutoScrollPosition.X
            };
            this.mtextbox_x += 0x2a;
            Size size = new Size(0x24, 20);
            box2.Size = size;
            box2.Text = Conversions.ToString(port);
            this.Controls.Add(box2);
            return box2;
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

        public List<int> Getports()
        {
            IEnumerator enumerator;
            List<int> list2 = new List<int>();
            try
            {
                enumerator = this.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    if (current is TextBox)
                    {
                        int result = 0;
                        int.TryParse(((TextBox) current).Text, out result);
                        if ((result > 0) && !list2.Contains(result))
                        {
                            list2.Add(result);
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return list2;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.SuspendLayout();
            SizeF ef = new SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "PortRepeater";
            Size size = new Size(0xaf, 0x29);
            this.Size = size;
            this.ResumeLayout(false);
        }

        public void setPorts(int[] value)
        {
            List<int>.Enumerator enumerator;
            List<int> list = new List<int>();
            if (value == null)
            {
                list = new List<int> { 0x2328, 0x232d, 0x2332 };
            }
            else
            {
                list = new List<int>();
                int num3 = Information.UBound(value, 1);
                for (int i = 0; i <= num3; i++)
                {
                    list.Add(value[i]);
                }
            }
            list.Sort();
            try
            {
                enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
                    this.addtextbox(current);
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }
    }
}

