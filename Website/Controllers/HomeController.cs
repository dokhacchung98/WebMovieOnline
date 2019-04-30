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
        private readonly ITrailerService _trailersService;


        public HomeController(ITrailerService trailersService, IMoviesService moviesService)
        {
            _trailersService = trailersService;
            _moviesService = moviesService; 
        }
        
        // à này, cái hàm khởi tạo này, có truyền luôn movies vaofd dược không? na
        //ô dùng cái gì thì ô truyền, vì thằng constructor này nó khởi tạo sẵn rồi, nên ô ko cần phảipasas=new mmovie...
        //ô cần dùng movie thì ô truyền vào
        //ta tạo function để lấy ra phim hot nhé ;)
        //nhớ bắt đầu từ đâu ko
        //tạo cái j trước ấy, tầng nào trc
        //uk => repository trước nè 
        //xong 2 cái tầng đó rồi => tạo constructor để lấy ra
        // giờ chỉ việc lấy ra dùng thôi
        public ActionResult Index()
        {
            /*
             
            //lấy ra 10 phần tử movie hot nhất mới nhất
            //chuyển dạng Movie => MovieViewModel để hiển thị lên View sử dụng automap
            //neesu chayj như này thì sẽ báo lỗi lý do là nó ko thể chuyển lít<movie> => movie view model được=> nên ta thêm ICole...
            //chỗ này hiểu ko ok=> giờ chuyền sang bên view thôi
            var listMovieHot = _moviesService.GetMovieHotByNumber(10);
            
            var listMovieHotViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovieHot);

            ViewBag.SyHocGioi = listMovieHotViewModel;//tên sau viewbag tự đặt, nhưng sang bên view phải giống

            return View(listMovieHotViewModel);
            //chạy thôi

             */
            //vãi nồi nhìn nhé: ô truyền đây là kiểu gì: listNewTraillerViewModel còn sang bên view nè MoviesViewModel thấy ỗi chưa men
            //đâu r chả :'( đâu nhỉ
            //đây: ở bên controller ô truyền sang bên view là kiểu trailerviewmodel đúng ko
            //mà bên view thì lại yêucaaiu movieviewmocel
            //hiểu cái này ko
            
            var listNewTrailer = _trailersService.GetNewTrailerByNumber(10);
            var listNewTrailerViewModel = AutoMapper.Mapper.Map<ICollection<TrailerViewModel>>(listNewTrailer);
            ViewBag.ListNewTrailer = listNewTrailerViewModel;

            var listMovie = _moviesService.GetAll();
            var listMovieViewModel = AutoMapper.Mapper.Map<ICollection<MoviesViewModel>>(listMovie);
            //ô để ý cái thằng return nè, bên trong tham số ô truyền kiểu gì
            // nhưng chỉ return được 1 view, trong khi bên kia cần dùng cả trailer và movie ý
            //:v ko, ý t ko phải thế, mà ô thấy ô truyền cả 2 kiểu nhưng vẫn là 1 dữ liệu ko :v ko @@
            //vãi, đây nhé, viewbag là cách truyền mà ko quan tâm đến thằng @model bên view
            //nên cái viewbag ô truyền 100 kiểu dữ liệu cũng dc hết á
            //còn cái @model bên view chỉ tiếp nhận 1 kiểu dữ liệu đúng ko, nên bên controller truyền dữ liệu sang đó bằng cách return View(dữ liệu mà bên kia cần sẽ truyền vào đây)
            // thế giờ là phải thêm một loạt để truyền được list movie nhỉ
            //uk, lít movie có sẵn rồi lấy ra dùng thôi, để t hướng dẫn cách truyền bằng model, qua t nói về viewbag rồi nhỉ
            //để ý nhé, viewbag thì bên kia ko quan trọng cái @model, chỉ quan tâm viewbag.cái khỉ gì đó có viết đúng chính tả hay ko thôi :v
            //bên view có thể xóa dòng này @model ICollection<Website.ViewModel.MoviesViewModel>
            //hoặc có cũng ko sao hết
            //cái này hiểu cách truyền qua viewbag rồi đúng ko
            // ừ cái viewbag thì ok, 
            //cách thứ 2 là qua model, thì bên view nó sẽ yêu cầu bên controller gửi nó dữ liệu thông qua kiểu nó yêu cầu
            //bằng dòng @model --trong này là kiểu nhé-- hiểu chỗ này chứ
            // cái return view() này là dùng cho cái model à
            //chuẩn rồi, nên bên controller ô bắt buộc phải truyền đúng kiểu, trong view truyền nhiều tham số được khong, 
            //mặc định là ko có tham số, và nhiều nhất là 2 tham số, 1 tham số đầu là tên view, tham số 2 là dữ liệu
            //đây nhé, ô đang định truyền sang bên view 1 lít movie đúng ko? đến đây đúng ý ô ko
            // giờ là t đang truyền được cái traller rồi, cần truyền movie nữa thôi
            //ok nhé, trailler ô truyền bằng cách sử dụng viiewbag rồi, h movie t dùng cách 2 nhé
            //đầu tiên là lấy dữ liệu
            //cho ô code đấy ;)
            // nhưng mà trong repository với service chưa có ấy, ô định lấy theo cái gì thế
            //lấy hết movie, lấy movie mới hay là lấy theo gì
            //là ok, lấy hết thì không cần thêm mấy cái kia nhỉ
            //uk, mặc định có sẵn hàm getall để lấy hết r, code đi men
            //đợi 15s nhé. srrrrr UK
            //ok rồi đó ;), giờ sang view n
            // mắt tinh vcc 
            return View(listMovieViewModel);
        }

    }
}