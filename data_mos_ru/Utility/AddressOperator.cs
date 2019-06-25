using data_mos_ru.Entities;
using System.Text.RegularExpressions;

namespace data_mos_ru.Utility
{
    public class AddressOperator
    {
        public static string CleanToSearch(string address)
        {
            Regex regex = new Regex("\\s+");
            string result = regex.Replace(address, " ");
            result = result
                    .Replace("г. ", "город ")
                    .Replace("пос. ", "посёлок ")
                    .Replace("тер. ", "территория ")
                    .Replace("\"", "")
                    .Replace(",", " ")
                    .Replace("ул.", "улица")
                    .Replace("двл.", "домовладение")
                    .Replace("д/вл.", "домовладение")
                    .Replace("д\\вл.", "домовладение")
                    .Replace("влд.", "владение")
                    .Replace("вл.", "владение")
                    .Replace("д.", "дом")
                    .Replace("корп.", "корпус")
                    .Replace("кор.", "корпус")
                    .Replace("к.", "корпус")
                    .Replace("стр.", "строение")
                    .Replace("соор.", "сооружение")
                    .Replace("пер.", "переулок")
                    .Replace("пр.", "проезд")
                    .Replace("просп.", "проспект")
                    .Replace("пл.", "площадь")
                    .Replace("ш. ", "шоссе ")
                    .Replace("наб. ", "набережная ")
                    .Replace("город Москва", "")
                    .Replace("муниципальный округ", "")
                    .Trim();
            result = regex.Replace(result, " ");
            return result;
        }
        public static string AO_60562_ToSearch(AO_60562 ao)
        {
            return CleanToSearch(string.Join(" ", ao.P2, ao.P3, ao.P4, ao.P6, ao.P7, ao.P90, ao.P91,
                ao.L1_TYPE, ao.L1_VALUE, ao.L2_TYPE, ao.L2_VALUE, ao.L3_TYPE, ao.L4_TYPE, ao.L4_VALUE, ao.L5_TYPE, ao.L5_VALUE));
        }
    }
}
