using Common.GenericRepository;
using Infrastructure.DataContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public class MoviesRepository : GenericRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<Movie> GetAllFeatureMovies()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == false).ToList();
        }

        public ICollection<Movie> GetAllSeriesTV()
        {
            return _dbContext.Movies.Where(t => t.IsSeriesMovie == true).ToList();
        }

        /*đây là hàm thực thi nè
        public ICollection<Movie> GetMovieHotByNumber(int countMovie)
        {
            //đầu tiên là:model hoặc đặt tên gì cũng dc nhé
            //cuối cùng phải .ToList để convert nó về dạng lít, nếu ko có mặc định là kiểu iqueryable : giống sql là câu truy vấn chứ ko phải kiểu
            //quên cái count movie nè, lấy ra bao nhiêu phần tử thì dùng .take
            //tuy nhieenn cái khỉ này nó ko sắp xếp theo thời gian, mà mình chỉ muốn lấy ra những phần tử là mới nhất => ỏderby theo createDate
            //có chỗ nào ko hiểu ko
            //xong repo rooifi => sẻvice
            return _dbContext.Movies.Where(t => t.IsHot == true).OrderBy(t => t.CreatedDate).Take(countMovie).ToList();
        }
        */

        public ICollection<Movie> SearchMovieByName(string name)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name)).ToList();
        }

        public ICollection<Movie> SearchMovieByNameAndType(string name, bool isSeriesTV)
        {
            return _dbContext.Movies.Where(t => t.Name.Contains(name) && t.IsSeriesMovie == isSeriesTV).ToList();
        }
    }
}

