using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.AccountManagement.BLL.Common.UserAccount.Entities
{
    /// <summary>
    /// Country Entity
    /// </summary>
    public class Country
    {
        public string Id { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string Iso3 { get; set; }
        public string NumCode { get; set; }
        public string PhoneCode { get; set; }
        public int? SortIndex { get; set; }
    }
}
