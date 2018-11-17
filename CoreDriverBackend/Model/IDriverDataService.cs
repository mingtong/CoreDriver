namespace CoreDriverBackend.Model
{
    public interface IDriverDataService
    {
        string GetAllData();
        string GetDataByPrefix(string prefix);
        string GetDataByWholeSerial(string wholeSerial);
        string GetDataByNameCn(string name);
        string GetDataByTag(string tag);
        string GetDataByCompany(string companyName);

        string AddNewData(
            string prefix,
            string serial,
            string wholeSerial,
            string nameCn,
            string nameEn,
            string nameJp,
            string tag, //maybe array
            string magnetLink, //maybe array
            string torrentLink, //maybe array
            string pictureLink, //maybe array
            string companyName
            );

        string DeleteDataBy(string wholeSerial);
        
        string ModifyData(            string prefix,
            string serial,
            string wholeSerial,
            string nameCn,
            string nameEn,
            string nameJp,
            string tag, //maybe array
            string magnetLink, //maybe array
            string torrentLink, //maybe array
            string pictureLink, //maybe array
            string companyName
        );

    }
}