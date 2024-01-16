using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiaplayApp.Models;
using EmployeeRESTApi.Models;

namespace DiaplayApp.Data
{
    public class DiaplayAppContext : DbContext
    {
        public DiaplayAppContext (DbContextOptions<DiaplayAppContext> options)
            : base(options)
        {
        }

        public DbSet<DiaplayApp.Models.EditModel> EditModel { get; set; } = default!;
        public DbSet<EmployeeRESTApi.Models.EmployeeViewModel> EmployeeViewModel { get; set; } = default!;
    }
}
