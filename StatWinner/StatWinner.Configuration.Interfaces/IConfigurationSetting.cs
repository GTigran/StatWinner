using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatWinner.Configuration.Interfaces
{
    /// <summary>
    /// Interface holding single configuration Setting
    /// </summary>
    public interface IConfigurationSetting
    {
        string Id { get; set; }

        /// <summary>
        /// Name of the field
        /// </summary>
        string FieldName { get; set; }

        /// <summary>
        /// Value of the field
        /// </summary>
        object FieldValue { get; set; }

        bool IsDeleted { get; set; }
    }
}
