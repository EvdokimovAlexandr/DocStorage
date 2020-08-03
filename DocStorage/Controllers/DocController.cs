using DocStorage.Data;
using DocStorage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace DocStorage.Controllers
{
    public class DocController : Controller
    {
        DocRepo docRepo;
        public DocController()
        {
            this.docRepo = new DocRepo();
        }
        [HttpGet]

        public ActionResult Menu()
        {
            return PartialView();
        }

        public ActionResult Index()
        {
            var docs = docRepo.GetDocs();
            List<DocDto> docDtos = ConvertDocToDocDto(docs);
            return View(docDtos);
        }

        [HttpGet]
        public ActionResult NewDoc()
        {
            return View(new DocDto());
        }

        [HttpPost]
        public ActionResult NewDoc(DocDto docDto, HttpPostedFileBase upload)
        {

            Doc doc = GetDoc(docDto);
            var filename = Path.GetFileName(upload.FileName);
            var path = Path.Combine(Server.MapPath("~/DocFiles/"), filename);
            var folder = Path.GetDirectoryName(path);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            upload.SaveAs(path);
            doc.RefFile = Path.Combine("/DocFiles/", filename);
            docRepo.AddDoc(doc);
            return Redirect("/Doc/Index");
        }

        private Doc GetDoc(DocDto docDto)
        {
            var doc = new Doc();

            doc.DateOfCreation = DateTime.Today;
            doc.DocType = docDto.DocType;
            doc.Title = docDto.Title;
            doc.Author = Server.UrlDecode(Request.Cookies["user"].Value);

            return doc;
        }

        private List<DocDto> ConvertDocToDocDto(List<Doc> docs)
        {
            List<DocDto> docDtos = new List<DocDto>();
            foreach (var doc in docs)
            {
                DocDto docDto = new DocDto();
                docDto.Title = doc.Title;
                docDto.Author = doc.Author;
                docDto.DateOfCreation = doc.DateOfCreation;
                docDto.DocId = doc.DocId;
                docDto.RefFile = doc.RefFile;
                docDto.DocType = doc.DocType;
                docDtos.Add(docDto);
            }

            return docDtos;
        }
    }
}