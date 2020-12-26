using System;
using System.Data;
using System.Data.SqlClient;

namespace DataForSeo.DataAccess.Repositories.Dapper.Base
{
  public class BaseRepository : IDisposable
  {
    protected IDbConnection _db;

    public BaseRepository(string connectionString)
    {
      _db = new SqlConnection(connectionString);
    }

    public virtual void Dispose()
    {
      _db.Dispose();
      GC.SuppressFinalize(this);
    }

    ~BaseRepository()
    {
      _db.Dispose();
    }
  }
}
