using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace data_mos_ru
{
    public class UNSdbConfiguration : DbConfiguration
    {
        public UNSdbConfiguration()
        {
            //SetExecutionStrategy("System.Data.SqlClient",, () => new Sql());
            SetDefaultConnectionFactory(new SqlConnectionFactory("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;"));
        }
    }
}
