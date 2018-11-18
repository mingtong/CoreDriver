using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDriverBackend.DataService;
using CoreDriverBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDriverBackend.Model
{
    public class CoreActressModel : IActressDataService
    {
        public string GetAllData()
        {
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            foreach (var v in db.CoreActress.ToList())
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByNameCn(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                return string.Empty;                
            }

            name = name.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var actresses = db.CoreActress.Where(v => v.NameJp == name);
            foreach (var v in actresses)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByNameJp(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
            {
                return string.Empty;                
            }

            name = name.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var actresses = db.CoreActress.Where(v => v.NameCn == name);
            foreach (var v in actresses)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByTags(string tag)
        {
            if (string.IsNullOrEmpty(tag.Trim()))
            {
                return string.Empty;                
            }

            tag = tag.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var videos = db.CoreActress.Where(v => v.Tags.Contains(tag));
            foreach (var v in videos)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string AddNewData(string nameCn, string nameEn, string nameJp, string birth, int height, string chest, string tags,
            string pictureLink)
        {
            var db = new CoreDriverContext();
            var newData = new CoreActress()
            {
                NameCn = nameCn,
                NameEn = nameEn,
                NameJp = nameJp,
                Birth = birth,
                Height = height,
                Chest = chest,
                Tags = tags,
                PictureLink = pictureLink
            };

            try
            {
                db.CoreActress.Add(newData);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "501";
                //throw;
            }
            finally
            {
                db.Dispose();
            }

            return "200";
        }

        public string AddNewData(string json)
        {
            return "";
        }

        public string DeleteDataByName(string nameCn)
        {
            return "NotImplementedException";
        }

        public string ModifyData(string prefix, string nameCn, string nameEn, string nameJp, string birth, int height, string chest,
            string tags, string pictureLink)
        {
            var db = new CoreDriverContext();
            var newData = new CoreActress()
            {
                NameCn = nameCn,
                NameEn = nameEn,
                NameJp = nameJp,
                Birth = birth,
                Height = height,
                Chest = chest,
                Tags = tags,
                PictureLink = pictureLink
            };

            try
            {
                db.CoreActress.Update(newData);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "501";
                //throw;
            }
            finally
            {
                db.Dispose();
            }

            return "200";
        }
    }
}
