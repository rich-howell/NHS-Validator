using NHSValidator.NHS;
using NHSValidator.NHS.Testing;

namespace NHSValidator
{
    public partial class Main : Form
    {
        private readonly ToolTip _toolTip = new();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            btnCopyNumbers.Enabled = false;

            cbValidNumbers.DataSource = new[]
            {
                new { Text = "Yes", Value = true },
                new { Text = "No", Value = false }
            };

            cbValidNumbers.DisplayMember = "Text";
            cbValidNumbers.ValueMember = "Value";
            cbValidNumbers.SelectedIndex = 0;

            _toolTip.SetToolTip(
                txtNHSNumber,
                "Enter an NHS number (10 digits).\r\nSpaces and dashes are allowed."
            );

            _toolTip.SetToolTip(
                cbValidNumbers,
                "For testing only.\r\nGenerates either valid or intentionally invalid NHS numbers."
            );

            _toolTip.SetToolTip(
                btnGenerate,
                "Generates test NHS numbers using the Modulus 11 checksum."
            );

            ActiveControl = txtNHSNumber;

        }

        private void btnCheckNHS_Click(object sender, EventArgs e)
        {
            string nhsNumber = txtNHSNumber.Text;
            if (!NHSNumber.TryParse(nhsNumber, out NHSNumber? nhs))
            {
                _ = MessageBox.Show(text: $"The NHS Number {nhs.NormalisedValue} is not valid");
                return;
            }
            else
            {
                _ = MessageBox.Show("NHS Number " + nhsNumber + " is valid");
            }
        }

        private void txtNHSNumber_TextChanged(object sender, EventArgs e)
        {
            int digitCount = txtNHSNumber.Text.Count(char.IsDigit);

            if (digitCount < 10)
            {
                lblStatus.Text = "Enter NHS number";
                return;
            }

            string normalised = new(txtNHSNumber.Text.Where(char.IsDigit).ToArray());

            lblStatus.Text = NHSNumber.TryParse(txtNHSNumber.Text, out NHSNumber? nhs)
                ? $"{nhs.NormalisedValue} – valid NHS number"
                : $"{normalised} – invalid NHS number";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            rtbNumbers.Clear();
            int quantity = (int)numQty.Value;

            if (quantity == 0)
            {
                _ = MessageBox.Show(
                    "Please enter a valid qty for generation",
                    "Generation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            bool valid = (bool)cbValidNumbers.SelectedValue;

            IReadOnlyList<string> numbers = NHSNumberGenerator.Generate(
                valid: valid,
                quantity: quantity
            );

            rtbNumbers.Text = string.Join(
                Environment.NewLine,
                numbers
            );

            btnCopyNumbers.Enabled = true;
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            if (cbValidNumbers.Text != "0")
            {
                btnGenerate.Enabled = true;
            }
        }

        private void btnCopyNumbers_Click(object sender, EventArgs e)
        {
            if (rtbNumbers.Text.Length > 0)
            {
                Clipboard.SetText(rtbNumbers.Text);
                _ = MessageBox.Show("Numbers copied\r\nRemember, these should only be used for testing", "Numbers Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _ = MessageBox.Show(
                    "There are no generated numbers to copy yet.",
                    "Nothing to Copy",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) => exitApplication();

        private static void exitApplication()
        {
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(1);
            }
        }

    }
}
