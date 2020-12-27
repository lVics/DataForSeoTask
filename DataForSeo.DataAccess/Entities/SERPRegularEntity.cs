using Dapper.Contrib.Extensions;
using DataForSeo.DataAccess.Entities.Base;
using DataForSeo.Shared.Enums;

namespace DataForSeo.DataAccess.Entities
{
  [Table("SERPRegular")]
  public class SERPRegularEntity : BaseEntity
  {
    public string Keyword { get; set; }
    public string Website { get; set; }
    public SearchEngine SearchEngine { get; set; }
    public int Rank_group { get; set; }
  }
}
