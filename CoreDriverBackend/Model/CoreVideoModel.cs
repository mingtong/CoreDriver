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
    public class CoreVideoModel : IVideoDataService
    {
        
        #region public interface
        
        public string GetAllData()
        {
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            foreach (var v in db.CoreVideo.ToList())
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByPrefix(string prefix)
        {
            if (string.IsNullOrEmpty(prefix.Trim()))
            {
                return string.Empty;                
            }

            prefix = prefix.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var videos = db.CoreVideo.Where(v => v.Prefix == prefix);
            foreach (var v in videos)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByWholeSerial(string wholeSerial)
        {
            if (string.IsNullOrEmpty(wholeSerial.Trim()))
            {
                return string.Empty;                
            }

            wholeSerial = wholeSerial.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var videos = db.CoreVideo.Where(v => v.WholeSerial == wholeSerial);
            foreach (var v in videos)
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
            var videos = db.CoreVideo.Where(v => v.ActressName == name);
            foreach (var v in videos)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag.Trim()))
            {
                return string.Empty;                
            }

            tag = tag.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var videos = db.CoreVideo.Where(v => v.Tags.Contains(tag));
            foreach (var v in videos)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string GetDataByCompany(string companyName)
        {
            if (string.IsNullOrEmpty(companyName.Trim()))
            {
                return string.Empty;                
            }

            companyName = companyName.Trim();
            var db = new CoreDriverContext();

            var jsonArray = new JArray();
            var videos = db.CoreVideo.Where(v => v.CompanyName == companyName);
            foreach (var v in videos)
            {
                var json = JsonConvert.SerializeObject(v);
                jsonArray.Add(json);
            }
            db.Dispose();
            
            return jsonArray.ToString();
        }

        public string AddNewData(string prefix, string serial, string wholeSerial, string nameCn, string nameEn, string nameJp,
            string tag, string magnetLink, string torrentLink, string pictureLink, string companyName)
        {
            if (string.IsNullOrEmpty(wholeSerial))
            {
                wholeSerial = prefix + "-" + serial;
            }
            else
            {
                if(wholeSerial.Contains("-"))
                {
                    var ws = wholeSerial.Split('-');
                    if (ws.Length == 2)
                    {
                        prefix = ws[0];
                        serial = ws[1];
                    }
                    
                }
            }

            var db = new CoreDriverContext();
            var data = db.CoreVideo.Where(v => v.WholeSerial == wholeSerial);
            if (data.Any())
            {
                return "502";
            }

            var newData = new CoreVideo()
            {
                Prefix = prefix,
                Serial = int.Parse(serial),
                WholeSerial = wholeSerial,
                Tags = tag,
                MagnetLink = magnetLink,
                TorrentLink = torrentLink,
                PictureLink = pictureLink,
                CompanyName = companyName,
                ActressName = nameCn
            };

            try
            {
                db.CoreVideo.Add(newData);
                
                //Add new actress
                var actress = db.CoreActress.Where(v => v.NameCn == nameCn);
                if (!actress.Any())
                {
                    var newActress = new CoreActress()
                    {
                        NameCn = nameCn,
                        NameEn = nameEn,
                        NameJp = nameJp,
                        PictureLink = pictureLink
                    };
                    db.CoreActress.Add(newActress);
                }

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

        public string AddNewData(CoreVideo newData)
        {
            var db = new CoreDriverContext();
            var data = db.CoreVideo.Where(v => v.WholeSerial == newData.WholeSerial);
            if (data.Any())
            {
                return "502";
            }


            try
            {
                db.CoreVideo.Add(newData);
                
                //Add new actress
                var actress = db.CoreActress.Where(v => v.NameCn == newData.ActressName);
                if (!actress.Any())
                {
                    var newActress = new CoreActress()
                    {
                        NameCn = newData.ActressName,
                    };
                    db.CoreActress.Add(newActress);
                }

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

        public string DeleteDataBySerial(string wholeSerial)
        {
            //var db = new CoreDriverContext();
            //db.CoreVideo.Remove();

            return "Not implemented yet";
        }

        public string ModifyData(string prefix, string serial, string wholeSerial, string nameCn, string nameEn, string nameJp,
            string tag, string magnetLink, string torrentLink, string pictureLink, string companyName)
        {
            var db = new CoreDriverContext();
            var newData = new CoreVideo();
            newData.Prefix = prefix;
            newData.Serial = int.Parse(serial);
            newData.WholeSerial = wholeSerial;
            newData.Tags = tag;
            newData.MagnetLink = magnetLink;
            newData.TorrentLink = torrentLink;
            newData.PictureLink = pictureLink;
            newData.CompanyName = companyName;
            try
            {
                db.CoreVideo.Update(newData);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "501";
            }
            finally
            {
                db.Dispose();
            }

            return "200";
        }
        
        #endregion

        #region private logic

        #endregion
    }
}
