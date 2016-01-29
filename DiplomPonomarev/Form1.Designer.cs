
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
            this.miPush = new System.Windows.Forms.ToolStripMenuItem();
            this.mi = new System.Windows.Forms.ToolStripMenuItem();
            this.miPushHead = new System.Windows.Forms.ToolStripMenuItem();
            this.miPushTail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.miPop = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиЗToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPopHead = new System.Windows.Forms.ToolStripMenuItem();
            this.miPopTail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAmount = new System.Windows.Forms.ToolStripTextBox();
            this.значенняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miValue = new System.Windows.Forms.ToolStripMenuItem();
            this.tbValue = new System.Windows.Forms.ToolStripTextBox();
            this.miRandomize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.структураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDestPush = new System.Windows.Forms.ToolStripComboBox();
            this.btnPush = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDestPop = new System.Windows.Forms.ToolStripComboBox();
            this.btnPop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRandomize = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbStructType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbSortType = new System.Windows.Forms.ToolStripComboBox();
            this.btnSortAsc = new System.Windows.Forms.ToolStripButton();
            this.btnStopSort = new System.Windows.Forms.ToolStripButton();
            this.btnSortDesc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.lblSpeed = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pnlDevice = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.graphicsComponent = new GraphicsComponent.GraphicsComponent();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.miStructStack = new System.Windows.Forms.ToolStripMenuItem();
            this.miStructQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.miStructList = new System.Windows.Forms.ToolStripMenuItem();
            this.miSortBubble = new System.Windows.Forms.ToolStripMenuItem();
            this.miSortInsertion = new System.Windows.Forms.ToolStripMenuItem();
            this.miSortQuick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miSortAsc = new System.Windows.Forms.ToolStripMenuItem();
            this.miSortDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.miSortStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPush,
            this.mi,
            this.toolStripSeparator7,
            this.miPop,
            this.видалитиЗToolStripMenuItem,
            this.toolStripSeparator8,
            this.toolStripMenuItem1,
            this.значенняToolStripMenuItem,
            this.miRandomize,
            this.toolStripSeparator9,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // miPush
            // 
            this.miPush.Name = "miPush";
            this.miPush.Size = new System.Drawing.Size(190, 22);
            this.miPush.Text = "Вставити елемент(и)";
            this.miPush.Click += new System.EventHandler(this.miPush_Click);
            // 
            // mi
            // 
            this.mi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPushHead,
            this.miPushTail});
            this.mi.Name = "mi";
            this.mi.Size = new System.Drawing.Size(190, 22);
            this.mi.Text = "Вставити в";
            // 
            // miPushHead
            // 
            this.miPushHead.Checked = true;
            this.miPushHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miPushHead.Enabled = false;
            this.miPushHead.Name = "miPushHead";
            this.miPushHead.Size = new System.Drawing.Size(152, 22);
            this.miPushHead.Text = "head";
            this.miPushHead.Click += new System.EventHandler(this.miPushHead_Click);
            // 
            // miPushTail
            // 
            this.miPushTail.Enabled = false;
            this.miPushTail.Name = "miPushTail";
            this.miPushTail.Size = new System.Drawing.Size(152, 22);
            this.miPushTail.Text = "tail";
            this.miPushTail.Click += new System.EventHandler(this.miPushTail_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(187, 6);
            // 
            // miPop
            // 
            this.miPop.Name = "miPop";
            this.miPop.Size = new System.Drawing.Size(190, 22);
            this.miPop.Text = "Видалити елемент(и)";
            this.miPop.Click += new System.EventHandler(this.miPop_Click);
            // 
            // видалитиЗToolStripMenuItem
            // 
            this.видалитиЗToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPopHead,
            this.miPopTail});
            this.видалитиЗToolStripMenuItem.Name = "видалитиЗToolStripMenuItem";
            this.видалитиЗToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.видалитиЗToolStripMenuItem.Text = "Видалити з";
            // 
            // miPopHead
            // 
            this.miPopHead.Checked = true;
            this.miPopHead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miPopHead.Enabled = false;
            this.miPopHead.Name = "miPopHead";
            this.miPopHead.Size = new System.Drawing.Size(152, 22);
            this.miPopHead.Text = "head";
            this.miPopHead.Click += new System.EventHandler(this.miPopHead_Click);
            // 
            // miPopTail
            // 
            this.miPopTail.Enabled = false;
            this.miPopTail.Name = "miPopTail";
            this.miPopTail.Size = new System.Drawing.Size(152, 22);
            this.miPopTail.Text = "tail";
            this.miPopTail.Click += new System.EventHandler(this.miPopTail_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAmount,
            this.tbAmount});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem1.Text = "Кількість";
            // 
            // miAmount
            // 
            this.miAmount.Checked = true;
            this.miAmount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miAmount.Name = "miAmount";
            this.miAmount.Size = new System.Drawing.Size(160, 22);
            this.miAmount.Text = "Автоматично";
            this.miAmount.CheckedChanged += new System.EventHandler(this.miAmount_CheckedChanged);
            // 
            // tbAmount
            // 
            this.tbAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAmount.MaxLength = 2;
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 23);
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // значенняToolStripMenuItem
            // 
            this.значенняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miValue,
            this.tbValue});
            this.значенняToolStripMenuItem.Name = "значенняToolStripMenuItem";
            this.значенняToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.значенняToolStripMenuItem.Text = "Значення";
            // 
            // miValue
            // 
            this.miValue.Checked = true;
            this.miValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miValue.Name = "miValue";
            this.miValue.Size = new System.Drawing.Size(160, 22);
            this.miValue.Text = "Випадково";
            this.miValue.CheckedChanged += new System.EventHandler(this.miValue_CheckedChanged);
            // 
            // tbValue
            // 
            this.tbValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbValue.MaxLength = 2;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(100, 23);
            this.tbValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValue_KeyPress);
            this.tbValue.TextChanged += new System.EventHandler(this.tbValue_TextChanged);
            // 
            // miRandomize
            // 
            this.miRandomize.Name = "miRandomize";
            this.miRandomize.Size = new System.Drawing.Size(190, 22);
            this.miRandomize.Text = "Оновити випадково";
            this.miRandomize.Click += new System.EventHandler(this.miRandomize_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(187, 6);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.вихідToolStripMenuItem.Text = "Вихід";
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);
            // 
            // структураToolStripMenuItem
            // 
            this.структураToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStructStack,
            this.miStructQueue,
            this.miStructList});
            this.структураToolStripMenuItem.Name = "структураToolStripMenuItem";
            this.структураToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.структураToolStripMenuItem.Text = "Структура";
            // 
            // сортуванняToolStripMenuItem
            // 
            this.сортуванняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSortBubble,
            this.miSortInsertion,
            this.miSortQuick,
            this.toolStripSeparator2,
            this.miSortAsc,
            this.miSortDesc,
            this.toolStripSeparator10,
            this.miSortStop});
            this.сортуванняToolStripMenuItem.Name = "сортуванняToolStripMenuItem";
            this.сортуванняToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.сортуванняToolStripMenuItem.Text = "Сортування";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.cmbDestPush,
            this.btnPush,
            this.toolStripSeparator6,
            this.toolStripLabel5,
            this.cmbDestPop,
            this.btnPop,
            this.toolStripSeparator5,
            this.btnRandomize,
            this.toolStripSeparator1,
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
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel4.Text = "Вставити в:";
            // 
            // cmbDestPush
            // 
            this.cmbDestPush.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestPush.Items.AddRange(new object[] {
            "head",
            "tail"});
            this.cmbDestPush.Name = "cmbDestPush";
            this.cmbDestPush.Size = new System.Drawing.Size(75, 25);
            this.cmbDestPush.SelectedIndexChanged += new System.EventHandler(this.cmbDestPush_SelectedIndexChanged);
            // 
            // btnPush
            // 
            this.btnPush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPush.Image = ((System.Drawing.Image)(resources.GetObject("btnPush.Image")));
            this.btnPush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(23, 22);
            this.btnPush.Text = "toolStripButton1";
            this.btnPush.ToolTipText = "Вставити елементи";
            this.btnPush.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // btnPop
            // 
            this.btnPop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPop.Image = ((System.Drawing.Image)(resources.GetObject("btnPop.Image")));
            this.btnPop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPop.Name = "btnPop";
            this.btnPop.Size = new System.Drawing.Size(23, 22);
            this.btnPop.Text = "toolStripButton2";
            this.btnPop.ToolTipText = "Видалити елементи";
            this.btnPop.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            this.btnRandomize.ToolTipText = "Оновити випадковими значеннями";
            this.btnRandomize.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.cmbSortType.SelectedIndexChanged += new System.EventHandler(this.cmbSortType_SelectedIndexChanged);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSortAsc.Image = ((System.Drawing.Image)(resources.GetObject("btnSortAsc.Image")));
            this.btnSortAsc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(23, 22);
            this.btnSortAsc.Text = "toolStripButton4";
            this.btnSortAsc.ToolTipText = "Сортувати за зростанням";
            this.btnSortAsc.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // btnStopSort
            // 
            this.btnStopSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopSort.Enabled = false;
            this.btnStopSort.Image = ((System.Drawing.Image)(resources.GetObject("btnStopSort.Image")));
            this.btnStopSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopSort.Name = "btnStopSort";
            this.btnStopSort.Size = new System.Drawing.Size(23, 22);
            this.btnStopSort.Text = "toolStripButton1";
            this.btnStopSort.ToolTipText = "Зупинити сортування";
            this.btnStopSort.Click += new System.EventHandler(this.btnStopSort_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSortDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnSortDesc.Image")));
            this.btnSortDesc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(23, 22);
            this.btnSortDesc.Text = "toolStripButton5";
            this.btnSortDesc.ToolTipText = "Сортувати за спаданням";
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
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
            this.toolStripButton2.ToolTipText = "Зменшити швидкість анімації";
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
            this.toolStripButton3.ToolTipText = "Збільшити швидкість анімації";
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // miStructStack
            // 
            this.miStructStack.Checked = true;
            this.miStructStack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miStructStack.Name = "miStructStack";
            this.miStructStack.Size = new System.Drawing.Size(152, 22);
            this.miStructStack.Text = "Стек";
            this.miStructStack.Click += new System.EventHandler(this.miStructStack_Click);
            // 
            // miStructQueue
            // 
            this.miStructQueue.Name = "miStructQueue";
            this.miStructQueue.Size = new System.Drawing.Size(152, 22);
            this.miStructQueue.Text = "Черга";
            this.miStructQueue.Click += new System.EventHandler(this.miStructQueue_Click);
            // 
            // miStructList
            // 
            this.miStructList.Name = "miStructList";
            this.miStructList.Size = new System.Drawing.Size(152, 22);
            this.miStructList.Text = "Список";
            this.miStructList.Click += new System.EventHandler(this.miStructList_Click);
            // 
            // miSortBubble
            // 
            this.miSortBubble.Checked = true;
            this.miSortBubble.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miSortBubble.Name = "miSortBubble";
            this.miSortBubble.Size = new System.Drawing.Size(155, 22);
            this.miSortBubble.Text = "Бульбашками";
            this.miSortBubble.Click += new System.EventHandler(this.miSortBubble_Click);
            // 
            // miSortInsertion
            // 
            this.miSortInsertion.Name = "miSortInsertion";
            this.miSortInsertion.Size = new System.Drawing.Size(155, 22);
            this.miSortInsertion.Text = "Вставками";
            this.miSortInsertion.Click += new System.EventHandler(this.miSortInsertion_Click);
            // 
            // miSortQuick
            // 
            this.miSortQuick.Name = "miSortQuick";
            this.miSortQuick.Size = new System.Drawing.Size(155, 22);
            this.miSortQuick.Text = "Швидке";
            this.miSortQuick.Click += new System.EventHandler(this.miSortQuick_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // miSortAsc
            // 
            this.miSortAsc.Name = "miSortAsc";
            this.miSortAsc.Size = new System.Drawing.Size(155, 22);
            this.miSortAsc.Text = "За зростанням";
            this.miSortAsc.Click += new System.EventHandler(this.miSortAsc_Click);
            // 
            // miSortDesc
            // 
            this.miSortDesc.Name = "miSortDesc";
            this.miSortDesc.Size = new System.Drawing.Size(155, 22);
            this.miSortDesc.Text = "За спаданням";
            this.miSortDesc.Click += new System.EventHandler(this.miSortDesc_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(152, 6);
            // 
            // miSortStop
            // 
            this.miSortStop.Enabled = false;
            this.miSortStop.Name = "miSortStop";
            this.miSortStop.Size = new System.Drawing.Size(155, 22);
            this.miSortStop.Text = "Зупинити";
            this.miSortStop.Click += new System.EventHandler(this.miSortStop_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            this.toolStripMenuItem2.Visible = false;
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ToolStripButton btnPush;
        private System.Windows.Forms.Panel pnlDevice;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private GraphicsComponent.GraphicsComponent graphicsComponent;
        private System.Windows.Forms.ToolStripButton btnPop;
        private System.Windows.Forms.ToolStripButton btnRandomize;
        private System.Windows.Forms.ToolStripButton btnSortAsc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSortDesc;
        private System.Windows.Forms.ToolStripComboBox cmbStructType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbSortType;
        private System.Windows.Forms.ToolStripMenuItem структураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуванняToolStripMenuItem;
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
        private ToolStripMenuItem miPush;
        private ToolStripMenuItem mi;
        private ToolStripMenuItem miPushHead;
        private ToolStripMenuItem miPushTail;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem miPop;
        private ToolStripMenuItem видалитиЗToolStripMenuItem;
        private ToolStripMenuItem miPopHead;
        private ToolStripMenuItem miPopTail;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem miAmount;
        private ToolStripTextBox tbAmount;
        private ToolStripMenuItem значенняToolStripMenuItem;
        private ToolStripMenuItem miValue;
        private ToolStripTextBox tbValue;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem вихідToolStripMenuItem;
        private ToolStripMenuItem miRandomize;
        private ToolStripMenuItem miStructStack;
        private ToolStripMenuItem miStructQueue;
        private ToolStripMenuItem miStructList;
        private ToolStripMenuItem miSortBubble;
        private ToolStripMenuItem miSortInsertion;
        private ToolStripMenuItem miSortQuick;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem miSortAsc;
        private ToolStripMenuItem miSortDesc;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem miSortStop;
        private ToolStripMenuItem toolStripMenuItem2;

    }
}

