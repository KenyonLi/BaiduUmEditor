using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
namespace UEditor.Core
{
    /// <summary>
    /// 在线管理文件
    /// </summary>
    public class DeleteFileHandler : Handler
    {
        public DeleteFileHandler(HttpContext context) : base(context) { }

        public override void Process()
        {
            var path = base.Request["path"];//路径
            var physFilePath = $"{ base.Context.Server.MapPath("/")}{path}";
            if (File.Exists(physFilePath))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(physFilePath);
                    fileInfo.Attributes = FileAttributes.Normal;
                    File.Delete(physFilePath);
                    WriteJson(new
                    {
                        state = "SUCCESS",
                    });
                }
                catch (Exception ex)
                {
                    WriteJson(new
                    {
                        state = "error",
                        error = ex.Message
                    });
                }
            }
        }
    }
}