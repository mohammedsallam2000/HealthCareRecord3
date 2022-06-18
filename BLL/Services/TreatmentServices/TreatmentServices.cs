using DAL.Database;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.TreatmentServices
{
    public class TreatmentServices : ITreatmentServices
    {
        private readonly AplicationDbContext context;

        public TreatmentServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #region Get Treatment Notes
        public string GetNotes(int id)
        {
            return context.Treatment.Where(x => x.Id == id).Select(x => x.Notes).FirstOrDefault();
        }
        #endregion
    }
}
