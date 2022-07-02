using Base.Models;
using Base.Services;
using BaseApi.Controllers;
using BaseApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MyHttpController : ApiCtrl
    {
        [HttpPost]
        public string KeyStr(string str1, string str2)
        {
            return $"by server: str1={str1}, str2={str2}";
        }

        [HttpPost]
        public JObject JsonJson(IdStrDto model)
        {
            return _Model.ToJson(model);
        }

        [HttpPost]
        public async Task<FileResult> GetImage(string str)
        {
            var path = $"{_Fun.DirRoot}_download/cat.jpg";
            return await _WebFile.ViewFileAsync(path, "cat.jpg");
        }

        [HttpPost]
        public string UploadZip(string str, IFormFile file)
        {
            var toDir = $"{_Fun.DirRoot}_upload";
            using var stream = file.OpenReadStream();
            using var archive = new ZipArchive(stream);
            archive.ExtractToDirectory(toDir);
            return $"unzip to _upload folder.";
        }

        /*
        [HttpPost]
        public void DownloadZip(string str)
        {
            var path = "";
            return;
        }
        */

    }//class
}
