// Decompiled with JetBrains decompiler
// Type: GongziSimple.FrmProductStep
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using GongziSimple.gongziDataSetTableAdapters;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GongziSimple
{
  public class FrmProductStep : Form
  {
    private IContainer components;
    private DataGridView dataGridView1;
    private gongziDataSet gongziDataSet;
    private BindingSource productStepBindingSource;
    private ProductStepTableAdapter productStepTableAdapter;
    private BindingNavigator bindingNavigator1;
    private ToolStripButton bindingNavigatorAddNewItem;
    private ToolStripLabel bindingNavigatorCountItem;
    private ToolStripButton bindingNavigatorDeleteItem;
    private ToolStripButton bindingNavigatorMoveFirstItem;
    private ToolStripButton bindingNavigatorMovePreviousItem;
    private ToolStripSeparator bindingNavigatorSeparator;
    private ToolStripTextBox bindingNavigatorPositionItem;
    private ToolStripSeparator bindingNavigatorSeparator1;
    private ToolStripButton bindingNavigatorMoveNextItem;
    private ToolStripButton bindingNavigatorMoveLastItem;
    private ToolStripSeparator bindingNavigatorSeparator2;
    private ToolStripButton 保存SToolStripButton;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn prodnameDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn prodSpecDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step1DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step2DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step3DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step4DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step5DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step6DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step7DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step8DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step9DataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn step10;
    private DataGridViewTextBoxColumn memo;
    private ToolStripTextBox txtSpec;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripLabel toolStripLabel1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripLabel toolStripLabel2;
    private ToolStripTextBox txtProdName;
    private ToolStripButton btnExcel;
    private ToolStripProgressBar pb1;

    public FrmProductStep()
    {
      this.InitializeComponent();
    }

    private void FrmProductStep_Load(object sender, EventArgs e)
    {
      this.productStepTableAdapter.InitAptCmd();
      this.gongziDataSet.ProductStep.IDColumn.AutoIncrementSeed = Convert.ToInt64((object) this.productStepTableAdapter.Get_maxid());
      this.gongziDataSet.ProductStep.IDColumn.AutoIncrementStep = 1L;
      this.productStepTableAdapter.Fill(this.gongziDataSet.ProductStep);
    }

    private void 保存SToolStripButton_Click(object sender, EventArgs e)
    {
      this.bindingNavigatorPositionItem.Focus();
      this.productStepTableAdapter.Update(this.gongziDataSet);
    }

    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      if (e.ColumnIndex < 3)
        return;
      int num = (int) MessageBox.Show("您输入的数字格式不对，请重新输入！");
    }

    private void txtSpec_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.productStepTableAdapter.FillByProd_Spec(this.gongziDataSet.ProductStep, this.txtSpec.Text, this.txtProdName.Text);
    }

    private void btnExcel_Click(object sender, EventArgs e)
    {
      this.pb1.Visible = true;
      PubFunc.DataGridView2Excel(this.dataGridView1, "产品工种价格", this.pb1);
      this.pb1.Visible = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmProductStep));
      this.dataGridView1 = new DataGridView();
      this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.prodnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.prodSpecDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step3DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step4DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step5DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step6DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step7DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step8DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step9DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.step10 = new DataGridViewTextBoxColumn();
      this.memo = new DataGridViewTextBoxColumn();
      this.productStepBindingSource = new BindingSource(this.components);
      this.gongziDataSet = new gongziDataSet();
      this.bindingNavigator1 = new BindingNavigator(this.components);
      this.bindingNavigatorAddNewItem = new ToolStripButton();
      this.bindingNavigatorCountItem = new ToolStripLabel();
      this.bindingNavigatorDeleteItem = new ToolStripButton();
      this.bindingNavigatorMoveFirstItem = new ToolStripButton();
      this.bindingNavigatorMovePreviousItem = new ToolStripButton();
      this.bindingNavigatorSeparator = new ToolStripSeparator();
      this.bindingNavigatorPositionItem = new ToolStripTextBox();
      this.bindingNavigatorSeparator1 = new ToolStripSeparator();
      this.bindingNavigatorMoveNextItem = new ToolStripButton();
      this.bindingNavigatorMoveLastItem = new ToolStripButton();
      this.bindingNavigatorSeparator2 = new ToolStripSeparator();
      this.保存SToolStripButton = new ToolStripButton();
      this.btnExcel = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripLabel1 = new ToolStripLabel();
      this.txtSpec = new ToolStripTextBox();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripLabel2 = new ToolStripLabel();
      this.txtProdName = new ToolStripTextBox();
      this.pb1 = new ToolStripProgressBar();
      this.productStepTableAdapter = new ProductStepTableAdapter();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      ((ISupportInitialize) this.productStepBindingSource).BeginInit();
      this.gongziDataSet.BeginInit();
      this.bindingNavigator1.BeginInit();
      this.bindingNavigator1.SuspendLayout();
      this.SuspendLayout();
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn, (DataGridViewColumn) this.prodnameDataGridViewTextBoxColumn, (DataGridViewColumn) this.prodSpecDataGridViewTextBoxColumn, (DataGridViewColumn) this.step1DataGridViewTextBoxColumn, (DataGridViewColumn) this.step2DataGridViewTextBoxColumn, (DataGridViewColumn) this.step3DataGridViewTextBoxColumn, (DataGridViewColumn) this.step4DataGridViewTextBoxColumn, (DataGridViewColumn) this.step5DataGridViewTextBoxColumn, (DataGridViewColumn) this.step6DataGridViewTextBoxColumn, (DataGridViewColumn) this.step7DataGridViewTextBoxColumn, (DataGridViewColumn) this.step8DataGridViewTextBoxColumn, (DataGridViewColumn) this.step9DataGridViewTextBoxColumn, (DataGridViewColumn) this.step10, (DataGridViewColumn) this.memo);
      this.dataGridView1.DataSource = (object) this.productStepBindingSource;
      this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(0, 25);
      this.dataGridView1.Margin = new Padding(4);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 23;
      this.dataGridView1.Size = new Size(987, 589);
      this.dataGridView1.TabIndex = 1;
      this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.Visible = false;
      this.prodnameDataGridViewTextBoxColumn.DataPropertyName = "Prod_name";
      this.prodnameDataGridViewTextBoxColumn.HeaderText = "产品名称";
      this.prodnameDataGridViewTextBoxColumn.Name = "prodnameDataGridViewTextBoxColumn";
      this.prodSpecDataGridViewTextBoxColumn.DataPropertyName = "Prod_Spec";
      this.prodSpecDataGridViewTextBoxColumn.HeaderText = "产品型号";
      this.prodSpecDataGridViewTextBoxColumn.Name = "prodSpecDataGridViewTextBoxColumn";
      this.step1DataGridViewTextBoxColumn.DataPropertyName = "step1";
      this.step1DataGridViewTextBoxColumn.HeaderText = "木工";
      this.step1DataGridViewTextBoxColumn.Name = "step1DataGridViewTextBoxColumn";
      this.step2DataGridViewTextBoxColumn.DataPropertyName = "step2";
      this.step2DataGridViewTextBoxColumn.HeaderText = "介棉";
      this.step2DataGridViewTextBoxColumn.Name = "step2DataGridViewTextBoxColumn";
      this.step3DataGridViewTextBoxColumn.DataPropertyName = "step3";
      this.step3DataGridViewTextBoxColumn.HeaderText = "贴棉";
      this.step3DataGridViewTextBoxColumn.Name = "step3DataGridViewTextBoxColumn";
      this.step4DataGridViewTextBoxColumn.DataPropertyName = "step4";
      this.step4DataGridViewTextBoxColumn.HeaderText = "裁皮";
      this.step4DataGridViewTextBoxColumn.Name = "step4DataGridViewTextBoxColumn";
      this.step5DataGridViewTextBoxColumn.DataPropertyName = "step5";
      this.step5DataGridViewTextBoxColumn.HeaderText = "车皮";
      this.step5DataGridViewTextBoxColumn.Name = "step5DataGridViewTextBoxColumn";
      this.step6DataGridViewTextBoxColumn.DataPropertyName = "step6";
      this.step6DataGridViewTextBoxColumn.HeaderText = "压线";
      this.step6DataGridViewTextBoxColumn.Name = "step6DataGridViewTextBoxColumn";
      this.step7DataGridViewTextBoxColumn.DataPropertyName = "step7";
      this.step7DataGridViewTextBoxColumn.HeaderText = "扪皮";
      this.step7DataGridViewTextBoxColumn.Name = "step7DataGridViewTextBoxColumn";
      this.step8DataGridViewTextBoxColumn.DataPropertyName = "step8";
      this.step8DataGridViewTextBoxColumn.HeaderText = "安装";
      this.step8DataGridViewTextBoxColumn.Name = "step8DataGridViewTextBoxColumn";
      this.step9DataGridViewTextBoxColumn.DataPropertyName = "step9";
      this.step9DataGridViewTextBoxColumn.HeaderText = "包装";
      this.step9DataGridViewTextBoxColumn.Name = "step9DataGridViewTextBoxColumn";
      this.step10.DataPropertyName = "step10";
      this.step10.HeaderText = "厚皮贴皮";
      this.step10.Name = "step10";
      this.memo.DataPropertyName = "memo";
      this.memo.HeaderText = "备注";
      this.memo.Name = "memo";
      this.productStepBindingSource.DataMember = "ProductStep";
      this.productStepBindingSource.DataSource = (object) this.gongziDataSet;
      this.gongziDataSet.DataSetName = "gongziDataSet";
      this.gongziDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.bindingNavigator1.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bindingNavigator1.BindingSource = this.productStepBindingSource;
      this.bindingNavigator1.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bindingNavigator1.DeleteItem = (ToolStripItem) this.bindingNavigatorDeleteItem;
      this.bindingNavigator1.Items.AddRange(new ToolStripItem[20]
      {
        (ToolStripItem) this.bindingNavigatorMoveFirstItem,
        (ToolStripItem) this.bindingNavigatorMovePreviousItem,
        (ToolStripItem) this.bindingNavigatorSeparator,
        (ToolStripItem) this.bindingNavigatorPositionItem,
        (ToolStripItem) this.bindingNavigatorCountItem,
        (ToolStripItem) this.bindingNavigatorSeparator1,
        (ToolStripItem) this.bindingNavigatorMoveNextItem,
        (ToolStripItem) this.bindingNavigatorMoveLastItem,
        (ToolStripItem) this.bindingNavigatorSeparator2,
        (ToolStripItem) this.bindingNavigatorAddNewItem,
        (ToolStripItem) this.bindingNavigatorDeleteItem,
        (ToolStripItem) this.保存SToolStripButton,
        (ToolStripItem) this.btnExcel,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripLabel1,
        (ToolStripItem) this.txtSpec,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripLabel2,
        (ToolStripItem) this.txtProdName,
        (ToolStripItem) this.pb1
      });
      this.bindingNavigator1.Location = new Point(0, 0);
      this.bindingNavigator1.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bindingNavigator1.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bindingNavigator1.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bindingNavigator1.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bindingNavigator1.Name = "bindingNavigator1";
      this.bindingNavigator1.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bindingNavigator1.Size = new Size(987, 25);
      this.bindingNavigator1.TabIndex = 2;
      this.bindingNavigator1.Text = "bindingNavigator1";
      this.bindingNavigatorAddNewItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorAddNewItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorAddNewItem.Image");
      this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
      this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorAddNewItem.Size = new Size(23, 22);
      this.bindingNavigatorAddNewItem.Text = "新添";
      this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
      this.bindingNavigatorCountItem.Size = new Size(32, 22);
      this.bindingNavigatorCountItem.Text = "/ {0}";
      this.bindingNavigatorCountItem.ToolTipText = "总项数";
      this.bindingNavigatorDeleteItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorDeleteItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorDeleteItem.Image");
      this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
      this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorDeleteItem.Size = new Size(23, 22);
      this.bindingNavigatorDeleteItem.Text = "删除";
      this.bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveFirstItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveFirstItem.Image");
      this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
      this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveFirstItem.Size = new Size(23, 22);
      this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
      this.bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMovePreviousItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMovePreviousItem.Image");
      this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
      this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMovePreviousItem.Size = new Size(23, 22);
      this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
      this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
      this.bindingNavigatorSeparator.Size = new Size(6, 25);
      this.bindingNavigatorPositionItem.AccessibleName = "位置";
      this.bindingNavigatorPositionItem.AutoSize = false;
      this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
      this.bindingNavigatorPositionItem.Size = new Size(65, 23);
      this.bindingNavigatorPositionItem.Text = "0";
      this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
      this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
      this.bindingNavigatorSeparator1.Size = new Size(6, 25);
      this.bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveNextItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveNextItem.Image");
      this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
      this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveNextItem.Size = new Size(23, 22);
      this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
      this.bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.bindingNavigatorMoveLastItem.Image = (Image) componentResourceManager.GetObject("bindingNavigatorMoveLastItem.Image");
      this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
      this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
      this.bindingNavigatorMoveLastItem.Size = new Size(23, 22);
      this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
      this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
      this.bindingNavigatorSeparator2.Size = new Size(6, 25);
      this.保存SToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.保存SToolStripButton.Image = (Image) componentResourceManager.GetObject("保存SToolStripButton.Image");
      this.保存SToolStripButton.ImageTransparentColor = Color.Magenta;
      this.保存SToolStripButton.Name = "保存SToolStripButton";
      this.保存SToolStripButton.Size = new Size(23, 22);
      this.保存SToolStripButton.Text = "保存(&S)";
      this.保存SToolStripButton.Click += new EventHandler(this.保存SToolStripButton_Click);
      this.btnExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnExcel.Image = (Image) componentResourceManager.GetObject("btnExcel.Image");
      this.btnExcel.ImageTransparentColor = Color.Magenta;
      this.btnExcel.Name = "btnExcel";
      this.btnExcel.Size = new Size(23, 22);
      this.btnExcel.Text = "导出Excel";
      this.btnExcel.Click += new EventHandler(this.btnExcel_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new Size(32, 22);
      this.toolStripLabel1.Text = "型号";
      this.txtSpec.AcceptsReturn = true;
      this.txtSpec.BorderStyle = BorderStyle.FixedSingle;
      this.txtSpec.Name = "txtSpec";
      this.txtSpec.Size = new Size(133, 25);
      this.txtSpec.ToolTipText = "输入型号，后查询请按回车";
      this.txtSpec.KeyUp += new KeyEventHandler(this.txtSpec_KeyUp);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new Size(32, 22);
      this.toolStripLabel2.Text = "产品";
      this.txtProdName.BorderStyle = BorderStyle.FixedSingle;
      this.txtProdName.Name = "txtProdName";
      this.txtProdName.Size = new Size(133, 25);
      this.txtProdName.KeyUp += new KeyEventHandler(this.txtSpec_KeyUp);
      this.pb1.Name = "pb1";
      this.pb1.Size = new Size(133, 29);
      this.pb1.Visible = false;
      this.productStepTableAdapter.ClearBeforeFill = true;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(987, 614);
      this.Controls.Add((Control) this.dataGridView1);
      this.Controls.Add((Control) this.bindingNavigator1);
      this.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Margin = new Padding(4);
      this.Name = "FrmProductStep";
      this.Text = "产品工序配置";
      this.Load += new EventHandler(this.FrmProductStep_Load);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      ((ISupportInitialize) this.productStepBindingSource).EndInit();
      this.gongziDataSet.EndInit();
      this.bindingNavigator1.EndInit();
      this.bindingNavigator1.ResumeLayout(false);
      this.bindingNavigator1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
