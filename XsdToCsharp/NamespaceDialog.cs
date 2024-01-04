using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XsdToCsharp
{
    public partial class NamespaceDialog : Form
    {
        NsPair Item;

        void AnyClick(object sender, EventArgs e)
        {
            if (btnOK == sender)
            {
                if (!string.IsNullOrWhiteSpace(edtXsd.Text) && !string.IsNullOrWhiteSpace(edtCSharp.Text))
                {
                    Item.Xsd = edtXsd.Text.Trim();
                    Item.CSharp = edtCSharp.Text.Trim();

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        void FormInitialize()
        {
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;

            btnOK.Click += AnyClick;

            edtXsd.Text = Item.Xsd;
            edtCSharp.Text = Item.CSharp;
        }

        protected override void OnShown(EventArgs e)
        {
            if (!DesignMode)
                FormInitialize();
            base.OnShown(e);
        }

        public NamespaceDialog()
        {
            InitializeComponent();
        }

        static public bool ShowModal(NsPair Item)
        {
            using (NamespaceDialog F = new NamespaceDialog())
            {
                F.Item = Item;
                return F.ShowDialog() == DialogResult.OK;
            }
        }
    }
}
