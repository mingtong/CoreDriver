using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDriverBackend.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDriverBackend.Model
{
    public class CoreVideoModel : IDriverDataService
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
            var videos = db.CoreVideo.Where(v => v.ActressId == name);
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
            var videos = db.CoreVideo.Where(v => v.Tag == tag);
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
            var db = new CoreDriverContext();
            var newData = new CoreVideo();
            newData.Prefix = prefix;
            newData.Serial = int.Parse(serial);
            newData.WholeSerial = wholeSerial;
            newData.Tag = tag;
            newData.MagnetLink = magnetLink;
            newData.TorrentLink = torrentLink;
            newData.PictureLink = pictureLink;
            newData.CompanyName = companyName;

            try
            {
                var videos = db.CoreVideo.Add(newData);
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

        public string DeleteDataBy(string wholeSerial)
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
            newData.Tag = tag;
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
