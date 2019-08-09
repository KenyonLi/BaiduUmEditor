using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 在线管理文件
/// </summary>
public class DeleteFileHandler : Handler
{
    public DeleteFileHandler(HttpContext context) : base(context) { }

    public override void Process()
    {
        var path = base.Request["path"];//路径
        WriteJson(new
        {
            state = "SUCCESS",
        });
    }
}
