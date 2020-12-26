using DataForSeo.BusinessLogic.DTOModels;
using System;
using System.Threading.Tasks;

namespace DataForSeo.BusinessLogic.Interfaces
{
  public interface ISERPRegularService : IDisposable
  {
    Task<int> Create(SERPRegularDTO model);
  }
}
