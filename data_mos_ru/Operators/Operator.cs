using data_mos_ru.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UNS.Models.Entities;
using UNS.Models;

namespace data_mos_ru.Operators
{
    public class Operator
    {
        public JSONContext ContextMain { get; set; }

        public UNSModel ContexUNS { get; set; }
        protected string ConnectionString { get; set; }
        public Operator()
        {
            log4net.Config.XmlConfigurator.Configure();
            //Logger.itLogger();
        }
        public Operator(string сonnectionString) : this()
        {
            ConnectionString = сonnectionString;
            ContextMain = new JSONContext(сonnectionString);
            ContexUNS = new UNSModel("Data Source=BUSHMAKIN;Initial Catalog=UNS;Integrated Security=True;");
        }

        public delegate void UpdateDelegate<T>(T X);
        public void Update<T>(List<T> input, UpdateDelegate<T> updater)
        {
            foreach (T ao in input)
            { updater(ao); }
        }
        public delegate void UpdateDelegateTwo<T>(T X);
        public delegate object ComparerDelegate<T>(T x);
        public void Update<T>(IEnumerable<IQueryable<T>> input, UpdateDelegateTwo<T> updater, Expression<Func<Data_2624_8684, object>> comparer)
        {
            int counter = 0;
            foreach (IEnumerable<T> block in input)
                using (JSONContext context = new JSONContext(ConnectionString))
                {
                    foreach (T row in block)
                    {
                        updater(row);
                    }
                    //context.AddOrUpdate(comparer, block.ToArray());
                    Logger.Logger.Info(string.Join(" ", typeof(Data_2624_8684).Name, "Сохранено", block.Count().ToString(), "всего", counter.ToString()));
                    context.SaveChanges();
                }
        }
    }
}
