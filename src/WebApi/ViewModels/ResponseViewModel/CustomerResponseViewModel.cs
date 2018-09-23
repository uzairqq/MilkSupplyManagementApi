using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace WebApi.ViewModels.ResponseViewModel
{
    public class CustomerResponseViewModel : BaseEntity
    {
        public string Name { get; set; }
    }
}
