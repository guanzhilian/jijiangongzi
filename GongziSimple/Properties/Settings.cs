// Decompiled with JetBrains decompiler
// Type: GongziSimple.Properties.Settings
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GongziSimple.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [DebuggerNonUserCode]
    [ApplicationScopedSetting]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\gongzi.accdb;Persist Security Info=True;Jet OLEDB:Database Password=G0ngZijiSu@an2014.;User ID=Admin")]
    public string gongziConnectionString
    {
      get
      {
        return (string) this["gongziConnectionString"];
      }
    }
  }
}
