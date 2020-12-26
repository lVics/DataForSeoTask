using DataForSeo.BusinessLogic.DTOModels;
using DataForSeo.BusinessLogic.Interfaces;
using DataForSeo.DataAccess.Entities;
using DataForSeo.DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

namespace DataForSeo.BusinessLogic.Services
{
  public class SERPRegularService : ISERPRegularService
  {
    protected ISERPRegularRepository _repository;

    public SERPRegularService(ISERPRegularRepository repository)
    {
      _repository = repository;
    }

    public async Task<int> Create(SERPRegularDTO model)
    {
      return await _repository.CreateAsync(
        new SERPRegularEntity()
        {
          Keyword = model.Keyword,
          SearchEngine = model.SearchEngine,
          Website = model.Website,
          Rank_group = model.Rank_group
        });
    }

    public virtual void Dispose()
    {
      _repository.Dispose();
      GC.SuppressFinalize(this);
    }

    ~SERPRegularService()
    {
      _repository.Dispose();
    }
  }
}
