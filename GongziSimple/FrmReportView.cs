// Decompiled with JetBrains decompiler
// Type: GongziSimple.FrmReportView
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using GongziSimple.gongziDataSetTableAdapters;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GongziSimple
{
  public class FrmReportView : Form
  {
    private string head_id;
    private IContainer components;
    private ReportViewer reportViewer1;
    private BindingSource work_sheet_lineBindingSource;
    private gongziDataSet gongziDataSet;
    private work_sheet_lineTableAdapter work_sheet_lineTableAdapter;
    private BindingSource worksheetheadBindingSource;
    private work_sheet_headTableAdapter work_sheet_headTableAdapter;

    public FrmReportView()
    {
      this.InitializeComponent();
    }

    public static void ViewRpt(string head_id)
    {
      FrmReportView frmReportView = new FrmReportView();
      frmReportView.head_id = head_id;
      int num = (int) frmReportView.ShowDialog();
      frmReportView.Dispose();
    }

    private void FrmReportView_Load(object sender, EventArgs e)
    {
      this.work_sheet_headTableAdapter.FillByID(this.gongziDataSet.work_sheet_head, this.head_id);
      this.work_sheet_lineTableAdapter.FillByHeadId(this.gongziDataSet.work_sheet_line, this.head_id);
      this.reportViewer1.RefreshReport();
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
      ReportDataSource reportDataSource1 = new ReportDataSource();
      ReportDataSource reportDataSource2 = new ReportDataSource();
      this.work_sheet_lineBindingSource = new BindingSource(this.components);
      this.gongziDataSet = new gongziDataSet();
      this.worksheetheadBindingSource = new BindingSource(this.components);
      this.reportViewer1 = new ReportViewer();
      this.work_sheet_lineTableAdapter = new work_sheet_lineTableAdapter();
      this.work_sheet_headTableAdapter = new work_sheet_headTableAdapter();
      ((ISupportInitialize) this.work_sheet_lineBindingSource).BeginInit();
      this.gongziDataSet.BeginInit();
      ((ISupportInitialize) this.worksheetheadBindingSource).BeginInit();
      this.SuspendLayout();
      this.work_sheet_lineBindingSource.DataMember = "work_sheet_line";
      this.work_sheet_lineBindingSource.DataSource = (object) this.gongziDataSet;
      this.gongziDataSet.DataSetName = "gongziDataSet";
      this.gongziDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.worksheetheadBindingSource.DataMember = "work_sheet_head";
      this.worksheetheadBindingSource.DataSource = (object) this.gongziDataSet;
      this.reportViewer1.Dock = DockStyle.Fill;
      reportDataSource1.Name = "line_ds";
      reportDataSource1.Value = (object) this.work_sheet_lineBindingSource;
      reportDataSource2.Name = "head_ds";
      reportDataSource2.Value = (object) this.worksheetheadBindingSource;
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
      this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
      this.reportViewer1.LocalReport.ReportEmbeddedResource = "GongziSimple.WorkSheet.rdlc";
      this.reportViewer1.Location = new Point(0, 0);
      this.reportViewer1.Name = "reportViewer1";
      this.reportViewer1.Size = new Size(876, 631);
      this.reportViewer1.TabIndex = 0;
      this.work_sheet_lineTableAdapter.ClearBeforeFill = true;
      this.work_sheet_headTableAdapter.ClearBeforeFill = true;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(876, 631);
      this.Controls.Add((Control) this.reportViewer1);
      this.Name = "FrmReportView";
      this.Text = "打印预览";
      this.Load += new EventHandler(this.FrmReportView_Load);
      ((ISupportInitialize) this.work_sheet_lineBindingSource).EndInit();
      this.gongziDataSet.EndInit();
      ((ISupportInitialize) this.worksheetheadBindingSource).EndInit();
      this.ResumeLayout(false);
    }
  }
}
