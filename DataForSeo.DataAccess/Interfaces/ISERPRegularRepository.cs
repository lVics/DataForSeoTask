using DataForSeo.DataAccess.Entities;
using System;
using System.Threading.Tasks;

namespace DataForSeo.DataAccess.Interfaces
{
  public interface ISERPRegularRepository : IDisposable
  {
    Task<int> CreateAsync(SERPRegularEntity entity);
  }
}
