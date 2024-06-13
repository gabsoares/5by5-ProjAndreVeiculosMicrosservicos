using Models;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DependentService
    {
        private DependentRepository _dependentRepository;

        public DependentService()
        {
            _dependentRepository = new DependentRepository();
        }

        public string Insert(Dependent dependent)
        {
            return _dependentRepository.Insert(dependent);
        }

        public List<Dependent> GetAllDependents()
        {
            return _dependentRepository.GetAllDependents();
        }
    }
}