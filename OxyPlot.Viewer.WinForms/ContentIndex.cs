using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.Viewer.WinForms
{
    public class ContentIndex
    {
        private Dictionary<Guid, MovableDockContent> Data = new Dictionary<Guid, MovableDockContent>();

        public void Add(MovableDockContent content)
        {
            this.Data.Add(content.Id, content);
        }

        public void Remove(MovableDockContent content)
        {
            this.Data.Remove(content.Id);
        }

        public bool TryGet(Guid id, out MovableDockContent output)
        {
            return this.Data.TryGetValue(id, out output);
        }
    }
}
