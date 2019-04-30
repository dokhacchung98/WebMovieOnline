using Common.GenericRepository;
using Infrastructure.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Repositories
{
    public interface IMoviesRepository : IGenericRepository<Movie>
    {
        ICollection<Movie> GetAllFeatureMovies();

        ICollection<Movie> GetAllSeriesTV();

        ICollection<Movie> SearchMovieByName(string name);

        ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV);

        // mà có thể hàm này dùng nhiều chỗ, như trang chủ thì lấy ra 10 phần từ,trang khỉ gió nào đó lại lấy ra 40 phần tử =>> tham số
        //đầu tiên bên interface nè, ta muốn lấy ra 1 list movie => kiểu trả về là I gì cũng dc :D(IList, ICollection, IEnbl...)
        //ICollection<Movie> GetMovieHotByNumber(int countMovie);
        


    }
}