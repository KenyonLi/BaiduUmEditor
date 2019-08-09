using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiduUmEditorWebApp.Controllers
{
    public class EditorUploadController : Controller
    {
        // GET: EditorUpload
        public void Index()
        {
            var context = System.Web.HttpContext.Current;
            ProcessRequest(context);
        }


        private void ProcessRequest(HttpContext context)
        {
            Handler _action = null;
            switch (context.Request["action"])
            {
                case "config":
                    _action = new ConfigHandler(context);
                    break;
                case "uploadimage":
                    _action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    });
                    break;
                case "uploadscrawl":
                    _action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    });
                    break;
                case "uploadvideo":
                    _action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName")
                    });
                    break;
                case "uploadfile":
                    _action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    });
                    break;
                case "listimage":
                    _action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"));
                    break;
                case "listfile":
                    _action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"));
                    break;
                case "listvideo":
                    _action = new ListFileManager(context, Config.GetString("videoManagerListPath"), Config.GetStringList("videoManagerAllowFiles"));
                    break;
                case "catchimage":
                    _action = new CrawlerHandler(context);
                    break;

                case "deletefile":
                    _action = new DeleteFileHandler(context); //删除文件
                    break;
                default:
                    _action = new NotSupportedHandler(context);
                    break;
            }
            _action.Process(); //执行方法
        }
    }
}