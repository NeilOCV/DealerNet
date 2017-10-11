using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class categories
    {
        public string id { get; set; }
        public string category_description { get; set; }
        public string Create(categories obj)
        {
            string result = string.Empty;
            Guid id = Guid.NewGuid();
            obj.id = id.ToString();
            using (var EDM = new DBContext())
            {
                EDM.Categories.Add(obj);
                try
                {
                    EDM.SaveChanges();
                    result = obj.id;
                }
                catch (Exception ex)
                {
                    result = "Error!  " + ex.Message;
                }
            }
            return result;
        }
        public categories Read(string id)
        {
            using (var EDM = new DBContext())
            {
                var prog = from tb in EDM.Categories.AsNoTracking()
                           where tb.id == id
                           select tb;
                if (prog.Count() > 0)
                    return prog.ToList()[0];
                return null;
            }
        }
        public List<categories> Read()
        {
            using (var EDM = new DBContext())
            {
                var prog = from tb in EDM.Categories.AsNoTracking()
                           select tb;
                return prog.ToList();
            }
        }
        public string Update(categories obj)
        {
            using(var EDM = new DBContext())
            {
                EDM.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                try
                {
                    EDM.SaveChanges();
                    return "Updated";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
        public string Delete(categories obj)
        {
            using (var EDM = new DBContext())
            {
                EDM.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    EDM.SaveChanges();
                    return "Deleted";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
