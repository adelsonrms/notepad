namespace CashPosition
{
    partial class ManualInput
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Layout panels
            var mainLayout = new System.Windows.Forms.TableLayoutPanel();
            var panelInputs = new System.Windows.Forms.TableLayoutPanel();
            var panelActions = new System.Windows.Forms.FlowLayoutPanel();
            var panelBottom = new System.Windows.Forms.FlowLayoutPanel();

            // Labels
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelGLNumber = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelBank = new System.Windows.Forms.Label();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelMaturityDate = new System.Windows.Forms.Label();
            // Input controls
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxGLNumber = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.dateTimePickerMaturity = new System.Windows.Forms.DateTimePicker();
            // Action buttons
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            // Data grid
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            // Back button
            this.btnBack = new System.Windows.Forms.Button();

            // Form setup
            this.SuspendLayout();

            // mainLayout
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.RowCount = 3;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // inputs + labels + actions
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // grid
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // bottom
            mainLayout.Controls.Add(panelInputs, 0, 0);
            mainLayout.Controls.Add(this.dataGridViewItems, 0, 1);
            mainLayout.Controls.Add(panelBottom, 0, 2);

            // panelInputs
            panelInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            panelInputs.ColumnCount = 9;
            panelInputs.RowCount = 2;
            panelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F)); // labels
            panelInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F)); // inputs
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F)); // Description
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F)); // GL Number
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F)); // Type
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F)); // Bank
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F)); // Product
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F)); // Amount
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F)); // Maturity Date
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F)); // Insert
            panelInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F)); // Clear

            // Labels row
            panelInputs.Controls.Add(this.labelDescription, 0, 0);
            panelInputs.Controls.Add(this.labelGLNumber, 1, 0);
            panelInputs.Controls.Add(this.labelType, 2, 0);
            panelInputs.Controls.Add(this.labelBank, 3, 0);
            panelInputs.Controls.Add(this.labelProduct, 4, 0);
            panelInputs.Controls.Add(this.labelAmount, 5, 0);
            panelInputs.Controls.Add(this.labelMaturityDate, 6, 0);
            // Inputs row
            panelInputs.Controls.Add(this.textBoxDescription, 0, 1);
            panelInputs.Controls.Add(this.comboBoxGLNumber, 1, 1);
            panelInputs.Controls.Add(this.comboBoxType, 2, 1);
            panelInputs.Controls.Add(this.comboBoxBank, 3, 1);
            panelInputs.Controls.Add(this.comboBoxProduct, 4, 1);
            panelInputs.Controls.Add(this.textBoxAmount, 5, 1);
            panelInputs.Controls.Add(this.dateTimePickerMaturity, 6, 1);
            panelInputs.Controls.Add(panelActions, 7, 1);
            panelInputs.Controls.Add(this.btnClear, 8, 1);

            // Label properties
            foreach (var lbl in new[] { labelDescription, labelGLNumber, labelType, labelBank, labelProduct, labelAmount, labelMaturityDate })
            {
                lbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
                lbl.ForeColor = System.Drawing.Color.Gray;
                lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            labelDescription.Text = "Description";
            labelGLNumber.Text = "GL Number";
            labelType.Text = "Type";
            labelBank.Text = "Bank";
            labelProduct.Text = "Product";
            labelAmount.Text = "Amount";
            labelMaturityDate.Text = "Maturity Date";

            // Input properties
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGLNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerMaturity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerMaturity.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // panelActions (Insert button)
            panelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            panelActions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            panelActions.Controls.Add(this.btnInsert);
            this.btnInsert.Text = "INSERT";
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.Size = new System.Drawing.Size(80, 25);

            // btnClear
            this.btnClear.Text = "CLEAR FIELDS";
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Size = new System.Drawing.Size(80, 25);

            // dataGridViewItems
            this.dataGridViewItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // panelBottom (Back button)
            panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            panelBottom.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            panelBottom.Controls.Add(this.btnBack);
            this.btnBack.Text = "BACK";
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnBack.ForeColor = System.Drawing.Color.Red;
            this.btnBack.Size = new System.Drawing.Size(80, 30);

            // Form
            this.Controls.Add(mainLayout);
            this.Text = "Insert Items";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelGLNumber;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelMaturityDate;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxGLNumber;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.DateTimePicker dateTimePickerMaturity;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button btnBack;
    }

    public partial class ManualInput : Form
    {
        public ManualInput()
        {
            InitializeComponent();
        }
    }
}
