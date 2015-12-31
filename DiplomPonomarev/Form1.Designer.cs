
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DiplomPonomarev
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.структураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анімаціяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGenData = new System.Windows.Forms.ToolStripButton();
            this.btnAddElements = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveElements = new System.Windows.Forms.ToolStripButton();
            this.btnRandomize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSortAsc = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnSortDesc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbStruct = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSortType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.graphicsComponent = new GraphicsComponent.GraphicsComponent();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.структураToolStripMenuItem,
            this.сортуванняToolStripMenuItem,
            this.анімаціяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // структураToolStripMenuItem
            // 
            this.структураToolStripMenuItem.Name = "структураToolStripMenuItem";
            this.структураToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.структураToolStripMenuItem.Text = "Структура";
            // 
            // сортуванняToolStripMenuItem
            // 
            this.сортуванняToolStripMenuItem.Name = "сортуванняToolStripMenuItem";
            this.сортуванняToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.сортуванняToolStripMenuItem.Text = "Сортування";
            // 
            // анімаціяToolStripMenuItem
            // 
            this.анімаціяToolStripMenuItem.Name = "анімаціяToolStripMenuItem";
            this.анімаціяToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.анімаціяToolStripMenuItem.Text = "Анімація";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenData,
            this.btnAddElements,
            this.btnRemoveElements,
            this.btnRandomize,
            this.toolStripSeparator1,
            this.btnSortAsc,
            this.toolStripButton1,
            this.btnSortDesc,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.cmbStruct,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cmbSortType,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(828, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGenData
            // 
            this.btnGenData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGenData.Image = ((System.Drawing.Image)(resources.GetObject("btnGenData.Image")));
            this.btnGenData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenData.Name = "btnGenData";
            this.btnGenData.Size = new System.Drawing.Size(23, 22);
            this.btnGenData.Text = "toolStripButton6";
            // 
            // btnAddElements
            // 
            this.btnAddElements.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddElements.Image = ((System.Drawing.Image)(resources.GetObject("btnAddElements.Image")));
            this.btnAddElements.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddElements.Name = "btnAddElements";
            this.btnAddElements.Size = new System.Drawing.Size(23, 22);
            this.btnAddElements.Text = "toolStripButton1";
            this.btnAddElements.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnRemoveElements
            // 
            this.btnRemoveElements.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveElements.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveElements.Image")));
            this.btnRemoveElements.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveElements.Name = "btnRemoveElements";
            this.btnRemoveElements.Size = new System.Drawing.Size(23, 22);
            this.btnRemoveElements.Text = "toolStripButton2";
            this.btnRemoveElements.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnRandomize
            // 
            this.btnRandomize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRandomize.Image = ((System.Drawing.Image)(resources.GetObject("btnRandomize.Image")));
            this.btnRandomize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(23, 22);
            this.btnRandomize.Text = "toolStripButton3";
            this.btnRandomize.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSortAsc.Image = ((System.Drawing.Image)(resources.GetObject("btnSortAsc.Image")));
            this.btnSortAsc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(23, 22);
            this.btnSortAsc.Text = "toolStripButton4";
            this.btnSortAsc.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSortDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnSortDesc.Image")));
            this.btnSortDesc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(23, 22);
            this.btnSortDesc.Text = "toolStripButton5";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel2.Text = "Структура:";
            // 
            // cmbStruct
            // 
            this.cmbStruct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStruct.Items.AddRange(new object[] {
            "Стек",
            "Черга",
            "Список"});
            this.cmbStruct.Name = "cmbStruct";
            this.cmbStruct.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel1.Text = "Сортування:";
            // 
            // cmbSortType
            // 
            this.cmbSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortType.Items.AddRange(new object[] {
            "Блочне",
            "Бульбашками",
            "Вставками",
            "Швидке",
            "Шелла"});
            this.cmbSortType.Name = "cmbSortType";
            this.cmbSortType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel3.Text = "Швидкість:";
            // 
            // pnlDevice
            // 
            this.pnlDevice.Controls.Add(this.statusStrip1);
            this.pnlDevice.Controls.Add(this.elementHost1);
            this.pnlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDevice.Location = new System.Drawing.Point(0, 49);
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(828, 409);
            this.pnlDevice.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(828, 409);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.graphicsComponent;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 458);
            this.Controls.Add(this.pnlDevice);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Візуалізація структур даних";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlDevice.ResumeLayout(false);
            this.pnlDevice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddElements;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private GraphicsComponent.GraphicsComponent graphicsComponent;
        private System.Windows.Forms.ToolStripButton btnRemoveElements;
        private System.Windows.Forms.ToolStripButton btnRandomize;
        private System.Windows.Forms.ToolStripButton btnSortAsc;
        private System.Windows.Forms.ToolStripButton btnGenData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSortDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cmbStruct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbSortType;
        private System.Windows.Forms.ToolStripMenuItem структураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анімаціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private ToolStripButton toolStripButton2;

    }
}

