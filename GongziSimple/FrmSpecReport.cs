// Decompiled with JetBrains decompiler
// Type: GongziSimple.FrmSpecReport
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GongziSimple
{
  public class FrmSpecReport : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private Button btnExcel;
    private Button btnSearch;
    private Label label5;
    private TextBox txtBatch;
    private TextBox txtSpec;
    private TextBox txtWorker;
    private ComboBox cmbxProdName;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private Label label7;
    private DateTimePicker dtpMonth;
    private ComboBox cmbxStep;
    private DataGridView dgdata;
    private RadioButton rbQ;
    private RadioButton rbSum;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel ssb1;
    private ToolStripProgressBar pb;
    private DataGridViewTextBoxColumn Column1;
    private DataGridViewTextBoxColumn Column2;
    private DataGridViewTextBoxColumn Column3;
    private DataGridViewTextBoxColumn Column4;
    private DataGridViewTextBoxColumn Column5;
    private DataGridViewTextBoxColumn Column6;
    private DataGridViewTextBoxColumn Column7;

    public FrmSpecReport()
    {
      this.InitializeComponent();
      this.dgdata.AutoGenerateColumns = false;
    }

    private void FrmSpecReport_Load(object sender, EventArgs e)
    {
      this.dtpMonth.Value = DateTime.Now;
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      using (gongziDataSet gongziDataSet = new gongziDataSet())
      {
        string str1 = "";
        string format = !this.rbSum.Checked ? " SELECT   b.worker, a.prod_spec, a.batch_code, a.amount, a.price, a.[sum] as sum1, a.memo  FROM      (work_sheet_line a INNER JOIN  work_sheet_head b ON a.head_id = b.ID)  where 1=1 {0}" : " SELECT   b.worker, a.prod_spec, a.batch_code, SUM(a.amount) AS amount, AVG(a.price) AS price, SUM(a.[sum]) AS sum1  FROM      (work_sheet_line a INNER JOIN  work_sheet_head b ON a.head_id = b.ID)  where 1=1 {0} GROUP BY b.worker, a.prod_spec, a.batch_code ";
        if (this.cmbxProdName.SelectedIndex > 0)
          str1 += string.Format(" and Prod_Spec in ( select Prod_Spec from ProductStep where Prod_Name ='{0}')", (object) this.cmbxProdName.Text);
        if (this.txtSpec.Text != "")
          str1 += string.Format(" and prod_spec like '%{0}%'", (object) this.txtSpec.Text);
        if (this.txtBatch.Text != "")
          str1 += string.Format(" and batch_code like '%{0}%'", (object) this.txtBatch.Text);
        if (this.txtWorker.Text != "")
          str1 += string.Format(" and worker like '%{0}%'", (object) this.txtWorker.Text);
        if (this.cmbxStep.Text != "")
          str1 += string.Format(" and b.Prod_Step='{0}'", (object) this.cmbxStep.Text);
        string str2 = str1 + string.Format(" and work_date='{0}'", (object) this.dtpMonth.Text);
        string sql = string.Format(format, (object) str2);
        this.dgdata.DataSource = (object) gongziDataSet.QueryData(sql);
      }
      this.ssb1.Text = "记录总数：" + (object) this.dgdata.Rows.Count;
    }

    private void btnExcel_Click(object sender, EventArgs e)
    {
      PubFunc.DataGridView2Excel(this.dgdata, this.cmbxProdName.Text + this.txtSpec.Text + this.txtBatch.Text + this.txtWorker.Text + this.cmbxStep.Text + this.dtpMonth.Text, this.pb);
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      this.groupBox1 = new GroupBox();
      this.rbQ = new RadioButton();
      this.rbSum = new RadioButton();
      this.cmbxStep = new ComboBox();
      this.label7 = new Label();
      this.dtpMonth = new DateTimePicker();
      this.btnExcel = new Button();
      this.btnSearch = new Button();
      this.label5 = new Label();
      this.txtBatch = new TextBox();
      this.txtSpec = new TextBox();
      this.txtWorker = new TextBox();
      this.cmbxProdName = new ComboBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.dgdata = new DataGridView();
      this.Column1 = new DataGridViewTextBoxColumn();
      this.Column2 = new DataGridViewTextBoxColumn();
      this.Column3 = new DataGridViewTextBoxColumn();
      this.Column4 = new DataGridViewTextBoxColumn();
      this.Column5 = new DataGridViewTextBoxColumn();
      this.Column6 = new DataGridViewTextBoxColumn();
      this.Column7 = new DataGridViewTextBoxColumn();
      this.statusStrip1 = new StatusStrip();
      this.ssb1 = new ToolStripStatusLabel();
      this.pb = new ToolStripProgressBar();
      this.groupBox1.SuspendLayout();
      ((ISupportInitialize) this.dgdata).BeginInit();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.rbQ);
      this.groupBox1.Controls.Add((Control) this.rbSum);
      this.groupBox1.Controls.Add((Control) this.cmbxStep);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.dtpMonth);
      this.groupBox1.Controls.Add((Control) this.btnExcel);
      this.groupBox1.Controls.Add((Control) this.btnSearch);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.txtBatch);
      this.groupBox1.Controls.Add((Control) this.txtSpec);
      this.groupBox1.Controls.Add((Control) this.txtWorker);
      this.groupBox1.Controls.Add((Control) this.cmbxProdName);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(16, 16);
      this.groupBox1.Margin = new Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(4, 4, 4, 4);
      this.groupBox1.Size = new Size(1108, 95);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "条件";
      this.rbQ.AutoSize = true;
      this.rbQ.Checked = true;
      this.rbQ.Location = new Point(841, 65);
      this.rbQ.Margin = new Padding(4, 4, 4, 4);
      this.rbQ.Name = "rbQ";
      this.rbQ.Size = new Size(58, 20);
      this.rbQ.TabIndex = 17;
      this.rbQ.TabStop = true;
      this.rbQ.Text = "查询";
      this.rbQ.UseVisualStyleBackColor = true;
      this.rbSum.AutoSize = true;
      this.rbSum.Location = new Point(774, 65);
      this.rbSum.Margin = new Padding(4, 4, 4, 4);
      this.rbSum.Name = "rbSum";
      this.rbSum.Size = new Size(58, 20);
      this.rbSum.TabIndex = 16;
      this.rbSum.Text = "汇总";
      this.rbSum.UseVisualStyleBackColor = true;
      this.cmbxStep.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbxStep.FormattingEnabled = true;
      this.cmbxStep.Items.AddRange(new object[11]
      {
        (object) "",
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
      this.cmbxStep.Location = new Point(345, 64);
      this.cmbxStep.Margin = new Padding(4, 4, 4, 4);
      this.cmbxStep.Name = "cmbxStep";
      this.cmbxStep.Size = new Size(160, 24);
      this.cmbxStep.TabIndex = 15;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(525, 69);
      this.label7.Margin = new Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(40, 16);
      this.label7.TabIndex = 14;
      this.label7.Text = "月份";
      this.dtpMonth.CustomFormat = "yyyy年MM月";
      this.dtpMonth.Format = DateTimePickerFormat.Custom;
      this.dtpMonth.Location = new Point(587, 61);
      this.dtpMonth.Margin = new Padding(4, 4, 4, 4);
      this.dtpMonth.Name = "dtpMonth";
      this.dtpMonth.Size = new Size(160, 26);
      this.dtpMonth.TabIndex = 13;
      this.btnExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnExcel.Location = new Point(991, 56);
      this.btnExcel.Margin = new Padding(4, 4, 4, 4);
      this.btnExcel.Name = "btnExcel";
      this.btnExcel.Size = new Size(100, 31);
      this.btnExcel.TabIndex = 11;
      this.btnExcel.Text = "导出Excel";
      this.btnExcel.UseVisualStyleBackColor = true;
      this.btnExcel.Click += new EventHandler(this.btnExcel_Click);
      this.btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSearch.Location = new Point(991, 16);
      this.btnSearch.Margin = new Padding(4, 4, 4, 4);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(100, 31);
      this.btnSearch.TabIndex = 10;
      this.btnSearch.Text = "查询";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(298, 69);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(40, 16);
      this.label5.TabIndex = 9;
      this.label5.Text = "工序";
      this.txtBatch.Location = new Point(587, 25);
      this.txtBatch.Margin = new Padding(4, 4, 4, 4);
      this.txtBatch.Name = "txtBatch";
      this.txtBatch.Size = new Size(160, 26);
      this.txtBatch.TabIndex = 7;
      this.txtSpec.Location = new Point(345, 25);
      this.txtSpec.Margin = new Padding(4, 4, 4, 4);
      this.txtSpec.Name = "txtSpec";
      this.txtSpec.Size = new Size(160, 26);
      this.txtSpec.TabIndex = 6;
      this.txtWorker.Location = new Point(97, 66);
      this.txtWorker.Margin = new Padding(4, 4, 4, 4);
      this.txtWorker.Name = "txtWorker";
      this.txtWorker.Size = new Size(160, 26);
      this.txtWorker.TabIndex = 5;
      this.cmbxProdName.FormattingEnabled = true;
      this.cmbxProdName.Items.AddRange(new object[3]
      {
        (object) "",
        (object) "沙发",
        (object) "椅子"
      });
      this.cmbxProdName.Location = new Point(97, 25);
      this.cmbxProdName.Margin = new Padding(4, 4, 4, 4);
      this.cmbxProdName.Name = "cmbxProdName";
      this.cmbxProdName.Size = new Size(160, 24);
      this.cmbxProdName.TabIndex = 4;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(540, 29);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(40, 16);
      this.label4.TabIndex = 3;
      this.label4.Text = "批号";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(299, 29);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(40, 16);
      this.label3.TabIndex = 2;
      this.label3.Text = "型号";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(35, 69);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(40, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "人名";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(35, 29);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(40, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "产品";
      this.dgdata.AllowUserToAddRows = false;
      this.dgdata.AllowUserToDeleteRows = false;
      this.dgdata.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgdata.Columns.AddRange((DataGridViewColumn) this.Column1, (DataGridViewColumn) this.Column2, (DataGridViewColumn) this.Column3, (DataGridViewColumn) this.Column4, (DataGridViewColumn) this.Column5, (DataGridViewColumn) this.Column6, (DataGridViewColumn) this.Column7);
      this.dgdata.Location = new Point(16, 117);
      this.dgdata.Margin = new Padding(4, 4, 4, 4);
      this.dgdata.Name = "dgdata";
      this.dgdata.RowTemplate.Height = 23;
      this.dgdata.Size = new Size(1108, 538);
      this.dgdata.TabIndex = 1;
      this.Column1.DataPropertyName = "worker";
      this.Column1.HeaderText = "姓名";
      this.Column1.Name = "Column1";
      this.Column2.DataPropertyName = "prod_spec";
      this.Column2.HeaderText = "型号";
      this.Column2.Name = "Column2";
      this.Column3.DataPropertyName = "batch_code";
      this.Column3.HeaderText = "批号";
      this.Column3.Name = "Column3";
      this.Column4.DataPropertyName = "amount";
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.Column4.DefaultCellStyle = gridViewCellStyle1;
      this.Column4.HeaderText = "数量";
      this.Column4.Name = "Column4";
      this.Column5.DataPropertyName = "price";
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.Column5.DefaultCellStyle = gridViewCellStyle2;
      this.Column5.HeaderText = "单价";
      this.Column5.Name = "Column5";
      this.Column6.DataPropertyName = "sum1";
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
      this.Column6.DefaultCellStyle = gridViewCellStyle3;
      this.Column6.HeaderText = "总价";
      this.Column6.Name = "Column6";
      this.Column7.DataPropertyName = "memo";
      this.Column7.HeaderText = "备注";
      this.Column7.Name = "Column7";
      this.statusStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.ssb1,
        (ToolStripItem) this.pb
      });
      this.statusStrip1.Location = new Point(0, 663);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new Padding(1, 0, 19, 0);
      this.statusStrip1.Size = new Size(1140, 27);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      this.ssb1.Name = "ssb1";
      this.ssb1.Size = new Size(0, 22);
      this.pb.Name = "pb";
      this.pb.Size = new Size(133, 21);
      this.AutoScaleDimensions = new SizeF(8f, 16f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1140, 690);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.dgdata);
      this.Controls.Add((Control) this.groupBox1);
      this.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.Margin = new Padding(4, 4, 4, 4);
      this.Name = "FrmSpecReport";
      this.Text = "报表查询";
      this.Load += new EventHandler(this.FrmSpecReport_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((ISupportInitialize) this.dgdata).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
