using DAL.Database;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.SurgeryServices
{
    public class SurgeryServices : ISurgeryServices
    {

        #region Fields
        private readonly AplicationDbContext context;
        #endregion

        #region Ctor
        public SurgeryServices(AplicationDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create Surgery
        public async Task<int> Create(SurgeryViewModel model)
        {
            try
            {
                Surgery obj = new Surgery();
                var data = context.Surgery.Where(x => x.Name == model.Name).ToList();
                if (data == null || data.Count == 0)
                {
                    obj.Name = model.Name;
                    obj.State = true;
                    obj.Price = model.Price;
                    obj.Delete = false;
                    int res = await context.SaveChangesAsync();
                    if (res > 0)
                    {
                        return obj.Id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }             
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Delete Surgery
        public bool Delete(int id)
        {
            try
            {
                var data = context.Surgery.Where(x => x.Id == id).FirstOrDefault();
                data.Delete = true;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region Edit Surgery
        public async Task<int> Edit(SurgeryViewModel model)
        {
            try
            {
                var OldData = context.Surgery.FirstOrDefault(x => x.Id == model.Id);
                OldData.State = model.State;
                OldData.Name = model.Name;
                OldData.Price = model.Price;
                 context.SaveChanges();
               
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region Get All Surgery
        public IEnumerable<SurgeryViewModel> GetAll()
        {
            try
            {
                return context.Surgery
                                .Where(x => x.State == true)
                                       .Select(x => new SurgeryViewModel
                                       {
                                           Id = x.Id,
                                           Name = x.Name,
                                           Price = x.Price,
                                           State = x.State
                                       });
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get All Surgery Deleted
        public IEnumerable<SurgeryViewModel> GetAllDeleted()
        {
            List<SurgeryViewModel> list = new List<SurgeryViewModel>();
            foreach (var item in context.Surgery.Where(x => x.Delete == true))
            {
                var data = new SurgeryViewModel
                {
                    Name = item.Name,
                    Price = item.Price,
                    State = item.State
                };
                list.Add(data);
            }
            return list;
        }

        #endregion

        #region Get Surgery
        public SurgeryViewModel GetByID(int id)
        {
            try
            {
                var surgery = context.Surgery.Where(x => x.Id == id)
                                    .Select(x => new SurgeryViewModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Price = x.Price,
                                        State = x.State
                                    })
                                    .FirstOrDefault();
                return surgery;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Get Price Of Surgery
        public decimal GetPrice(string name)
        {
            var data = context.Surgery.Where(x => x.Name == name).First();
            return data.Price;
        }
        #endregion

        #region Update Delete
        public bool UpdateDelete(int id)
        {
            try
            {
                var data = context.Surgery.Where(x => x.Id == id).FirstOrDefault();
                data.Delete = false;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

    }
}
