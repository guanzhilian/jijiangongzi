// Decompiled with JetBrains decompiler
// Type: GongziSimple.FrmMain
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using GongziSimple.gongziDataSetTableAdapters;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace GongziSimple
{
    public class FrmMain : Form
    {
        private static uint WM_CLOSE = 16;
        private GrandDog Dog = new GrandDog();
        private IntPtr handle = IntPtr.Zero;
        private System.Timers.Timer _watchDog = new System.Timers.Timer();
        private uint RetCode;
        private uint ulDogHandle;
        private uint OpenDogFlag;
        private IContainer components;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 产品工序配置ToolStripMenuItem;
        private ToolStripMenuItem 录入产量ToolStripMenuItem;
        private ToolStripMenuItem 报表ToolStripMenuItem;
        private ToolStripMenuItem 加密狗ToolStripMenuItem;

        public FrmMain()
        {
            this.InitializeComponent();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("Reg.dll", CharSet = CharSet.Ansi)]
        public static extern string GetCPUID();

        private void 产品工序配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateForm(typeof(FrmProductStep));
        }

        private void 录入产量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateForm(typeof(FrmWorkSheet));
        }

        private void CreateForm(Type typ)
        {
            bool flag = false;
            Form form = (Form)null;
            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild.GetType().Equals(typ))
                {
                    flag = true;
                    form = mdiChild;
                    break;
                }
            }
            if (!flag)
            {
                Form instance = Activator.CreateInstance(typ) as Form;
                instance.MdiParent = (Form)this;
                instance.WindowState = FormWindowState.Maximized;
                instance.Show();
                this.ActivateMdiChild(instance);
            }
            else
            {
                form.Show();
                form.BringToFront();
                this.ActivateMdiChild(form);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmMain frmMain = this;
            string str = frmMain.Text + " Ver:" + this.fileVersionInfo();
            frmMain.Text = str;
            //try
            //{
            //    string cpuid = FrmMain.GetCPUID();
            //    if (!File.Exists("./HWInfo.dll"))
            //    {
            //        File.WriteAllText("./no.txt", cpuid);
            //        int num = (int)MessageBox.Show("请联系开发商进行软件签名！");
            //        this.Close();
            //    }
            //    else
            //    {
            //        if (!(Convert.ToBase64String(new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(cpuid + "gfdsaN0-*^#jhhlkjopl6788767865htfds&%#7dareqw45ruygjhgfyte@65e7xsZgdfs,kho"))) != File.ReadAllText("./HWInfo.dll")))
            //            return;
            //        int num = (int)MessageBox.Show("签名信息部正确，请与系统管理员联系！");
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    int num = (int)MessageBox.Show(ex.StackTrace);
            //    this.Close();
            //}
        }

        private unsafe void _watchDog_Elapsed(object sender, ElapsedEventArgs e)
        {
            this._watchDog.Stop();
            this.RetCode = this.Dog.CheckDog(this.ulDogHandle);
            if ((int)this.RetCode != 0)
            {
                MessageBox.Show("加密狗不存在程序即将退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
            byte[] numArray = new byte[16];
            uint ulInLen = 16;
            fixed (byte* pucOut = &numArray[0])
                this.RetCode = this.Dog.GetRandom(this.ulDogHandle, pucOut, ulInLen);
            int num1 = 0;
            if ((int)this.RetCode == 0)
            {
                for (int index = 0; (long)index < (long)ulInLen; ++index)
                    num1 += (int)numArray[index];
            }
            this._watchDog.Interval = (double)((num1 % 5 + 1) * 60000);
            if (this.VeriflySignData() != 0)
            {
                MessageBox.Show("加密狗校验失败，程序即将退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Close();
            }
            else
                this._watchDog.Start();
        }

        private unsafe int VeriflySignData()
        {
            byte[] numArray1 = new byte[16];
            byte[] numArray2 = new byte[16];
            uint ulInLen = 16;
            uint num = 16;
            char[] chArray = new char[16]
            {
        'A',
        'A',
        'b',
        'b',
        'c',
        'd',
        '0',
        '9',
        '8',
        '7',
        '@',
        '&',
        '*',
        '^',
        'm',
        'G'
            };
            for (int index = 0; index < chArray.Length; ++index)
                numArray1[index] = (byte)chArray[index];
            fixed (byte* pucIn = &numArray1[0])
            fixed (byte* pucOut = &numArray2[0])
                this.RetCode = this.Dog.SignData(this.ulDogHandle, pucIn, ulInLen, pucOut, &num);
            if ((int)this.RetCode == 0)
            {
                byte[] numArray3 = new byte[16]
                {
          (byte) 112,
          (byte) 1,
          byte.MaxValue,
          (byte) 197,
          (byte) 29,
          (byte) 38,
          (byte) 2,
          (byte) 195,
          (byte) 158,
          (byte) 124,
          (byte) 67,
          (byte) 26,
          (byte) 245,
          (byte) 193,
          (byte) 97,
          (byte) 48
                };
                for (int index = 0; index < 16; ++index)
                {
                    if ((int)numArray2[index] != (int)numArray3[index])
                        return -1;
                }
            }
            return 0;
        }

        private string fileVersionInfo()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
        }

        private bool CheckExpired()
        {
            TimeSpan timeSpan = DateTime.Parse("2014-10-01") - DateTime.Now;
            if (timeSpan.TotalDays < 0.0)
                return true;
            if (timeSpan.TotalDays < 15.0)
            {
                int num = (int)MessageBox.Show("软件将在" + timeSpan.TotalDays.ToString("0") + "天后过期，请联系开发商", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        private bool CheckLoginTime()
        {
            using (LoginLogTableAdapter loginLogTableAdapter = new LoginLogTableAdapter())
            {
                if ((DateTime.Now - DateTime.Parse(loginLogTableAdapter.LastLoginTime())).TotalSeconds < 0.0)
                    return false;
                loginLogTableAdapter.UpDateLastLogin(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                return true;
            }
        }

        private void 报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateForm(typeof(FrmSpecReport));
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.RetCode = this.Dog.CloseDog(this.ulDogHandle);
        }

        private void 加密狗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.VeriflySignData() != 0)
            {
                int num1 = (int)MessageBox.Show("加密狗校验失败，程序即将退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int num2 = (int)MessageBox.Show("校验成功");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            this.产品工序配置ToolStripMenuItem = new ToolStripMenuItem();
            this.录入产量ToolStripMenuItem = new ToolStripMenuItem();
            this.报表ToolStripMenuItem = new ToolStripMenuItem();
            this.加密狗ToolStripMenuItem = new ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            this.menuStrip1.Items.AddRange(new ToolStripItem[4]
            {
        (ToolStripItem) this.产品工序配置ToolStripMenuItem,
        (ToolStripItem) this.录入产量ToolStripMenuItem,
        (ToolStripItem) this.报表ToolStripMenuItem,
        (ToolStripItem) this.加密狗ToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1122, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.产品工序配置ToolStripMenuItem.Name = "产品工序配置ToolStripMenuItem";
            this.产品工序配置ToolStripMenuItem.Size = new Size(102, 21);
            this.产品工序配置ToolStripMenuItem.Text = "产品&&工序配置";
            this.产品工序配置ToolStripMenuItem.Click += new EventHandler(this.产品工序配置ToolStripMenuItem_Click);
            this.录入产量ToolStripMenuItem.Name = "录入产量ToolStripMenuItem";
            this.录入产量ToolStripMenuItem.Size = new Size(68, 21);
            this.录入产量ToolStripMenuItem.Text = "录入产量";
            this.录入产量ToolStripMenuItem.Click += new EventHandler(this.录入产量ToolStripMenuItem_Click);
            this.报表ToolStripMenuItem.Name = "报表ToolStripMenuItem";
            this.报表ToolStripMenuItem.Size = new Size(44, 21);
            this.报表ToolStripMenuItem.Text = "报表";
            this.报表ToolStripMenuItem.Click += new EventHandler(this.报表ToolStripMenuItem_Click);
            this.加密狗ToolStripMenuItem.Name = "加密狗ToolStripMenuItem";
            this.加密狗ToolStripMenuItem.Size = new Size(56, 21);
            this.加密狗ToolStripMenuItem.Text = "加密狗";
            this.加密狗ToolStripMenuItem.Visible = false;
            this.加密狗ToolStripMenuItem.Click += new EventHandler(this.加密狗ToolStripMenuItem_Click);
            this.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1122, 602);
            this.Controls.Add((Control)this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "工资计算";
            this.FormClosed += new FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
