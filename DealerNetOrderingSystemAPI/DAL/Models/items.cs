using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class items
    {
        #region Properties

        public string id { get; set; }
        public string description { get; set; }
        public decimal unit_price { get; set; }
        public string categories_id { get; set; }

        #endregion

        #region CRUD

        /// <summary>
        /// Called from POST
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="returnMessage"></param>
        /// <returns></returns>
        public bool Create(items obj, out string returnMessage)
        {
            Guid id = Guid.NewGuid();
            obj.id = id.ToString();
            returnMessage = id.ToString();
            using (var edc = new EDC())
            {
                edc.Items.Add(obj);
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
        public List<items> Get()
        {
            using (var edc = new EDC())
            {
                var prog = from tb in edc.Items.AsNoTracking()
                           orderby tb.description
                           select tb;
                return prog.ToList();
            }
        }
        /// <summary>
        /// Called from GET (With an ID as a parameter to get a targetted entity).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public items Get(string id)
        {
            using (var edc = new EDC())
            {
                var prog = from tb in edc.Items.AsNoTracking()
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
        public bool Update(items obj, out string returnMessage)
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
                items obj = Get(id);

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
