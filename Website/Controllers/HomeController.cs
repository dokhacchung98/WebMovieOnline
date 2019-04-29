using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.ViewModel;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;

        public HomeController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        //ta tạo function để lấy ra phim hot nhé ;)
        //nhớ bắt đầu từ đâu ko
        //tạo cái j trước ấy, tầng nào trc
        //uk => repository trước nè 
        //xong 2 cái tầng đó rồi => tạo constructor để lấy ra
        // giờ chỉ việc lấy ra dùng thôi
        public ActionResult Index()
        {
            //lấy ra 10 phần tử movie hot nhất mới nhất
            var listMovieHot = _moviesService.GetMovieHotByNumber(10);
            //chuyển dạng Movie => MovieViewModel để hiển thị lên View sử dụng automap
            //neesu chayj như này thì sẽ báo lỗi lý do là nó ko thể chuyển lít<movie> => movie view model được=> nên ta thêm ICole...
            //chỗ này hiểu ko ok=> giờ chuyền sang bên view thôi
            var listMovieHotViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovieHot);

            ViewBag.SyHocGioi = listMovieHotViewModel;//tên sau viewbag tự đặt, nhưng sang bên view phải giống

            return View(listMovieHotViewModel);
            //chạy thôi
        }

    }
}