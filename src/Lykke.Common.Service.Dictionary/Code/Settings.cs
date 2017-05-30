namespace Lykke.Common.Service.Dictionary.Code
{
    public class Settings
    {
        public CommonServiceDictionarySettings CommonServiceDictionary { get; set; }

    }

    public class CommonServiceDictionarySettings
    {
        public DbSettings Db { get; set; }
    }



    public class DbSettings
    {
        public string DictsConnString { get; set; }

    }


}
