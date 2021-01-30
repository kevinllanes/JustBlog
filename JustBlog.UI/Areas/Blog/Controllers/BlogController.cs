using JustBlog.Core.Common.UnitOfWork;
using JustBlog.Model;
using JustBlog.Service;
using JustBlog.UI.Areas.Blog.Models;
using JustBlog.UI.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace JustBlog.UI.Areas.Blog.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region PageTab
        public ActionResult LoadPageTab()
        {
            try
            {
                var pageList = _unitOfWork.pageRepository.GetAll().ToList();
                return Json(pageList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult GetPageById(int pageId)
        {
            var id = _unitOfWork.pageRepository.FindById(pageId);
            return Json(id,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddorUpdatePage(Page viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Page
                    {
                        PageId=viewModel.PageId,
                        Title = viewModel.Title,
                        PagesContent = viewModel.PagesContent,
                        CreateTime = DateTime.Now,
                        UpdateTime = viewModel.UpdateTime
                    };
                    var id = _unitOfWork.pageRepository.FindById(model.PageId);
                    if (id != null)
                    {
                        model.UpdateTime = DateTime.Now;
                        _unitOfWork.pageRepository.Detach(id);
                        _unitOfWork.pageRepository.Update(model);
                        _unitOfWork.Complete();
                    }
                    else
                    {
                        _unitOfWork.pageRepository.Add(model);
                        _unitOfWork.Complete();
                    }
                }
                return new EmptyResult();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region PostTab
        public ActionResult LoadPostTab()
        {
            try
            {
                var postList = _unitOfWork.postRepository.GetAll().ToList();
                return Json(postList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region CategoryTab
        public ActionResult LoadCategoryTab()
        {
            try
            {
                var postList = _unitOfWork.categoryRepository.GetAll().ToList();
                return Json(postList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult GetCategoryById(int categoryId)
        {
            var id = _unitOfWork.categoryRepository.FindById(categoryId);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddorUpdateCategory(Category viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new Category
                    {
                        CategoryId = viewModel.CategoryId,
                        CategoryName = viewModel.CategoryName,
                        Description = viewModel.Description,
                        CreateTime = DateTime.Now,
                        Frequence = viewModel.Frequence
                    };
                    var id = _unitOfWork.categoryRepository.FindById(model.CategoryId);
                    if (id != null)
                    {
                        _unitOfWork.categoryRepository.Detach(id);
                        _unitOfWork.categoryRepository.Update(model);
                        _unitOfWork.Complete();
                    }
                    else
                    {
                        _unitOfWork.categoryRepository.Add(model);
                        _unitOfWork.Complete();
                    }
                }
                return new EmptyResult();

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}