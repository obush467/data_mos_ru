using data_mos_ru.Loaders;
using System.IO;

namespace data_mos_ru.Operators
{
    public class Rospt_ru_Operator : Operator
    {
        Rospt_ru_Loader rospt_Ru_Loader = new Rospt_ru_Loader();
        public void AppendAddresses()
        {
            using (JSONContext context = new JSONContext("integra"))
            {

                //context.ownerRawAddresses.AddRange(rospt_Ru_Loader.Load(new DirectoryInfo("C:\\Users\\Bushmakin\\Downloads\\www.rospt.ru").GetFiles(), true));
                context.SaveChanges();
            }
        }
    }
}
