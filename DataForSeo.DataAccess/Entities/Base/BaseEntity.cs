using Dapper.Contrib.Extensions;
using System;

namespace DataForSeo.DataAccess.Entities.Base
{
  public class BaseEntity
  {
    [Key]
    public Guid ID { get; set; }
  }
}
