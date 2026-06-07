using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventorySalesSystem.Services;

namespace InventorySalesSystem
{
    public partial class MainForm : Form
    {
        private readonly InventoryService _inventoryService;
        private readonly CustomerService _customerService;
        private readonly SalesService _salesService;
        private readonly ReportService _reportService;
        private TextBox _txtProductName;
        private ComboBox _cmbProductCategory;
        private NumericUpDown _numProductPrice;
        private NumericUpDown _numProductStock;
        private NumericUpDown _numProductMinimumStock;
        private Button _btnAddProduct;
        private Button _btnUpdateProduct;

        public MainForm(
            InventoryService inventoryService,
            CustomerService customerService,
            SalesService salesService,
            ReportService reportService)
        {
            InitializeComponent();

            _inventoryService = inventoryService;
            _customerService = customerService;
            _salesService = salesService;
            _reportService = reportService;

            Text = "Stok ve Satış Yönetim Sistemi";
            Width = 1000;
            Height = 650;

            SetupProductEditor();
        }

        private void SetupProductEditor()
        {
            pnlProductsTop.Height = 135;

            AddProductLabel("Ürün Adı:", 20, 18, 85);
            _txtProductName = AddProductTextBox(110, 15, 220);

            AddProductLabel("Kategori:", 350, 18, 80);
            _cmbProductCategory = new ComboBox
            {
                Left = 435,
                Top = 15,
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbProductCategory.Items.Add(new ProductCategoryItem(1, "Klavye"));
            _cmbProductCategory.Items.Add(new ProductCategoryItem(2, "Mouse"));
            _cmbProductCategory.Items.Add(new ProductCategoryItem(3, "Kulaklık"));
            _cmbProductCategory.Items.Add(new ProductCategoryItem(4, "Depolama"));
            _cmbProductCategory.Items.Add(new ProductCategoryItem(5, "Monitör"));
            _cmbProductCategory.Items.Add(new ProductCategoryItem(6, "Aksesuar"));
            _cmbProductCategory.SelectedIndex = 0;
            pnlProductsTop.Controls.Add(_cmbProductCategory);

            AddProductLabel("Fiyat:", 635, 18, 55);
            _numProductPrice = AddProductNumber(695, 15, 130, 999999, 1);
            _numProductPrice.DecimalPlaces = 2;
            _numProductPrice.Increment = 10;

            AddProductLabel("Stok:", 20, 78, 85);
            _numProductStock = AddProductNumber(110, 75, 90, 10000, 0);

            AddProductLabel("Minimum Stok:", 230, 78, 130);
            _numProductMinimumStock = AddProductNumber(365, 75, 100, 10000, 0);

            _btnAddProduct = new Button
            {
                Left = 500,
                Top = 70,
                Width = 125,
                Height = 40,
                Text = "Ürün Ekle"
            };
            _btnAddProduct.Click += btnAddProduct_Click;
            pnlProductsTop.Controls.Add(_btnAddProduct);

            _btnUpdateProduct = new Button
            {
                Left = 645,
                Top = 70,
                Width = 185,
                Height = 40,
                Text = "Seçili Ürünü Güncelle"
            };
            _btnUpdateProduct.Click += btnUpdateProduct_Click;
            pnlProductsTop.Controls.Add(_btnUpdateProduct);

            btnLoadProducts.Left = 850;
            btnLoadProducts.Top = 70;
            btnLoadProducts.Width = 165;
            btnLoadProducts.Height = 40;
            btnLoadProducts.Text = "Ürünleri Listele";

            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            tabPage1.Resize += tabPage1_Resize;
            ArrangeProductsGrid();
        }

        private void AddProductLabel(string text, int left, int top, int width)
        {
            pnlProductsTop.Controls.Add(new Label
            {
                Left = left,
                Top = top + 4,
                Width = width,
                Height = 28,
                Text = text
            });
        }

        private TextBox AddProductTextBox(int left, int top, int width)
        {
            var textBox = new TextBox
            {
                Left = left,
                Top = top,
                Width = width
            };
            pnlProductsTop.Controls.Add(textBox);
            return textBox;
        }

        private NumericUpDown AddProductNumber(int left, int top, int width, int maximum, int minimum)
        {
            var number = new NumericUpDown
            {
                Left = left,
                Top = top,
                Width = width,
                Minimum = minimum,
                Maximum = maximum
            };
            pnlProductsTop.Controls.Add(number);
            return number;
        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {
            ArrangeProductsGrid();
        }

        private void ArrangeProductsGrid()
        {
            dgvProducts.Dock = DockStyle.None;
            dgvProducts.Left = 3;
            dgvProducts.Top = pnlProductsTop.Bottom + 6;
            dgvProducts.Width = tabPage1.ClientSize.Width - 6;
            dgvProducts.Height = tabPage1.ClientSize.Height - pnlProductsTop.Height - 12;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.BringToFront();
            pnlProductsTop.BringToFront();
        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.DataSource = _inventoryService.GetProducts();
                FormatProductsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Urunler listelenirken hata olustu: " + ex.Message);
            }
        }

        private void FormatProductsGrid()
        {
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvProducts.Columns["Id"] != null)
            {
                dgvProducts.Columns["Id"].Visible = false;
            }

            SetColumnHeader("Name", "Ürün Adı");
            SetColumnHeader("CategoryName", "Kategori");
            SetColumnHeader("UnitPrice", "Fiyat");
            SetColumnHeader("StockQuantity", "Stok");
            SetColumnHeader("MinimumStockQuantity", "Minimum Stok");

            if (dgvProducts.Columns["IsLowStock"] != null)
            {
                dgvProducts.Columns["IsLowStock"].Visible = false;
            }
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvProducts.Columns[columnName] != null)
            {
                dgvProducts.Columns[columnName].HeaderText = headerText;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _inventoryService.AddProduct(
                    _txtProductName.Text,
                    GetSelectedProductCategoryId(),
                    _numProductPrice.Value,
                    Convert.ToInt32(_numProductStock.Value),
                    Convert.ToInt32(_numProductMinimumStock.Value));

                MessageBox.Show("Ürün başarıyla eklendi.");
                ClearProductInputs();
                RefreshProductsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                var productId = GetSelectedProductId();
                if (productId == 0)
                {
                    MessageBox.Show("Lütfen güncellenecek ürünü tablodan seçin.");
                    return;
                }

                _inventoryService.UpdateProduct(
                    productId,
                    _txtProductName.Text,
                    GetSelectedProductCategoryId(),
                    _numProductPrice.Value,
                    Convert.ToInt32(_numProductStock.Value),
                    Convert.ToInt32(_numProductMinimumStock.Value));

                MessageBox.Show("Ürün başarıyla güncellendi.");
                RefreshProductsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün güncellenirken hata oluştu: " + ex.Message);
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            var product = dgvProducts.CurrentRow.DataBoundItem as InventorySalesSystem.Models.Product;
            if (product == null)
            {
                return;
            }

            _txtProductName.Text = product.Name;
            SelectProductCategory(product.CategoryName);
            _numProductPrice.Value = product.UnitPrice;
            _numProductStock.Value = product.StockQuantity;
            _numProductMinimumStock.Value = product.MinimumStockQuantity;
        }

        private int GetSelectedProductId()
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem == null)
            {
                return 0;
            }

            var product = dgvProducts.CurrentRow.DataBoundItem as InventorySalesSystem.Models.Product;
            return product == null ? 0 : product.Id;
        }

        private int GetSelectedProductCategoryId()
        {
            var category = _cmbProductCategory.SelectedItem as ProductCategoryItem;
            return category == null ? 1 : category.Id;
        }

        private void SelectProductCategory(string categoryName)
        {
            for (var i = 0; i < _cmbProductCategory.Items.Count; i++)
            {
                var category = _cmbProductCategory.Items[i] as ProductCategoryItem;
                if (category != null && string.Equals(category.Name, categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    _cmbProductCategory.SelectedIndex = i;
                    return;
                }
            }
        }

        private void RefreshProductsGrid()
        {
            dgvProducts.DataSource = _inventoryService.GetProducts();
            FormatProductsGrid();
        }

        private void ClearProductInputs()
        {
            _txtProductName.Clear();
            _cmbProductCategory.SelectedIndex = 0;
            _numProductPrice.Value = _numProductPrice.Minimum;
            _numProductStock.Value = 0;
            _numProductMinimumStock.Value = 0;
        }

        private void btnLoadCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCustomers.DataSource = _customerService.GetCustomers();
                FormatCustomersGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteriler listelenirken hata oluştu: " + ex.Message);
            }
        }
        private void FormatCustomersGrid()
        {
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvCustomers.Columns["Id"] != null)
            {
                dgvCustomers.Columns["Id"].Visible = false;
            }

            SetCustomerColumnHeader("FullName", "Ad Soyad");
            SetCustomerColumnHeader("Phone", "Telefon");
            SetCustomerColumnHeader("Email", "E-posta");
        }

        private void SetCustomerColumnHeader(string columnName, string headerText)
        {
            if (dgvCustomers.Columns[columnName] != null)
            {
                dgvCustomers.Columns[columnName].HeaderText = headerText;
            }
        }

        

        private void btnLoadSaleData_Click(object sender, EventArgs e)
        {
            try
            {
                cmbSaleCustomer.DataSource = _customerService.GetCustomers();
                cmbSaleCustomer.DisplayMember = "FullName";
                cmbSaleCustomer.ValueMember = "Id";

                cmbSaleProduct.DataSource = _inventoryService.GetProducts();
                cmbSaleProduct.DisplayMember = "Name";
                cmbSaleProduct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış verileri yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void btnCreateSale_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSaleCustomer.SelectedValue == null || cmbSaleProduct.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen müşteri ve ürün seçin.");
                    return;
                }

                var customerId = Convert.ToInt32(cmbSaleCustomer.SelectedValue);
                var productId = Convert.ToInt32(cmbSaleProduct.SelectedValue);
                var quantity = Convert.ToInt32(numSaleQuantity.Value);

                var saleId = _salesService.CreateSale(customerId, productId, quantity);

                MessageBox.Show("Satış başarıyla oluşturuldu. Satış No: " + saleId);

                dgvProducts.DataSource = _inventoryService.GetProducts();
                FormatProductsGrid();

                cmbSaleProduct.DataSource = _inventoryService.GetProducts();
                cmbSaleProduct.DisplayMember = "Name";
                cmbSaleProduct.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış yapılırken hata oluştu: " + ex.Message);
            }
        }

        private void btnLowStockReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.DataSource = _reportService.GetLowStockProducts();
                FormatReportsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Düşük stok raporu alınırken hata oluştu: " + ex.Message);
            }
        }

        private void btnTopProductsReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.DataSource = _reportService.GetTopProducts();
                FormatReportsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("En çok satılan ürünler alınırken hata oluştu: " + ex.Message);
            }
        }
        private void FormatReportsGrid()
        {
            dgvReports.RowHeadersVisible = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetReportColumnHeader("Id", "No");
            SetReportColumnHeader("Name", "Ürün Adı");
            SetReportColumnHeader("CategoryName", "Kategori");
            SetReportColumnHeader("UnitPrice", "Fiyat");
            SetReportColumnHeader("StockQuantity", "Stok");
            SetReportColumnHeader("MinimumStockQuantity", "Minimum Stok");
            SetReportColumnHeader("ProductName", "Ürün Adı");
            SetReportColumnHeader("TotalQuantity", "Toplam Adet");
            SetReportColumnHeader("TotalAmount", "Toplam Tutar");

            if (dgvReports.Columns["IsLowStock"] != null)
            {
                dgvReports.Columns["IsLowStock"].Visible = false;
            }
        }

        private void SetReportColumnHeader(string columnName, string headerText)
        {
            if (dgvReports.Columns[columnName] != null)
            {
                dgvReports.Columns[columnName].HeaderText = headerText;
            }
        }

        private class ProductCategoryItem
        {
            public ProductCategoryItem(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; }
            public string Name { get; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
