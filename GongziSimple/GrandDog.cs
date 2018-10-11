// Decompiled with JetBrains decompiler
// Type: GongziSimple.GrandDog
// Assembly: GongziSimple, Version=1.0.0.8, Culture=neutral, PublicKeyToken=null
// MVID: AD2171A5-EE2B-4A61-A9C6-3D2CB8A543AA
// Assembly location: F:\Temp\计件软件\GONGZI2014-6-21\GongziSimple20160518.exe

using System.Runtime.InteropServices;

namespace GongziSimple
{
  public class GrandDog
  {
    public const uint RC_OPEN_FIRST_IN_LOCAL = 1;
    public const uint RC_OPEN_NEXT_IN_LOCAL = 2;
    public const uint RC_OPEN_IN_LAN = 3;
    public const uint RC_OPEN_LOCAL_FIRST = 4;
    public const uint RC_OPEN_LAN_FIRST = 5;
    public const byte RC_PASSWORDTYPE_USER = 1;
    public const byte RC_PASSWORDTYPE_DEVELOPER = 2;
    public const byte RC_DOGTYPE_LOCAL = 1;
    public const byte RC_DOGTYPE_NET = 2;
    public const byte RC_TYPEFILE_DATA = 1;
    public const byte RC_TYPEFILE_LICENSE = 2;
    public const byte RC_TYPEFILE_ALGORITHMS = 3;
    public const byte RC_KEY_AES = 1;
    public const ulong E_RC_VERIFY_PASSWORD_FAILED = 2820014092;

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_OpenDog(uint ulFlag, byte* pszProductName, uint* pDogHandle);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_GetDogInfo(uint DogHandle, byte* pHardwareInfo, uint* pulLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_GetProductCurrentNo(uint DogHandle, uint* pulProductCurrentNo);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_VerifyPassword(uint DogHandle, byte bPasswordType, string szPassword, byte* pbDegree);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_ChangePassword(uint DogHandle, byte bPasswordType, string szPassword);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_SetKey(uint DogHandle, byte bKeyType, byte* pucIn, uint ulLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_EncryptData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_DecryptData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_SignData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_ConvertData(uint DogHandle, byte* pucIn, uint ulInLen, uint* pulResult);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_CheckDog(uint DogHandle);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_GetRandom(uint DogHandle, byte* pucOut, uint ulInLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_CreateDir(uint DogHandle, ushort usDirID, uint ulDirSize);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_CreateFile(uint DogHandle, ushort usDirID, ushort usFileID, byte bFiletype, uint ulFileSize);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_DeleteDir(uint DogHandle, ushort usDirID);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_DeleteFile(uint DogHandle, ushort usDirID, ushort usFileID);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_DefragFileSystem(uint DogHandle, ushort usDirID);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_ReadFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulPos, uint ulLen, byte* pucOut);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_WriteFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulPos, uint ulLen, byte* pucIn);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_VisitLicenseFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulReserved);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_ExecuteFile(uint DogHandle, ushort usDirID, ushort usFileID, byte* pucIn, uint ulInlen, byte* pucOut, uint* pulOutlen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_GetUpgradeRequestString(uint DogHandle, byte* pucBuf, uint* pulLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_Upgrade(uint DogHandle, byte* pucUpgrade, uint ulLen);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern uint rc_CloseDog(uint DogHandle);

    [DllImport("RCGrandDogW32.dll", CharSet = CharSet.Ansi)]
    public static extern unsafe uint rc_GetLicenseInfo(uint DogHandle, ushort usDirID, ushort usFileID, ushort* pusLimit, uint* pulCount, uint* pulRuntime, ushort* pusBeginYear, byte* pbBeginMonth, byte* pbBeginDay, byte* pbBeginHour, byte* pbBeginMinute, byte* pbBeginSecond, ushort* pusEndYear, byte* pbEndMonth, byte* pbEndDay, byte* pbEndHour, byte* pbEndMinute, byte* pbEndSecond);

    public unsafe uint OpenDog(uint ulFlag, byte* pszProductName, uint* pDogHandle)
    {
      return GrandDog.rc_OpenDog(ulFlag, pszProductName, pDogHandle);
    }

    public uint CloseDog(uint DogHandle)
    {
      return GrandDog.rc_CloseDog(DogHandle);
    }

    public unsafe uint GetDogInfo(uint DogHandle, byte* pHardwareInfo, uint* pulLen)
    {
      return GrandDog.rc_GetDogInfo(DogHandle, pHardwareInfo, pulLen);
    }

    public unsafe uint GetProductCurrentNo(uint DogHandle, uint* pulProductCurrentNo)
    {
      return GrandDog.rc_GetProductCurrentNo(DogHandle, pulProductCurrentNo);
    }

    public unsafe uint VerifyPassword(uint DogHandle, byte bPasswordType, string szPassword, byte* pbDegree)
    {
      return GrandDog.rc_VerifyPassword(DogHandle, bPasswordType, szPassword, pbDegree);
    }

    public uint ChangePassword(uint DogHandle, byte bPasswordType, string szPassword)
    {
      return GrandDog.rc_ChangePassword(DogHandle, bPasswordType, szPassword);
    }

    public unsafe uint SetKey(uint DogHandle, byte bKeyType, byte* pucIn, uint ulLen)
    {
      return GrandDog.rc_SetKey(DogHandle, bKeyType, pucIn, ulLen);
    }

    public unsafe uint EncryptData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen)
    {
      return GrandDog.rc_EncryptData(DogHandle, pucIn, ulInLen, pucOut, pulOutLen);
    }

    public unsafe uint DecryptData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen)
    {
      return GrandDog.rc_DecryptData(DogHandle, pucIn, ulInLen, pucOut, pulOutLen);
    }

    public unsafe uint SignData(uint DogHandle, byte* pucIn, uint ulInLen, byte* pucOut, uint* pulOutLen)
    {
      return GrandDog.rc_SignData(DogHandle, pucIn, ulInLen, pucOut, pulOutLen);
    }

    public unsafe uint ConvertData(uint DogHandle, byte* pucIn, uint ulInLen, uint* pulResult)
    {
      return GrandDog.rc_ConvertData(DogHandle, pucIn, ulInLen, pulResult);
    }

    public uint CheckDog(uint DogHandle)
    {
      return GrandDog.rc_CheckDog(DogHandle);
    }

    public unsafe uint GetRandom(uint DogHandle, byte* pucOut, uint ulInLen)
    {
      return GrandDog.rc_GetRandom(DogHandle, pucOut, ulInLen);
    }

    public uint CreateDir(uint DogHandle, ushort usDirID, uint ulDirSize)
    {
      return GrandDog.rc_CreateDir(DogHandle, usDirID, ulDirSize);
    }

    public uint CreateFile(uint DogHandle, ushort usDirID, ushort usFileID, byte bFiletype, uint ulFileSize)
    {
      return GrandDog.rc_CreateFile(DogHandle, usDirID, usFileID, bFiletype, ulFileSize);
    }

    public uint DeleteDir(uint DogHandle, ushort usDirID)
    {
      return GrandDog.rc_DeleteDir(DogHandle, usDirID);
    }

    public uint DeleteFile(uint DogHandle, ushort usDirID, ushort usFileID)
    {
      return GrandDog.rc_DeleteFile(DogHandle, usDirID, usFileID);
    }

    public uint DefragFileSystem(uint DogHandle, ushort usDirID)
    {
      return GrandDog.rc_DefragFileSystem(DogHandle, usDirID);
    }

    public unsafe uint ReadFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulPos, uint ulLen, byte* pucOut)
    {
      return GrandDog.rc_ReadFile(DogHandle, usDirID, usFileID, ulPos, ulLen, pucOut);
    }

    public unsafe uint WriteFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulPos, uint ulLen, byte* pucIn)
    {
      return GrandDog.rc_WriteFile(DogHandle, usDirID, usFileID, ulPos, ulLen, pucIn);
    }

    public uint VisitLicenseFile(uint DogHandle, ushort usDirID, ushort usFileID, uint ulReserved)
    {
      return GrandDog.rc_VisitLicenseFile(DogHandle, usDirID, usFileID, ulReserved);
    }

    public unsafe uint ExecuteFile(uint DogHandle, ushort usDirID, ushort usFileID, byte* pucIn, uint ulInlen, byte* pucOut, uint* pulOutlen)
    {
      return GrandDog.rc_ExecuteFile(DogHandle, usDirID, usFileID, pucIn, ulInlen, pucOut, pulOutlen);
    }

    public unsafe uint GetUpgradeRequestString(uint DogHandle, byte* pucBuf, uint* pulLen)
    {
      return GrandDog.rc_GetUpgradeRequestString(DogHandle, pucBuf, pulLen);
    }

    public unsafe uint Upgrade(uint DogHandle, byte* pucUpgrade, uint pulLen)
    {
      return GrandDog.rc_Upgrade(DogHandle, pucUpgrade, pulLen);
    }

    public unsafe uint GetLicenseInfo(uint DogHandle, ushort usDirID, ushort usFileID, ushort* pusLimit, uint* pulCount, uint* pulRuntime, ushort* pusBeginYear, byte* pbBeginMonth, byte* pbBeginDay, byte* pbBeginHour, byte* pbBeginMinute, byte* pbBeginSecond, ushort* pusEndYear, byte* pbEndMonth, byte* pbEndDay, byte* pbEndHour, byte* pbEndMinute, byte* pbEndSecond)
    {
      return GrandDog.rc_GetLicenseInfo(DogHandle, usDirID, usFileID, pusLimit, pulCount, pulRuntime, pusBeginYear, pbBeginMonth, pbBeginDay, pbBeginHour, pbBeginMinute, pbBeginSecond, pusEndYear, pbEndMonth, pbEndDay, pbEndHour, pbEndMinute, pbEndSecond);
    }
  }
}
