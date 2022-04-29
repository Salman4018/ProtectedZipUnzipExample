// See https://aka.ms/new-console-template for more information


using Ionic.Zip;

const string zippedFilePath = @"C:\Users\salmam\Downloads\MyFile.Zip";
const string filePathToBeZipped = @"C:\Users\salmam\Downloads\static-web-blazor-func-2020-11-20.pdf";
const string directoryInZippedFolder = "Files";
const string extractedZippedFolderPath = @"C:\Users\salmam\Downloads\MyFile";

CreateZip();
UnZip();



void CreateZip()
{
    try
    {
        var zip = new ZipFile(zippedFilePath);
        var entry = zip.AddFile(filePathToBeZipped, directoryInZippedFolder);
        entry.Password = "123456!";
        zip.Save(zippedFilePath);

        Console.WriteLine("Zip file has been successfully Created.");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void UnZip()
{
    try
    {
        using (var zip = ZipFile.Read(zippedFilePath))
        {
            zip.Password = "123456!";
            zip.ExtractAll(extractedZippedFolderPath, ExtractExistingFileAction.OverwriteSilently);
        }

        Console.WriteLine("Zip file has been successfully extracted.");
        Console.Read();
    }
    catch (Exception ep)
    {
        Console.Write(ep.Message);
    }
}