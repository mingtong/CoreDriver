namespace CoreDriverBackend.DataService
{
    public interface IActressDataService
    {
        string GetAllData();
        string GetDataByNameCn(string name);
        string GetDataByNameJp(string name);
        string GetDataByTags(string tag);

        string AddNewData(
            string nameCn,
            string nameEn,
            string nameJp,
            string birth,
            int height,
            string chest,
            string tags, //maybe array
            string pictureLink //maybe array
            );
        string AddNewData(
            string json
        );
        string DeleteDataByName(string nameCn);
        
        string ModifyData(            string prefix,
            string nameCn,
            string nameEn,
            string nameJp,
            string birth,
            int height,
            string chest,
            string tags, //maybe array
            string pictureLink //maybe array
        );

    }
}