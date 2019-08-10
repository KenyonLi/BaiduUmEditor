using UEditor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UEditor.WebApp.Controllers
{
    public class EditorUploadController : Controller
    {
        // GET: EditorUpload
        public void Index()
        {
            var context = System.Web.HttpContext.Current;
            UEditorController.ProcessRequest(context);
        }
    }
}