using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ObjectDAL
    {
        private static int count=0;
        public static void Counter()
        {
            count++;
        }
       // public List<ObjectModel> Objects;

        //public void AddObject(ObjectBO model)
        //{
        //    Counter();
        //    string counts = String.Format("{0:D4}", count + 1);
        //    ObjectModel newObject = new ObjectModel
        //    {
        //        Name = model.Name,
        //        Adress = model.Adress,
        //        ApplyDate = DateTime.Now,
        //        Representative = model.Representative,
        //        File = model.File,
        //        ApplyNo = "Q" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + counts

        //    };
        //    Objects.Add(newObject);
        //}

        public enum FəaliyyətSahəsi
        {
            Istehsal,
            Anbar,
            ictimaiIaşə,
            TopdanSatış,
            PərakəndəSatış
        }
    }
}
