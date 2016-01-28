
using System;
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
            this.cmbDestPush = new System.Windows.Forms.ToolStripComboBox();
            this.btnAddElements = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveElements = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRandomize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSortAsc = new System.Windows.Forms.ToolStripButton();
            this.btnStopSort = new System.Windows.Forms.ToolStripButton();
            this.btnSortDesc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbStructType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSortType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.lblSpeed = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.graphicsComponent = new GraphicsComponent.GraphicsComponent();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDestPop = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
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
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
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
            this.toolStripLabel4,
            this.cmbDestPush,
            this.btnAddElements,
            this.toolStripSeparator6,
            this.toolStripLabel5,
            this.cmbDestPop,
            this.btnRemoveElements,
            this.toolStripSeparator5,
            this.btnRandomize,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.cmbStructType,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.cmbSortType,
            this.btnSortAsc,
            this.btnStopSort,
            this.btnSortDesc,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.toolStripButton2,
            this.lblSpeed,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmbDestPush
            // 
            this.cmbDestPush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestPush.Items.AddRange(new object[] {
            "head",
            "tail"});
            this.cmbDestPush.Name = "cmbDestPush";
            this.cmbDestPush.Size = new System.Drawing.Size(75, 25);
            this.cmbDestPush.Text = "head";
            this.cmbDestPush.SelectedIndexChanged += new System.EventHandler(this.cmbDestPush_SelectedIndexChanged);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            // btnStopSort
            // 
            this.btnStopSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopSort.Image = ((System.Drawing.Image)(resources.GetObject("btnStopSort.Image")));
            this.btnStopSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopSort.Name = "btnStopSort";
            this.btnStopSort.Size = new System.Drawing.Size(23, 22);
            this.btnStopSort.Text = "toolStripButton1";
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSortDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnSortDesc.Image")));
            this.btnSortDesc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(23, 22);
            this.btnSortDesc.Text = "toolStripButton5";
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
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
            // cmbStructType
            // 
            this.cmbStructType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStructType.Items.AddRange(new object[] {
            "Стек",
            "Черга",
            "Список"});
            this.cmbStructType.Name = "cmbStructType";
            this.cmbStructType.Size = new System.Drawing.Size(75, 25);
            this.cmbStructType.SelectedIndexChanged += new System.EventHandler(this.cmbStruct_SelectedIndexChanged);
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
            "Бульбашками",
            "Вставками",
            "Швидке"});
            this.cmbSortType.Name = "cmbSortType";
            this.cmbSortType.Size = new System.Drawing.Size(110, 25);
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
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = false;
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(40, 22);
            this.lblSpeed.Text = "1x";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // pnlDevice
            // 
            this.pnlDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDevice.Controls.Add(this.elementHost1);
            this.pnlDevice.Location = new System.Drawing.Point(0, 49);
            this.pnlDevice.Name = "pnlDevice";
            this.pnlDevice.Size = new System.Drawing.Size(984, 387);
            this.pnlDevice.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(3, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(978, 381);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.graphicsComponent;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel4.Text = "Вставити в:";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel5.Text = "Видалити з:";
            // 
            // cmbDestPop
            // 
            this.cmbDestPop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestPop.Items.AddRange(new object[] {
            "head",
            "tail"});
            this.cmbDestPop.Name = "cmbDestPop";
            this.cmbDestPop.Size = new System.Drawing.Size(75, 25);
            this.cmbDestPop.SelectedIndexChanged += new System.EventHandler(this.cmbDestPop_SelectedIndexChanged);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlDevice);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Візуалізація структур даних";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlDevice.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSortDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cmbStructType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbSortType;
        private System.Windows.Forms.ToolStripMenuItem структураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem анімаціяToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnStopSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripButton2;
        private ToolStripLabel lblSpeed;
        private ToolStripButton toolStripButton3;
        private StatusStrip statusStrip1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripComboBox cmbDestPush;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripLabel toolStripLabel5;
        private ToolStripComboBox cmbDestPop;

    }
}

