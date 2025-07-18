using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace url_shortener.Data.Settings;
public record DefaultDatabaseSettings(string ConnectionStringName)
{
    public static string SectionName = nameof(DefaultDatabaseSettings);
}
