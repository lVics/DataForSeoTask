using DataForSeo.DataAccess.Entities;
using DataForSeo.DataAccess.Interfaces;
using DataForSeo.DataAccess.Repositories.Dapper.Base;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DataForSeo.DataAccess.Repositories.Dapper
{
  public class SERPRegularRepository : BaseRepository, ISERPRegularRepository
  {
    public SERPRegularRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<int> CreateAsync(SERPRegularEntity entity)
    {
      return await _db.InsertAsync(entity);
    }
  }
}
