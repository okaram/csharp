#r System.Configuration.dll

using System.Configuration;

ExeConfigurationFileMap m=new ExeConfigurationFileMap();
m.ExeConfigFilename=@"C:\Users\orkaram\Documents\csharp\ExamPrep\src\Configuration\test1.config";

Configuration conf=ConfigurationManager.OpenMappedExeConfiguration(m,ConfigurationUserLevel.None);

foreach(ConnectionStringSettings c in conf.ConnectionStrings.ConnectionStrings) {
	Console.WriteLine("Name: {0}, Provider: {1}, String:{2}",c.Name,c.ProviderName,c.ConnectionString);
}

foreach (KeyValueConfigurationElement keyValueElement in conf.AppSettings.Settings)
{
	Console.WriteLine("Key: {0}", keyValueElement.Key);
	Console.WriteLine("Value: {0}", keyValueElement.Value);
	Console.WriteLine();
}
