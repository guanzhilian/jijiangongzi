// Decompiled with JetBrains decompiler
// Type: CPUNum.HardWareHelper
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using System.Management;

namespace CPUNum
{
  public class HardWareHelper
  {
    public string getCpu()
    {
      string str = (string) null;
      using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("win32_Processor").GetInstances().GetEnumerator())
      {
        if (enumerator.MoveNext())
          str = enumerator.Current.Properties["Processorid"].Value.ToString();
      }
      return str;
    }
  }
}
