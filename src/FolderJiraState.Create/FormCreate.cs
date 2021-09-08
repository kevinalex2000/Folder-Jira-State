
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FolderJiraState.Service;
using FolderJiraState.Utils;

namespace FolderJiraState.Create
{
    public partial class FormCreate : Form
    {
        readonly string location;
        readonly FolderAppService folderAppService;

        public FormCreate(string location)
        {
            InitializeComponent();
            this.location = location;

            lblLocation.Text = this.location;
            ttLocation.SetToolTip(lblLocation, this.location);

            folderAppService = new FolderAppService();
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            bool IsHTMLDataOnClipboard = Clipboard.ContainsData(DataFormats.Html);

            if (IsHTMLDataOnClipboard)
            {
                if(Clipboard.GetText() == txtLink.Text)
                {
                    string data = (string)Clipboard.GetData(DataFormats.Html);
                    data = data.Substring(data.IndexOf("<html"));
                    string title = ConvertHtml.ToText(data).Replace("\n", "").Trim();

                    txtName.Text = title;
                }
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            string dir = location + "\\" + txtName.Text;

            Directory.CreateDirectory(dir);
            DirectAccess.CreateAccessToInternet(dir, txtLink.Text, "Ticket Link");
            folderAppService.ChangeIcon(dir,"en_desarrollo");

            Application.Exit();
        }

        private bool validarCampos()
        {
            lblLink.ForeColor = Color.Black;
            lblName.ForeColor = Color.Black;

            if (string.IsNullOrEmpty(txtLink.Text))
            {
                lblLink.ForeColor = Color.Red;
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                lblName.ForeColor = Color.Red;
                return false;
            }

            if (!Utils.Validate.FolderName(txtName.Text))
            {
                MessageBox.Show(
                    "The name cannot contain any of these characters: /" + new string(Path.GetInvalidFileNameChars()), 
                    "Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }

            if (Directory.Exists(location + "\\" + txtName.Text))
            {
                MessageBox.Show(
                    "The named directory " + txtName.Text + " already exists in the location \"" + location+ "\"",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!Directory.Exists(location))
            {
                MessageBox.Show(
                    "Directory does not exist", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
