using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnThisDay.TodayEvents.Protos
{
    public partial class Headline
    {
        public static Headline FromRepositoryModel(TodayEventData.Models.Headline source)
        {
            if (source is null) return null;

            return new Headline
            {
                Main = source.Main,
                Pubdate = source.PubDate ?? string.Empty
            };
        }
    }
}
