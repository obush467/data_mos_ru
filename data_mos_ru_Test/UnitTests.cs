using data_mos_ru.Loaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace data_mos_ru_Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Rospt_ru_Loader_Load()
        {
            Rospt_ru_Loader l = new Rospt_ru_Loader();
            l.Load(new DirectoryInfo("C:\\Users\\Bushmakin\\Downloads\\www.rospt.ru").GetFiles(), true);
        }

        [TestMethod]
        public void PostAddressTest()
        {
            var ttt = new data_mos_ru.Operators.Data_mos_ru_Operator();
            ttt.ReplacePost();

        }
    }
}