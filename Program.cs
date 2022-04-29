using Ionic.Zip;

const string zippedFilePath = @"C:\Users\salmam\Downloads\MyFile.Zip";
const string filePathToBeZipped = @"C:\Users\salmam\Downloads\static-web-blazor-func-2020-11-20.pdf";
const string directoryInZippedFolder = "Files";
const string extractedZippedFolderPath = @"C:\Users\salmam\Downloads\MyFile";

CreateProtectedZip();
ExtractProtectedZip();



void CreateProtectedZip()
{
    try
    {
        if (File.Exists(zippedFilePath))
        {
            File.Delete(zippedFilePath);
        }
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

void ExtractProtectedZip()
{
    try
    {
        using (var zip = ZipFile.Read(zippedFilePath))
        {
            const string password = "123456!";
            var zipPassword= ZipFile.CheckZipPassword(zippedFilePath, password);
            if (!zipPassword)
            {
                Console.WriteLine("Password in incorrect");
                throw new BadPasswordException("Password is Incorrect");
            }
            zip.Password = password;
            zip.ExtractAll(extractedZippedFolderPath, ExtractExistingFileAction.OverwriteSilently);
        }

        Console.WriteLine("Zip file has been successfully extracted.");
        Console.Read();
    }
    catch (BadPasswordException ep)
    {
        Console.Write(ep.Message);
    }
    catch (Exception ep)
    {
        Console.Write(ep.Message);
    }
}
