namespace CashPosition
{

    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    
    partial class MainPage
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Layout panels
            var mainLayout = new System.Windows.Forms.TableLayoutPanel();
            var panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            var panelTopInputs = new System.Windows.Forms.TableLayoutPanel();
            var panelMiddleInputs = new System.Windows.Forms.TableLayoutPanel();
            var panelGrids = new System.Windows.Forms.TableLayoutPanel();

            // Buttons
            this.btnCloseTool = new System.Windows.Forms.Button();
            this.btnImportFiles = new System.Windows.Forms.Button();
            this.btnManualInput = new System.Windows.Forms.Button();
            this.btnMaturitySchedule = new System.Windows.Forms.Button();
            this.btnBalanceList = new System.Windows.Forms.Button();
            this.btnExportDaily = new System.Windows.Forms.Button();
            // Top inputs
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.btnExportCashFlow = new System.Windows.Forms.Button();
            this.btnUpdateBalance = new System.Windows.Forms.Button();
            // Middle inputs (8)
            this.labelMinimum = new System.Windows.Forms.Label();
            this.textBoxMinimum = new System.Windows.Forms.TextBox();
            this.labelNumDays = new System.Windows.Forms.Label();
            this.textBoxNumDays = new System.Windows.Forms.TextBox();
            this.labelSaldoPrevisto = new System.Windows.Forms.Label();
            this.textBoxSaldoPrevisto = new System.Windows.Forms.TextBox();
            this.labelPendencias = new System.Windows.Forms.Label();
            this.textBoxPendenciasEuroclear = new System.Windows.Forms.TextBox();
            this.labelCustomerBalance = new System.Windows.Forms.Label();
            this.textBoxCustomerBalance = new System.Windows.Forms.TextBox();
            this.labelNetCustomerBalance = new System.Windows.Forms.Label();
            this.textBoxNetCustomerBalance = new System.Windows.Forms.TextBox();
            this.labelAsset = new System.Windows.Forms.Label();
            this.textBoxAsset = new System.Windows.Forms.TextBox();
            this.labelLiability = new System.Windows.Forms.Label();
            this.textBoxLiability = new System.Windows.Forms.TextBox();
            this.labelCapitalRevenue = new System.Windows.Forms.Label();
            this.textBoxCapitalRevenue = new System.Windows.Forms.TextBox();
            this.labelDailyRevenue = new System.Windows.Forms.Label();
            this.textBoxDailyRevenue = new System.Windows.Forms.TextBox();
            // Grids
            this.groupDisponibilidades = new System.Windows.Forms.GroupBox();
            this.dataGridViewDisponibilidades = new System.Windows.Forms.DataGridView();
            this.groupBalanceDays = new System.Windows.Forms.GroupBox();
            this.dataGridViewBalanceDays = new System.Windows.Forms.DataGridView();
            this.groupExecutedOperations = new System.Windows.Forms.GroupBox();
            this.dataGridViewExecutedOperations = new System.Windows.Forms.DataGridView();
            this.groupMaturitySchedule = new System.Windows.Forms.GroupBox();
            this.dataGridViewMaturitySchedule = new System.Windows.Forms.DataGridView();

            // Form
            this.SuspendLayout();
            // mainLayout
            mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.ColumnCount = 1;
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // buttons
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F)); // top inputs
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F)); // middle inputs
            mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // grids
            mainLayout.Controls.Add(panelButtons, 0, 0);
            mainLayout.Controls.Add(panelTopInputs, 0, 1);
            mainLayout.Controls.Add(panelMiddleInputs, 0, 2);
            mainLayout.Controls.Add(panelGrids, 0, 3);

            // panelButtons
            panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            panelButtons.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            panelButtons.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            panelButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnCloseTool, this.btnImportFiles, this.btnManualInput,
                this.btnMaturitySchedule, this.btnBalanceList, this.btnExportDaily }
            );

            // Buttons style
            foreach (var btn in new[] { btnCloseTool, btnImportFiles, btnManualInput, btnMaturitySchedule, btnBalanceList, btnExportDaily })
            {
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                btn.ForeColor = System.Drawing.Color.Red;
                btn.Size = new System.Drawing.Size(110, 30);
            }
            btnCloseTool.Text = "CLOSE TOOL";
            btnImportFiles.Text = "IMPORT FILES";
            btnManualInput.Text = "MANUAL INPUT";
            btnMaturitySchedule.Text = "MATURITY SCHEDULE";
            btnBalanceList.Text = "BALANCE LIST";
            btnExportDaily.Text = "EXPORT DAILY";

            // panelTopInputs
            panelTopInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTopInputs.ColumnCount = 7;
            panelTopInputs.RowCount = 1;
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F)); // DATE:
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F)); // picker
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F)); // CURR
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F)); // combo
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F)); // export
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F)); // update
            panelTopInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelTopInputs.Controls.Add(this.labelDate, 0, 0);
            panelTopInputs.Controls.Add(this.dateTimePickerDate, 1, 0);
            panelTopInputs.Controls.Add(this.labelCurrency, 2, 0);
            panelTopInputs.Controls.Add(this.comboBoxCurrency, 3, 0);
            panelTopInputs.Controls.Add(this.btnExportCashFlow, 4, 0);
            panelTopInputs.Controls.Add(this.btnUpdateBalance, 5, 0);
            // Top inputs properties
            labelDate.Text = "DATE:";
            labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            dateTimePickerDate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelCurrency.Text = "CURRENCY:";
            labelCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            comboBoxCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            btnExportCashFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportCashFlow.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            btnExportCashFlow.Text = "EXPORT CASH FLOW";
            btnExportCashFlow.Size = new System.Drawing.Size(100, 25);
            btnUpdateBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdateBalance.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            btnUpdateBalance.Text = "UPDATE BALANCE";
            btnUpdateBalance.Size = new System.Drawing.Size(100, 25);

            // panelMiddleInputs
            panelMiddleInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMiddleInputs.ColumnCount = 4;
            panelMiddleInputs.RowCount = 2;
            for (int i = 0; i < 4; i++) panelMiddleInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panelMiddleInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelMiddleInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            // Add 8 label/text pairs
            panelMiddleInputs.Controls.Add(this.labelMinimum, 0, 0);
            panelMiddleInputs.Controls.Add(this.textBoxMinimum, 0, 1);
            panelMiddleInputs.Controls.Add(this.labelNumDays, 1, 0);
            panelMiddleInputs.Controls.Add(this.textBoxNumDays, 1, 1);
            panelMiddleInputs.Controls.Add(this.labelSaldoPrevisto, 2, 0);
            panelMiddleInputs.Controls.Add(this.textBoxSaldoPrevisto, 2, 1);
            panelMiddleInputs.Controls.Add(this.labelPendencias, 3, 0);
            panelMiddleInputs.Controls.Add(this.textBoxPendenciasEuroclear, 3, 1);
            panelMiddleInputs.Controls.Add(this.labelCustomerBalance, 0, 2);
            panelMiddleInputs.Controls.Add(this.textBoxCustomerBalance, 0, 3);
            panelMiddleInputs.Controls.Add(this.labelNetCustomerBalance, 1, 2);
            panelMiddleInputs.Controls.Add(this.textBoxNetCustomerBalance, 1, 3);
            panelMiddleInputs.Controls.Add(this.labelAsset, 2, 2);
            panelMiddleInputs.Controls.Add(this.textBoxAsset, 2, 3);
            panelMiddleInputs.Controls.Add(this.labelLiability, 3, 2);
            panelMiddleInputs.Controls.Add(this.textBoxLiability, 3, 3);
            panelMiddleInputs.Controls.Add(this.labelCapitalRevenue, 0, 4);
            panelMiddleInputs.Controls.Add(this.textBoxCapitalRevenue, 0, 5);
            panelMiddleInputs.Controls.Add(this.labelDailyRevenue, 1, 4);
            panelMiddleInputs.Controls.Add(this.textBoxDailyRevenue, 1, 5);
            // Note: Adjust row count accordingly or condense into two rows of 4 as per spec

            // panelGrids
            panelGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGrids.ColumnCount = 2;
            panelGrids.RowCount = 2;
            panelGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelGrids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelGrids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            panelGrids.Controls.Add(this.groupDisponibilidades, 0, 0);
            panelGrids.Controls.Add(this.groupBalanceDays, 1, 0);
            panelGrids.Controls.Add(this.groupExecutedOperations, 0, 1);
            panelGrids.Controls.Add(this.groupMaturitySchedule, 1, 1);

            // GroupBoxes and DataGridViews
            foreach (var grp in new[] { groupDisponibilidades, groupBalanceDays, groupExecutedOperations, groupMaturitySchedule })
            {
                grp.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            groupDisponibilidades.Text = "DISPONIBILIDADES";
            groupDisponibilidades.Controls.Add(dataGridViewDisponibilidades);
            dataGridViewDisponibilidades.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBalanceDays.Text = "BALANCE DAYS";
            groupBalanceDays.Controls.Add(dataGridViewBalanceDays);
            dataGridViewBalanceDays.Dock = System.Windows.Forms.DockStyle.Fill;
            groupExecutedOperations.Text = "EXECUTED OPERATIONS";
            groupExecutedOperations.Controls.Add(dataGridViewExecutedOperations);
            dataGridViewExecutedOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            groupMaturitySchedule.Text = "MATURITY SCHEDULE";
            groupMaturitySchedule.Controls.Add(dataGridViewMaturitySchedule);
            dataGridViewMaturitySchedule.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add mainLayout to form
            this.Controls.Add(mainLayout);
            this.Text = "Forecast";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnCloseTool;
        private System.Windows.Forms.Button btnImportFiles;
        private System.Windows.Forms.Button btnManualInput;
        private System.Windows.Forms.Button btnMaturitySchedule;
        private System.Windows.Forms.Button btnBalanceList;
        private System.Windows.Forms.Button btnExportDaily;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Button btnExportCashFlow;
        private System.Windows.Forms.Button btnUpdateBalance;
        private System.Windows.Forms.Label labelMinimum;
        private System.Windows.Forms.TextBox textBoxMinimum;
        private System.Windows.Forms.Label labelNumDays;
        private System.Windows.Forms.TextBox textBoxNumDays;
        private System.Windows.Forms.Label labelSaldoPrevisto;
        private System.Windows.Forms.TextBox textBoxSaldoPrevisto;
        private System.Windows.Forms.Label labelPendencias;
        private System.Windows.Forms.TextBox textBoxPendenciasEuroclear;
        private System.Windows.Forms.Label labelCustomerBalance;
        private System.Windows.Forms.TextBox textBoxCustomerBalance;
        private System.Windows.Forms.Label labelNetCustomerBalance;
        private System.Windows.Forms.TextBox textBoxNetCustomerBalance;
        private System.Windows.Forms.Label labelAsset;
        private System.Windows.Forms.TextBox textBoxAsset;
        private System.Windows.Forms.Label labelLiability;
        private System.Windows.Forms.TextBox textBoxLiability;
        private System.Windows.Forms.Label labelCapitalRevenue;
        private System.Windows.Forms.TextBox textBoxCapitalRevenue;
        private System.Windows.Forms.Label labelDailyRevenue;
        private System.Windows.Forms.TextBox textBoxDailyRevenue;
        private System.Windows.Forms.GroupBox groupDisponibilidades;
        private System.Windows.Forms.DataGridView dataGridViewDisponibilidades;
        private System.Windows.Forms.GroupBox groupBalanceDays;
        private System.Windows.Forms.DataGridView dataGridViewBalanceDays;
        private System.Windows.Forms.GroupBox groupExecutedOperations;
        private System.Windows.Forms.DataGridView dataGridViewExecutedOperations;
        private System.Windows.Forms.GroupBox groupMaturitySchedule;
        private System.Windows.Forms.DataGridView dataGridViewMaturitySchedule;
    }
}
