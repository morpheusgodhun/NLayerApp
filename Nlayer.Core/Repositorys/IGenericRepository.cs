using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Repositorys {
    public interface IGenericRepository<T> where T : class {
        Task<T> GetByIdAsync();
        //Task<ICollection<T>> GetById() yazmamamın sebebi tek veri çekecek olmam eğer bi koleksiyon tutup bunları listelesydim getall gibi collection kullanırdık.
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<T> GetAll(Expression<Func<T, bool>> expression);
        // IQueryable dönünce direkt veritabanına gitmez tolist tolistasync gibi methodlar çağrılırsa veritabanına gideceği için kullanıyoruz.
        //örnek productRepository.Where(x=> x. Id >5) bu method sonuna orderby to list vs... gelmezse direkt veritabanına gitmez performans için iyi
        Task<T> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        //Update ve delete çok bellekte yük tutup uzun süren işlemler değil varolan üzerinden ilerliyor memory'de tuttuğu veriler üzerinden olduğü için task dönmek yerine performans açısından void dönmek daha sağlıklı   
        void Update(T Entity);
        void Remove(T Entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
