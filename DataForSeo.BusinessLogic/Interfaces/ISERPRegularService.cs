using DataForSeo.BusinessLogic.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataForSeo.BusinessLogic.Interfaces
{
  public interface ISERPRegularService : IDisposable
  {
    Task<int> CreateAsync(SERPRegularDTO model);
    Task<IEnumerable<SERPRegularDTO>> GetAllAsync();
  }
}
