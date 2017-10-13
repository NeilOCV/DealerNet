using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class stock_levels
    {
        public string id { get; set; }
        public string items_id { get; set; }
        public int stock_level { get; set; }




        #region CRUD

        /// <summary>
        /// Called from POST
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public bool Create(stock_levels obj, out string returnMessage)
        {
            Guid id = Guid.NewGuid();
            obj.id = id.ToString();
            returnMessage = id.ToString();
            using (var edc = new EDC())
            {
                edc.StockLevels.Add(obj);
                try
                {
                    edc.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    returnMessage = ex.Message;
                    return false;
                }
            }
        }
        /// <summary>
        /// Called from GET (No parameter - get all)
        /// </summary>
        /// <returns></returns>
        public List<stock_levels> Get()
        {
            using (var edc = new EDC())
            {
                var prog = from tb in edc.StockLevels.AsNoTracking()
                           orderby tb.stock_level
                           select tb;
                return prog.ToList();
            }
        }
        /// <summary>
        /// Called from GET (With an ID as a parameter to get a targetted entity).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public stock_levels Get(string id)
        {
            using (var edc = new EDC())
            {
                var prog = from tb in edc.StockLevels.AsNoTracking()
                           where tb.id == id
                           select tb;
                if (prog.Count() > 0)
                    return prog.ToList()[0];
                return null;
            }
        }
        /// <summary>
        /// Called from PUT
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public bool Update(stock_levels obj, out string returnMessage)
        {
            returnMessage = string.Empty;
            using (var edc = new EDC())
            {
                edc.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    edc.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    returnMessage = ex.Message;
                    return false;
                }
            }
        }
        /// <summary>
        /// Called from DELETE
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public bool Delete(string id, out string returnMessage)
        {
            returnMessage = string.Empty;
            using (var edc = new EDC())
            {
                stock_levels obj = Get(id);

                edc.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    edc.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    returnMessage = ex.Message;
                    return false;
                }
            }
        }

        #endregion

    }
}
