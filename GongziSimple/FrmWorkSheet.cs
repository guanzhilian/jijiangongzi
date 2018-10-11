// Decompiled with JetBrains decompiler
// Type: GongziSimple.FrmWorkSheet
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using GongziSimple.gongziDataSetTableAdapters;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace GongziSimple
{
  public class FrmWorkSheet : Form
  {
    private AutoCompleteStringCollection filterVals;
    private object LastActHeadObj;
    private IContainer components;
    private GroupBox groupBox1;
    private Button btnSearch;
    private ComboBox cmbStep;
    private TextBox txtName;
    private Label label3;
    private Label label1;
    private Label label2;
    private DateTimePicker dateTimePicker1;
    private GroupBox groupBox2;
    private gongziDataSet gongziDataSet;
    private work_sheet_lineTableAdapter work_sheet_lineTableAdapter;
    private work_sheet_headTableAdapter work_sheet_headTableAdapter;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private DataGridView dgWorkLine;
    private TabPage tabPage2;
    private DataGridView dgHead;
    private Panel panel1;
    private TextBox textBox3;
    private Label label7;
    private ComboBox cmbStepName;
    private Label label6;
    private TextBox txtWorker;
    private Label label5;
    private Label label4;
    private DateTimePicker dtpWorkDate;
    private BindingNavigator bsNav;
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
    private ToolStripButton btnSave;
    private BindingSource head_bs;
    private BindingSource line_bs;
    private ToolStripButton btnExcel;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn workdateDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn workerDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn prodStepDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn deptDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn modifydateDataGridViewTextBoxColumn;
    private Button button1;
    private DataGridViewTextBoxColumn sumDVCol;
    private ToolStripButton btnRpt;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripProgressBar pbCalc;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn seq;
    private DataGridViewTextBoxColumn prodspecDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn batchcodeDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn headidDataGridViewTextBoxColumn;
    private ToolStripButton btnCancel;

    public FrmWorkSheet()
    {
      this.InitializeComponent();
    }

    private void FrmWorkSheet_Load(object sender, EventArgs e)
    {
      this.work_sheet_headTableAdapter.InitAptCmd();
      this.work_sheet_lineTableAdapter.InitAptCmd();
      this.work_sheet_headTableAdapter.FillTop30(this.gongziDataSet.work_sheet_head);
      this.BuildAutoCompleteList();
      this.dgWorkLine.AllowUserToAddRows = this.gongziDataSet.work_sheet_head.Count > 0;
    }

    private void BuildAutoCompleteList()
    {
      DataTable dataTable = this.gongziDataSet.QueryData("select prod_spec from ProductStep");
      this.filterVals = new AutoCompleteStringCollection();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        this.filterVals.Add(row["prod_spec"].ToString());
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      string str = "select * from work_sheet_head where 1=1 and work_date='" + this.dateTimePicker1.Text + "'";
      if (this.txtName.Text != "")
        str += string.Format(" and worker like '%{0}%'", (object) this.txtName.Text);
      if (this.cmbStep.SelectedIndex >= 0)
        str += string.Format(" and Prod_Step = '{0}'", (object) this.cmbStep.Text);
      this.work_sheet_headTableAdapter.Fill(this.gongziDataSet.work_sheet_head, new OleDbCommand(str + " order by modify_date desc", this.work_sheet_headTableAdapter.Connection));
      this.dgWorkLine.AllowUserToAddRows = this.gongziDataSet.work_sheet_head.Count > 0;
    }

    private void worksheetheadBindingSource_CurrentChanged(object sender, EventArgs e)
    {
      if (this.head_bs.Current == null)
      {
        this.gongziDataSet.work_sheet_line.Clear();
        this.line_bs.ResetBindings(true);
      }
      else
      {
        if (this.head_bs.Current == this.LastActHeadObj)
          return;
        this.LastActHeadObj = this.head_bs.Current;
        DataRowView current = this.head_bs.Current as DataRowView;
        DataRow row = current.Row;
        this.work_sheet_lineTableAdapter.FillByHeadId(this.gongziDataSet.work_sheet_line, current.Row[0].ToString());
      }
    }

    private void DeleteChild()
    {
      foreach (gongziDataSet.work_sheet_headRow row in (InternalDataCollectionBase) this.gongziDataSet.work_sheet_head.Rows)
      {
        if (row.RowState == DataRowState.Deleted)
          this.work_sheet_lineTableAdapter.DeleteByHead_id(row["ID", DataRowVersion.Original].ToString());
      }
    }

    private void 保存SToolStripButton_Click(object sender, EventArgs e)
    {
      this.txtName.Focus();
      if (this.head_bs.Current == null && this.HasDataRowChanged((DataTable) this.gongziDataSet.work_sheet_head))
      {
        this.DeleteChild();
        int num = (int) MessageBox.Show(string.Concat((object) this.work_sheet_headTableAdapter.Update(this.gongziDataSet.work_sheet_head)));
      }
      else
      {
        gongziDataSet.work_sheet_headRow row1 = (this.head_bs.Current as DataRowView).Row as gongziDataSet.work_sheet_headRow;
        int rowState = (int) row1.RowState;
        this.head_bs.EndEdit();
        row1.modify_date = DateTime.Now;
        this.DeleteChild();
        int num1 = (int) MessageBox.Show(string.Concat((object) this.work_sheet_headTableAdapter.Update(this.gongziDataSet.work_sheet_head)));
        this.line_bs.EndEdit();
        for (int index = this.gongziDataSet.work_sheet_line.Rows.Count - 1; index >= 0; --index)
        {
          gongziDataSet.work_sheet_lineRow row2 = this.gongziDataSet.work_sheet_line.Rows[index] as gongziDataSet.work_sheet_lineRow;
          if (row2.RowState != DataRowState.Deleted && (row2.Isprod_specNull() || row2.prod_spec.Trim() == ""))
            row2.Delete();
        }
        string str = row1[0].ToString();
        foreach (gongziDataSet.work_sheet_lineRow row2 in (InternalDataCollectionBase) this.gongziDataSet.work_sheet_line.Rows)
        {
          if (row2.RowState != DataRowState.Deleted)
          {
            if (row2.RowState == DataRowState.Added)
              row2.ID = this.gongziDataSet.GetNewId(this.gongziDataSet.work_sheet_line.TableName);
            if (row2.head_id == null)
              row2.head_id = str;
          }
        }
        int num2 = this.work_sheet_lineTableAdapter.Update(this.gongziDataSet.work_sheet_line);
        this.line_bs.ResetBindings(true);
        int num3 = (int) MessageBox.Show("修改记录" + (object) num2);
        this.btnSave.Enabled = false;
      }
    }

    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      this.CalcSum(e.RowIndex, e.ColumnIndex);
    }

    private void CalcSum(int rowidx, int colidx)
    {
      DataGridViewRow row = this.dgWorkLine.Rows[rowidx];
      if (row == null)
        return;
      switch (colidx)
      {
        case 2:
          if (this.cmbStepName.SelectedIndex < 0 || row.Cells[2].Value == null)
            break;
          string ProdSpec = row.Cells[2].Value.ToString();
          string memo;
          row.Cells[this.priceDataGridViewTextBoxColumn.Index].Value = (object) this.gongziDataSet.GetProdStepPrice(ProdSpec, this.cmbStepName.SelectedIndex, out memo);
          if (row.Cells[this.memoDataGridViewTextBoxColumn.Index].Value.ToString().Contains(memo))
            break;
          DataGridViewCell cell = row.Cells[this.memoDataGridViewTextBoxColumn.Index];
          string str = cell.Value.ToString() + memo;
          cell.Value = (object) str;
          break;
        case 4:
          Decimal result1 = new Decimal(0);
          if (!Decimal.TryParse(string.Concat(row.Cells[4].Value), out result1))
            break;
          Decimal result2 = new Decimal(0);
          if (!Decimal.TryParse(string.Concat(row.Cells[5].Value), out result2))
            break;
          row.Cells[6].Value = (object) (result1 * result2);
          break;
      }
    }

    private void worksheetheadBindingSource_AddingNew(object sender, AddingNewEventArgs e)
    {
      gongziDataSet.work_sheet_headRow workSheetHeadRow = this.gongziDataSet.work_sheet_head.Addwork_sheet_headRow(Guid.NewGuid().ToString(), "", "", "", this.dtpWorkDate.Text, DateTime.Now);
      e.NewObject = (object) workSheetHeadRow;
      this.head_bs.MoveLast();
      this.dtpWorkDate.Value = DateTime.Now;
      this.cmbStepName.SelectedIndex = -1;
      this.dgWorkLine.AllowUserToAddRows = true;
    }

    private void cmbStepName_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.pbCalc.Visible = true;
      this.pbCalc.Minimum = 0;
      this.pbCalc.Maximum = this.dgWorkLine.Rows.Count;
      int num = 1;
      foreach (DataGridViewRow row in (IEnumerable) this.dgWorkLine.Rows)
      {
        this.CalcSum(row.Index, 2);
        this.CalcSum(row.Index, 4);
        this.pbCalc.Value = num;
        ++num;
      }
      this.line_bs.EndEdit();
      this.pbCalc.Visible = false;
    }

    private void btnExcel_Click(object sender, EventArgs e)
    {
      if (this.dgWorkLine.Rows.Count == 0)
        return;
      this.pbCalc.Visible = true;
      PubFunc.DataGridView2Excel(this.dgWorkLine, "产量 " + this.dtpWorkDate.Text + this.txtWorker.Text, this.pbCalc);
      this.pbCalc.Visible = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.work_sheet_headTableAdapter.FillTop30(this.gongziDataSet.work_sheet_head);
      this.dgWorkLine.AllowUserToAddRows = this.gongziDataSet.work_sheet_head.Count > 0;
    }

    private void dgWorkLine_UserAddedRow(object sender, DataGridViewRowEventArgs e)
    {
      e.Row.Cells[1].Value = (object) this.dgWorkLine.Rows.Count;
    }

    private void dgWorkLine_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
    {
      for (int index = 0; index < this.dgWorkLine.Rows.Count; ++index)
        this.dgWorkLine.Rows[index].Cells[1].Value = (object) (index + 1);
    }

    private void dgWorkLine_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
    {
      for (int index = 0; index < this.dgWorkLine.Rows.Count; ++index)
        this.dgWorkLine.Rows[index].Cells[1].Value = (object) (index + 1);
    }

    private void dgWorkLine_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
    }

    private void dgWorkLine_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (!(e.Control is TextBox))
        return;
      TextBox control = e.Control as TextBox;
      if (control == null)
        return;
      if (this.dgWorkLine.CurrentCell.ColumnIndex == 2)
      {
        control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        control.AutoCompleteSource = AutoCompleteSource.CustomSource;
        control.AutoCompleteCustomSource = this.filterVals;
      }
      else
        control.AutoCompleteCustomSource = (AutoCompleteStringCollection) null;
    }

    private void head_bs_ListChanged(object sender, ListChangedEventArgs e)
    {
      this.dgWorkLine.AllowUserToAddRows = this.head_bs.Count > 0;
      this.btnSave.Enabled = this.HasDataRowChanged((DataTable) this.gongziDataSet.work_sheet_head);
    }

    private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("点击保存后数据才会真正被删除！");
    }

    private bool HasDataRowChanged(DataTable dt)
    {
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        if (row.RowState != DataRowState.Unchanged && row.RowState != DataRowState.Detached)
          return true;
      }
      return false;
    }

    private void dgWorkLine_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      int num = (int) MessageBox.Show("您输入的数字格式不对，请重新输入！");
    }

    private void line_bs_ListChanged(object sender, ListChangedEventArgs e)
    {
      this.btnSave.Enabled = true;
    }

    private void btnRpt_Click(object sender, EventArgs e)
    {
      if (this.head_bs.Current == null)
        return;
      FrmReportView.ViewRpt(((this.head_bs.Current as DataRowView).Row as gongziDataSet.work_sheet_headRow).ID);
    }

    private void FrmWorkSheet_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("是否确定执行取消操作，上次保存前的所有数据将会丢失！", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      int columnIndex = this.dgWorkLine.CurrentCell.ColumnIndex;
      int rowIndex = this.dgWorkLine.CurrentCell.RowIndex;
      this.gongziDataSet.work_sheet_head.RejectChanges();
      this.LastActHeadObj = (object) null;
      this.worksheetheadBindingSource_CurrentChanged((object) null, (EventArgs) null);
      this.btnSave.Enabled = false;
      this.dgWorkLine.CurrentCell = this.dgWorkLine.Rows[rowIndex > this.dgWorkLine.Rows.Count - 1 ? this.dgWorkLine.Rows.Count - 1 : rowIndex].Cells[columnIndex];
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
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmWorkSheet));
      this.groupBox1 = new GroupBox();
      this.button1 = new Button();
      this.btnSearch = new Button();
      this.cmbStep = new ComboBox();
      this.txtName = new TextBox();
      this.label3 = new Label();
      this.label1 = new Label();
      this.label2 = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.groupBox2 = new GroupBox();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.dgWorkLine = new DataGridView();
      this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.seq = new DataGridViewTextBoxColumn();
      this.prodspecDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.batchcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.sumDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.memoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.headidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.line_bs = new BindingSource(this.components);
      this.gongziDataSet = new gongziDataSet();
      this.panel1 = new Panel();
      this.textBox3 = new TextBox();
      this.head_bs = new BindingSource(this.components);
      this.label7 = new Label();
      this.cmbStepName = new ComboBox();
      this.label6 = new Label();
      this.txtWorker = new TextBox();
      this.label5 = new Label();
      this.label4 = new Label();
      this.dtpWorkDate = new DateTimePicker();
      this.tabPage2 = new TabPage();
      this.dgHead = new DataGridView();
      this.iDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      this.workdateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.workerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.prodStepDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.deptDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.modifydateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
      this.bsNav = new BindingNavigator(this.components);
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
      this.btnSave = new ToolStripButton();
      this.btnCancel = new ToolStripButton();
      this.btnExcel = new ToolStripButton();
      this.btnRpt = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.pbCalc = new ToolStripProgressBar();
      this.work_sheet_lineTableAdapter = new work_sheet_lineTableAdapter();
      this.work_sheet_headTableAdapter = new work_sheet_headTableAdapter();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((ISupportInitialize) this.dgWorkLine).BeginInit();
      ((ISupportInitialize) this.line_bs).BeginInit();
      this.gongziDataSet.BeginInit();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.head_bs).BeginInit();
      this.tabPage2.SuspendLayout();
      ((ISupportInitialize) this.dgHead).BeginInit();
      this.bsNav.BeginInit();
      this.bsNav.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.button1);
      this.groupBox1.Controls.Add((Control) this.btnSearch);
      this.groupBox1.Controls.Add((Control) this.cmbStep);
      this.groupBox1.Controls.Add((Control) this.txtName);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.dateTimePicker1);
      this.groupBox1.Location = new Point(4, 16);
      this.groupBox1.Margin = new Padding(4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(4);
      this.groupBox1.Size = new Size(1116, 81);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "查询条件";
      this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button1.Location = new Point(1005, 28);
      this.button1.Margin = new Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new Size(100, 31);
      this.button1.TabIndex = 8;
      this.button1.Text = "最新的30个";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSearch.Location = new Point(885, 28);
      this.btnSearch.Margin = new Padding(4);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(100, 31);
      this.btnSearch.TabIndex = 7;
      this.btnSearch.Text = "查询";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
      this.cmbStep.FormattingEnabled = true;
      this.cmbStep.Items.AddRange(new object[10]
      {
        (object) "木工",
        (object) "介棉",
        (object) "贴棉",
        (object) "裁皮",
        (object) "车皮",
        (object) "压线",
        (object) "扪皮",
        (object) "安装",
        (object) "包装",
        (object) "厚皮贴皮"
      });
      this.cmbStep.Location = new Point(512, 30);
      this.cmbStep.Margin = new Padding(4);
      this.cmbStep.Name = "cmbStep";
      this.cmbStep.Size = new Size(203, 24);
      this.cmbStep.TabIndex = 6;
      this.txtName.Location = new Point(256, 30);
      this.txtName.Margin = new Padding(4);
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(199, 26);
      this.txtName.TabIndex = 5;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(464, 36);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(40, 16);
      this.label3.TabIndex = 4;
      this.label3.Text = "工序";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(208, 38);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(40, 16);
      this.label1.TabIndex = 3;
      this.label1.Text = "姓名";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(14, 35);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(40, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "月份";
      this.dateTimePicker1.CustomFormat = "yyyy年MM月";
      this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
      this.dateTimePicker1.Location = new Point(74, 29);
      this.dateTimePicker1.Margin = new Padding(4);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(121, 26);
      this.dateTimePicker1.TabIndex = 0;
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.tabControl1);
      this.groupBox2.Controls.Add((Control) this.bsNav);
      this.groupBox2.Location = new Point(4, 105);
      this.groupBox2.Margin = new Padding(4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(4);
      this.groupBox2.Size = new Size(1116, 855);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "产量";
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new Point(4, 48);
      this.tabControl1.Margin = new Padding(4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(1108, 803);
      this.tabControl1.TabIndex = 3;
      this.tabPage1.Controls.Add((Control) this.dgWorkLine);
      this.tabPage1.Controls.Add((Control) this.panel1);
      this.tabPage1.Location = new Point(4, 26);
      this.tabPage1.Margin = new Padding(4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(4);
      this.tabPage1.Size = new Size(1100, 773);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "常规";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.dgWorkLine.AutoGenerateColumns = false;
      this.dgWorkLine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgWorkLine.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn, (DataGridViewColumn) this.seq, (DataGridViewColumn) this.prodspecDataGridViewTextBoxColumn, (DataGridViewColumn) this.batchcodeDataGridViewTextBoxColumn, (DataGridViewColumn) this.amountDataGridViewTextBoxColumn, (DataGridViewColumn) this.priceDataGridViewTextBoxColumn, (DataGridViewColumn) this.sumDataGridViewTextBoxColumn, (DataGridViewColumn) this.memoDataGridViewTextBoxColumn, (DataGridViewColumn) this.headidDataGridViewTextBoxColumn);
      this.dgWorkLine.DataSource = (object) this.line_bs;
      this.dgWorkLine.Dock = DockStyle.Fill;
      this.dgWorkLine.Location = new Point(4, 76);
      this.dgWorkLine.Margin = new Padding(4);
      this.dgWorkLine.Name = "dgWorkLine";
      gridViewCellStyle1.Padding = new Padding(5, 0, 5, 0);
      this.dgWorkLine.RowsDefaultCellStyle = gridViewCellStyle1;
      this.dgWorkLine.RowTemplate.Height = 23;
      this.dgWorkLine.Size = new Size(1092, 693);
      this.dgWorkLine.TabIndex = 3;
      this.dgWorkLine.CellEndEdit += new DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
      this.dgWorkLine.DataError += new DataGridViewDataErrorEventHandler(this.dgWorkLine_DataError);
      this.dgWorkLine.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgWorkLine_EditingControlShowing);
      this.dgWorkLine.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgWorkLine_RowsAdded_1);
      this.dgWorkLine.UserAddedRow += new DataGridViewRowEventHandler(this.dgWorkLine_UserAddedRow);
      this.dgWorkLine.UserDeletedRow += new DataGridViewRowEventHandler(this.dgWorkLine_UserDeletedRow);
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      this.iDDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.iDDataGridViewTextBoxColumn.Visible = false;
      this.seq.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
      this.seq.DefaultCellStyle = gridViewCellStyle2;
      this.seq.HeaderText = "序号";
      this.seq.Name = "seq";
      this.seq.ReadOnly = true;
      this.seq.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.seq.Width = 46;
      this.prodspecDataGridViewTextBoxColumn.DataPropertyName = "prod_spec";
      this.prodspecDataGridViewTextBoxColumn.HeaderText = "型号";
      this.prodspecDataGridViewTextBoxColumn.Name = "prodspecDataGridViewTextBoxColumn";
      this.prodspecDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
      this.prodspecDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.batchcodeDataGridViewTextBoxColumn.DataPropertyName = "batch_code";
      this.batchcodeDataGridViewTextBoxColumn.HeaderText = "批次";
      this.batchcodeDataGridViewTextBoxColumn.Name = "batchcodeDataGridViewTextBoxColumn";
      this.batchcodeDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
      gridViewCellStyle3.Padding = new Padding(5, 0, 5, 0);
      this.amountDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle3;
      this.amountDataGridViewTextBoxColumn.HeaderText = "数量";
      this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
      this.amountDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
      gridViewCellStyle4.Padding = new Padding(5, 0, 5, 0);
      this.priceDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle4;
      this.priceDataGridViewTextBoxColumn.HeaderText = "单价";
      this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
      this.priceDataGridViewTextBoxColumn.ReadOnly = true;
      this.priceDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.sumDataGridViewTextBoxColumn.DataPropertyName = "sum";
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
      gridViewCellStyle5.Padding = new Padding(5, 0, 5, 0);
      this.sumDataGridViewTextBoxColumn.DefaultCellStyle = gridViewCellStyle5;
      this.sumDataGridViewTextBoxColumn.HeaderText = "总数";
      this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
      this.sumDataGridViewTextBoxColumn.ReadOnly = true;
      this.sumDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.memoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      this.memoDataGridViewTextBoxColumn.DataPropertyName = "memo";
      this.memoDataGridViewTextBoxColumn.HeaderText = "备注";
      this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
      this.memoDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.headidDataGridViewTextBoxColumn.DataPropertyName = "head_id";
      this.headidDataGridViewTextBoxColumn.HeaderText = "head_id";
      this.headidDataGridViewTextBoxColumn.Name = "headidDataGridViewTextBoxColumn";
      this.headidDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
      this.headidDataGridViewTextBoxColumn.Visible = false;
      this.line_bs.DataMember = "work_sheet_line";
      this.line_bs.DataSource = (object) this.gongziDataSet;
      this.line_bs.ListChanged += new ListChangedEventHandler(this.line_bs_ListChanged);
      this.gongziDataSet.DataSetName = "gongziDataSet";
      this.gongziDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.panel1.Controls.Add((Control) this.textBox3);
      this.panel1.Controls.Add((Control) this.label7);
      this.panel1.Controls.Add((Control) this.cmbStepName);
      this.panel1.Controls.Add((Control) this.label6);
      this.panel1.Controls.Add((Control) this.txtWorker);
      this.panel1.Controls.Add((Control) this.label5);
      this.panel1.Controls.Add((Control) this.label4);
      this.panel1.Controls.Add((Control) this.dtpWorkDate);
      this.panel1.Dock = DockStyle.Top;
      this.panel1.Location = new Point(4, 4);
      this.panel1.Margin = new Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1092, 72);
      this.panel1.TabIndex = 2;
      this.textBox3.DataBindings.Add(new Binding("Text", (object) this.head_bs, "dept", true, DataSourceUpdateMode.OnPropertyChanged));
      this.textBox3.Location = new Point(767, 20);
      this.textBox3.Margin = new Padding(4);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(256, 26);
      this.textBox3.TabIndex = 11;
      this.head_bs.DataMember = "work_sheet_head";
      this.head_bs.DataSource = (object) this.gongziDataSet;
      this.head_bs.AddingNew += new AddingNewEventHandler(this.worksheetheadBindingSource_AddingNew);
      this.head_bs.CurrentChanged += new EventHandler(this.worksheetheadBindingSource_CurrentChanged);
      this.head_bs.ListChanged += new ListChangedEventHandler(this.head_bs_ListChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(720, 24);
      this.label7.Margin = new Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(40, 16);
      this.label7.TabIndex = 10;
      this.label7.Text = "部门";
      this.cmbStepName.DataBindings.Add(new Binding("SelectedItem", (object) this.head_bs, "Prod_Step", true));
      this.cmbStepName.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbStepName.FormattingEnabled = true;
      this.cmbStepName.Items.AddRange(new object[10]
      {
        (object) "木工",
        (object) "介棉",
        (object) "贴棉",
        (object) "裁皮",
        (object) "车皮",
        (object) "压线",
        (object) "扪皮",
        (object) "安装",
        (object) "包装",
        (object) "厚皮贴皮"
      });
      this.cmbStepName.Location = new Point(496, 20);
      this.cmbStepName.Margin = new Padding(4);
      this.cmbStepName.Name = "cmbStepName";
      this.cmbStepName.Size = new Size(207, 24);
      this.cmbStepName.TabIndex = 9;
      this.cmbStepName.SelectionChangeCommitted += new EventHandler(this.cmbStepName_SelectedIndexChanged);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(448, 25);
      this.label6.Margin = new Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(40, 16);
      this.label6.TabIndex = 8;
      this.label6.Text = "工序";
      this.txtWorker.DataBindings.Add(new Binding("Text", (object) this.head_bs, "worker", true, DataSourceUpdateMode.OnPropertyChanged));
      this.txtWorker.Location = new Point(257, 20);
      this.txtWorker.Margin = new Padding(4);
      this.txtWorker.Name = "txtWorker";
      this.txtWorker.Size = new Size(180, 26);
      this.txtWorker.TabIndex = 7;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(209, 25);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(40, 16);
      this.label5.TabIndex = 6;
      this.label5.Text = "姓名";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(31, 25);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(40, 16);
      this.label4.TabIndex = 3;
      this.label4.Text = "月份";
      this.dtpWorkDate.CustomFormat = "yyyy年MM月";
      this.dtpWorkDate.DataBindings.Add(new Binding("Tag", (object) this.head_bs, "ID", true, DataSourceUpdateMode.OnPropertyChanged));
      this.dtpWorkDate.DataBindings.Add(new Binding("Text", (object) this.head_bs, "work_date", true, DataSourceUpdateMode.OnPropertyChanged));
      this.dtpWorkDate.Format = DateTimePickerFormat.Custom;
      this.dtpWorkDate.Location = new Point(77, 20);
      this.dtpWorkDate.Margin = new Padding(4);
      this.dtpWorkDate.Name = "dtpWorkDate";
      this.dtpWorkDate.Size = new Size(128, 26);
      this.dtpWorkDate.TabIndex = 0;
      this.dtpWorkDate.Value = new DateTime(2014, 6, 4, 0, 0, 0, 0);
      this.tabPage2.Controls.Add((Control) this.dgHead);
      this.tabPage2.Location = new Point(4, 26);
      this.tabPage2.Margin = new Padding(4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(4);
      this.tabPage2.Size = new Size(1100, 771);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "浏览";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.dgHead.AllowUserToAddRows = false;
      this.dgHead.AllowUserToDeleteRows = false;
      this.dgHead.AutoGenerateColumns = false;
      this.dgHead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgHead.Columns.AddRange((DataGridViewColumn) this.iDDataGridViewTextBoxColumn1, (DataGridViewColumn) this.workdateDataGridViewTextBoxColumn, (DataGridViewColumn) this.workerDataGridViewTextBoxColumn, (DataGridViewColumn) this.prodStepDataGridViewTextBoxColumn, (DataGridViewColumn) this.deptDataGridViewTextBoxColumn, (DataGridViewColumn) this.modifydateDataGridViewTextBoxColumn);
      this.dgHead.DataSource = (object) this.head_bs;
      this.dgHead.Dock = DockStyle.Fill;
      this.dgHead.Location = new Point(4, 4);
      this.dgHead.Margin = new Padding(4);
      this.dgHead.Name = "dgHead";
      this.dgHead.ReadOnly = true;
      this.dgHead.RowTemplate.Height = 23;
      this.dgHead.Size = new Size(1092, 763);
      this.dgHead.TabIndex = 0;
      this.iDDataGridViewTextBoxColumn1.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn1.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn1.Name = "iDDataGridViewTextBoxColumn1";
      this.iDDataGridViewTextBoxColumn1.ReadOnly = true;
      this.iDDataGridViewTextBoxColumn1.Visible = false;
      this.workdateDataGridViewTextBoxColumn.DataPropertyName = "work_date";
      this.workdateDataGridViewTextBoxColumn.HeaderText = "月份";
      this.workdateDataGridViewTextBoxColumn.Name = "workdateDataGridViewTextBoxColumn";
      this.workdateDataGridViewTextBoxColumn.ReadOnly = true;
      this.workdateDataGridViewTextBoxColumn.Width = 130;
      this.workerDataGridViewTextBoxColumn.DataPropertyName = "worker";
      this.workerDataGridViewTextBoxColumn.HeaderText = "姓名";
      this.workerDataGridViewTextBoxColumn.Name = "workerDataGridViewTextBoxColumn";
      this.workerDataGridViewTextBoxColumn.ReadOnly = true;
      this.workerDataGridViewTextBoxColumn.Width = 150;
      this.prodStepDataGridViewTextBoxColumn.DataPropertyName = "Prod_Step";
      this.prodStepDataGridViewTextBoxColumn.HeaderText = "工序";
      this.prodStepDataGridViewTextBoxColumn.Name = "prodStepDataGridViewTextBoxColumn";
      this.prodStepDataGridViewTextBoxColumn.ReadOnly = true;
      this.deptDataGridViewTextBoxColumn.DataPropertyName = "dept";
      this.deptDataGridViewTextBoxColumn.HeaderText = "部门";
      this.deptDataGridViewTextBoxColumn.Name = "deptDataGridViewTextBoxColumn";
      this.deptDataGridViewTextBoxColumn.ReadOnly = true;
      this.deptDataGridViewTextBoxColumn.Width = 200;
      this.modifydateDataGridViewTextBoxColumn.DataPropertyName = "modify_date";
      this.modifydateDataGridViewTextBoxColumn.HeaderText = "修改时间";
      this.modifydateDataGridViewTextBoxColumn.Name = "modifydateDataGridViewTextBoxColumn";
      this.modifydateDataGridViewTextBoxColumn.ReadOnly = true;
      this.modifydateDataGridViewTextBoxColumn.Width = 200;
      this.bsNav.AddNewItem = (ToolStripItem) this.bindingNavigatorAddNewItem;
      this.bsNav.BindingSource = this.head_bs;
      this.bsNav.CountItem = (ToolStripItem) this.bindingNavigatorCountItem;
      this.bsNav.DeleteItem = (ToolStripItem) this.bindingNavigatorDeleteItem;
      this.bsNav.Items.AddRange(new ToolStripItem[17]
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
        (ToolStripItem) this.btnSave,
        (ToolStripItem) this.btnCancel,
        (ToolStripItem) this.btnExcel,
        (ToolStripItem) this.btnRpt,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.pbCalc
      });
      this.bsNav.Location = new Point(4, 23);
      this.bsNav.MoveFirstItem = (ToolStripItem) this.bindingNavigatorMoveFirstItem;
      this.bsNav.MoveLastItem = (ToolStripItem) this.bindingNavigatorMoveLastItem;
      this.bsNav.MoveNextItem = (ToolStripItem) this.bindingNavigatorMoveNextItem;
      this.bsNav.MovePreviousItem = (ToolStripItem) this.bindingNavigatorMovePreviousItem;
      this.bsNav.Name = "bsNav";
      this.bsNav.PositionItem = (ToolStripItem) this.bindingNavigatorPositionItem;
      this.bsNav.Size = new Size(1108, 25);
      this.bsNav.TabIndex = 0;
      this.bsNav.Text = "bindingNavigator1";
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
      this.bindingNavigatorDeleteItem.Click += new EventHandler(this.bindingNavigatorDeleteItem_Click);
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
      this.btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnSave.Enabled = false;
      this.btnSave.Image = (Image) componentResourceManager.GetObject("btnSave.Image");
      this.btnSave.ImageTransparentColor = Color.Magenta;
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(23, 22);
      this.btnSave.Text = "保存(&S)";
      this.btnSave.Click += new EventHandler(this.保存SToolStripButton_Click);
      this.btnCancel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnCancel.Image = (Image) componentResourceManager.GetObject("btnCancel.Image");
      this.btnCancel.ImageTransparentColor = Color.Magenta;
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(23, 22);
      this.btnCancel.Text = "取消";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.btnExcel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnExcel.Image = (Image) componentResourceManager.GetObject("btnExcel.Image");
      this.btnExcel.ImageTransparentColor = Color.Magenta;
      this.btnExcel.Name = "btnExcel";
      this.btnExcel.Size = new Size(23, 22);
      this.btnExcel.Text = "导出Excel";
      this.btnExcel.Click += new EventHandler(this.btnExcel_Click);
      this.btnRpt.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.btnRpt.Image = (Image) componentResourceManager.GetObject("btnRpt.Image");
      this.btnRpt.ImageTransparentColor = Color.Magenta;
      this.btnRpt.Name = "btnRpt";
      this.btnRpt.Size = new Size(23, 22);
      this.btnRpt.Text = "打印";
      this.btnRpt.Click += new EventHandler(this.btnRpt_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.pbCalc.Name = "pbCalc";
      this.pbCalc.Size = new Size(133, 29);
      this.pbCalc.Visible = false;
      this.work_sheet_lineTableAdapter.ClearBeforeFill = true;
      this.work_sheet_headTableAdapter.ClearBeforeFill = true;
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1125, 971);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Margin = new Padding(4);
      this.Name = "FrmWorkSheet";
      this.Text = "产量录入";
      this.FormClosing += new FormClosingEventHandler(this.FrmWorkSheet_FormClosing);
      this.Load += new EventHandler(this.FrmWorkSheet_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      ((ISupportInitialize) this.dgWorkLine).EndInit();
      ((ISupportInitialize) this.line_bs).EndInit();
      this.gongziDataSet.EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.head_bs).EndInit();
      this.tabPage2.ResumeLayout(false);
      ((ISupportInitialize) this.dgHead).EndInit();
      this.bsNav.EndInit();
      this.bsNav.ResumeLayout(false);
      this.bsNav.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
