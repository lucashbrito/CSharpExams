using System;
using System.IO;

namespace Chapter4
{
    public class DriveInformation
    {
        public void UsingDriveInformation()
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();

            foreach (var info in driveInfo)
            {
                Console.WriteLine($"Drive {info.Name}");
                Console.WriteLine($"File type: {info.DriveType}");

                if (info.IsReady == true)
                {
                    Console.WriteLine(" Volume label: { 0}", info.VolumeLabel);
                    Console.WriteLine(" File system: { 0}", info.DriveFormat);
                    Console.WriteLine(" Available space to current user:{ 0, 15} bytes", info.AvailableFreeSpace);
                    Console.WriteLine(" Total available space: { 0, 15} bytes", info.TotalFreeSpace);
                    Console.WriteLine(" Total size of drive: { 0, 15} bytes ", info.TotalSize);
                }
            }
        }
    }
}
