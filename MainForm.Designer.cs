namespace InventorySalesSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlProductsTop = new System.Windows.Forms.Panel();
            this.btnLoadProducts = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlCustomersTop = new System.Windows.Forms.Panel();
            this.btnLoadCustomers = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.btnLoadSaleData = new System.Windows.Forms.Button();
            this.numSaleQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSaleProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSaleCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlReportsTop = new System.Windows.Forms.Panel();
            this.btnLowStockReport = new System.Windows.Forms.Button();
            this.btnTopProductsReport = new System.Windows.Forms.Button();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlProductsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlCustomersTop.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaleQuantity)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.pnlReportsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1076, 660);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlProductsTop);
            this.tabPage1.Controls.Add(this.dgvProducts);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1068, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ürünler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlProductsTop
            // 
            this.pnlProductsTop.Controls.Add(this.btnLoadProducts);
            this.pnlProductsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductsTop.Location = new System.Drawing.Point(3, 3);
            this.pnlProductsTop.Name = "pnlProductsTop";
            this.pnlProductsTop.Size = new System.Drawing.Size(1062, 50);
            this.pnlProductsTop.TabIndex = 1;
            // 
            // btnLoadProducts
            // 
            this.btnLoadProducts.Location = new System.Drawing.Point(0, 0);
            this.btnLoadProducts.Name = "btnLoadProducts";
            this.btnLoadProducts.Size = new System.Drawing.Size(168, 50);
            this.btnLoadProducts.TabIndex = 2;
            this.btnLoadProducts.Text = "Ürünleri Listele";
            this.btnLoadProducts.UseVisualStyleBackColor = true;
            this.btnLoadProducts.Click += new System.EventHandler(this.btnLoadProducts_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 3);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(1062, 621);
            this.dgvProducts.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvCustomers);
            this.tabPage2.Controls.Add(this.pnlCustomersTop);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1068, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Müşteriler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 53);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.Size = new System.Drawing.Size(1062, 571);
            this.dgvCustomers.TabIndex = 1;
            // 
            // pnlCustomersTop
            // 
            this.pnlCustomersTop.Controls.Add(this.btnLoadCustomers);
            this.pnlCustomersTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomersTop.Location = new System.Drawing.Point(3, 3);
            this.pnlCustomersTop.Name = "pnlCustomersTop";
            this.pnlCustomersTop.Size = new System.Drawing.Size(1062, 50);
            this.pnlCustomersTop.TabIndex = 0;
            // 
            // btnLoadCustomers
            // 
            this.btnLoadCustomers.Location = new System.Drawing.Point(0, 0);
            this.btnLoadCustomers.Name = "btnLoadCustomers";
            this.btnLoadCustomers.Size = new System.Drawing.Size(156, 50);
            this.btnLoadCustomers.TabIndex = 0;
            this.btnLoadCustomers.Text = "Müşterileri Listele";
            this.btnLoadCustomers.UseVisualStyleBackColor = true;
            this.btnLoadCustomers.Click += new System.EventHandler(this.btnLoadCustomers_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCreateSale);
            this.tabPage3.Controls.Add(this.btnLoadSaleData);
            this.tabPage3.Controls.Add(this.numSaleQuantity);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cmbSaleProduct);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cmbSaleCustomer);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1068, 627);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Satış";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreateSale.Location = new System.Drawing.Point(233, 253);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Size = new System.Drawing.Size(131, 43);
            this.btnCreateSale.TabIndex = 8;
            this.btnCreateSale.Text = "Satış Yap";
            this.btnCreateSale.UseVisualStyleBackColor = true;
            this.btnCreateSale.Click += new System.EventHandler(this.btnCreateSale_Click);
            // 
            // btnLoadSaleData
            // 
            this.btnLoadSaleData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoadSaleData.Location = new System.Drawing.Point(27, 253);
            this.btnLoadSaleData.Name = "btnLoadSaleData";
            this.btnLoadSaleData.Size = new System.Drawing.Size(127, 43);
            this.btnLoadSaleData.TabIndex = 7;
            this.btnLoadSaleData.Text = "Verileri Yükle";
            this.btnLoadSaleData.UseVisualStyleBackColor = true;
            this.btnLoadSaleData.Click += new System.EventHandler(this.btnLoadSaleData_Click);
            // 
            // numSaleQuantity
            // 
            this.numSaleQuantity.Location = new System.Drawing.Point(114, 190);
            this.numSaleQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSaleQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSaleQuantity.Name = "numSaleQuantity";
            this.numSaleQuantity.Size = new System.Drawing.Size(120, 26);
            this.numSaleQuantity.TabIndex = 6;
            this.numSaleQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(23, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Miktar:";
            // 
            // cmbSaleProduct
            // 
            this.cmbSaleProduct.FormattingEnabled = true;
            this.cmbSaleProduct.Location = new System.Drawing.Point(114, 104);
            this.cmbSaleProduct.Name = "cmbSaleProduct";
            this.cmbSaleProduct.Size = new System.Drawing.Size(250, 28);
            this.cmbSaleProduct.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ürün:";
            // 
            // cmbSaleCustomer
            // 
            this.cmbSaleCustomer.FormattingEnabled = true;
            this.cmbSaleCustomer.Location = new System.Drawing.Point(114, 35);
            this.cmbSaleCustomer.Name = "cmbSaleCustomer";
            this.cmbSaleCustomer.Size = new System.Drawing.Size(250, 28);
            this.cmbSaleCustomer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvReports);
            this.tabPage4.Controls.Add(this.btnTopProductsReport);
            this.tabPage4.Controls.Add(this.pnlReportsTop);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1068, 627);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Raporlar";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pnlReportsTop
            // 
            this.pnlReportsTop.Controls.Add(this.btnLowStockReport);
            this.pnlReportsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportsTop.Location = new System.Drawing.Point(3, 3);
            this.pnlReportsTop.Name = "pnlReportsTop";
            this.pnlReportsTop.Size = new System.Drawing.Size(1062, 50);
            this.pnlReportsTop.TabIndex = 0;
            // 
            // btnLowStockReport
            // 
            this.btnLowStockReport.Location = new System.Drawing.Point(0, -3);
            this.btnLowStockReport.Name = "btnLowStockReport";
            this.btnLowStockReport.Size = new System.Drawing.Size(247, 53);
            this.btnLowStockReport.TabIndex = 0;
            this.btnLowStockReport.Text = "Düşük Stok Raporu";
            this.btnLowStockReport.UseVisualStyleBackColor = true;
            this.btnLowStockReport.Click += new System.EventHandler(this.btnLowStockReport_Click);
            // 
            // btnTopProductsReport
            // 
            this.btnTopProductsReport.Location = new System.Drawing.Point(270, 0);
            this.btnTopProductsReport.Name = "btnTopProductsReport";
            this.btnTopProductsReport.Size = new System.Drawing.Size(210, 53);
            this.btnTopProductsReport.TabIndex = 1;
            this.btnTopProductsReport.Text = "En Çok Satılan Ürünler";
            this.btnTopProductsReport.UseVisualStyleBackColor = true;
            this.btnTopProductsReport.Click += new System.EventHandler(this.btnTopProductsReport_Click);
            // 
            // dgvReports
            // 
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.Location = new System.Drawing.Point(3, 53);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.Size = new System.Drawing.Size(1062, 571);
            this.dgvReports.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 660);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlProductsTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlCustomersTop.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSaleQuantity)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.pnlReportsTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlProductsTop;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnLoadProducts;
        private System.Windows.Forms.Panel pnlCustomersTop;
        private System.Windows.Forms.Button btnLoadCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown numSaleQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSaleProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSaleCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.Button btnLoadSaleData;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel pnlReportsTop;
        private System.Windows.Forms.Button btnLowStockReport;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnTopProductsReport;
    }
}
