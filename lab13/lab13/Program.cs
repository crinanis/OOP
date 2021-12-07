namespace lab13
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            BKADiskInfo.getFreeDrivesSpace();
            BKALog.writeToLog("BKADiskInfo.getFreeDrivesSpace()");

            BKAFileInfo.getFileinfo(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab13\lab13\log.txt");
            BKALog.writeToLog("BKAFileInfo.getFileinfo()", "log.txt", @"e:\!ПОИТ\2\First\ООТП\Лабы\lab13\lab13\log.txt");

            BKADirInfo.getDirinfo(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab13");
            BKALog.writeToLog("BKADirInfo.getDirinfo()", "", @"e:\!ПОИТ\2\First\ООТП\Лабы\lab13");

            BKAFileManager.getAllDirsAndFilesOfDisk(@"E:\");
            BKALog.writeToLog("BKAFileManager.getAllDirsAndFilesOfDisk()", "", @"E:\");

            BKAFileManager.getAllFilesWithExtension(@"e:\!ПОИТ\2\First\ЯП\КП\BKA-2021\BKA-2021", ".txt");
            BKALog.writeToLog("BKAFileManager.getAllDirsAndFilesOfDisk()", "", @"e:\!ПОИТ\2\First\ЯП\КП\BKA-2021\BKA-2021");

            BKAFileManager.createZIP(@"e:\!ПОИТ\2\First\ООТП\Лабы\lab13\BKAInspect\BKAFiles");
            BKALog.writeToLog("BKAFileManager.createZIP()");
        }
    }
}