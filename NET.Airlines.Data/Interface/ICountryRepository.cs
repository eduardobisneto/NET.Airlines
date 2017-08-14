﻿using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Airlines.Data.Interface
{
    public interface ICountryRepository : IRepository<Country>
    {
        IEnumerable<Data.DTO.Country> GetAllCountries(Entity.Country entity);
    }
}
