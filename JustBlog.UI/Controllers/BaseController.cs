using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JustBlog.UI.Controllers
{
    public class BaseController:Controller
    {
        private IMapper _mapper;

        public BaseController()
        {

        }

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDest MapSourceToDest<TSource, TDest>(TSource source)
        {
            return _mapper.Map<TSource, TDest>(source);
        }
        public List<TDest> MapSourceListToDestList<TSource, TDest>(List<TSource> source)
        {
            return _mapper.Map<List<TSource>, List<TDest>>(source);
        }
        public IEnumerable<TDest> MapSourceListToDestEnumerable<TSource, TDest>(IEnumerable<TSource> source)
        {
            return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDest>>(source);
        }
    }
}