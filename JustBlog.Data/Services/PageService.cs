//using JustBlog.Core.Common.UnitOfWork;
//using JustBlog.Core.Repositories;
//using JustBlog.Data.Common.Services;
//using JustBlog.Model;
//using JustBlog.Service;

//namespace JustBlog.Data.Services
//{
//    public class PageService : Service<Page>, IPageService
//    {
//        IUnitOfWork _unitOfWork;
//        IPageRepository _pageRepository;

//        public PageService(IUnitOfWork unitOfWork, IPageRepository pageRepository) : base(unitOfWork, pageRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _pageRepository = pageRepository;
//        }

//        public void AddorUpdate(Page page)
//        {
//            var pageItem = _pageRepository.FindById(page.PageId);
//            if (pageItem != null)
//            {
//                _pageRepository.Update(page);
//                _unitOfWork.Complete();
//            }
//            else
//            {
//                _pageRepository.Add(page);
//                _unitOfWork.Complete();
//            }
           
          
//        }
//    }
//}
