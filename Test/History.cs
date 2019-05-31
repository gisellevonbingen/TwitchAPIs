using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Test
{
    public class History<T>
    {
        private readonly List<T> List;
        public int Cursor { get; private set; }

        public History()
        {
            this.List = new List<T>();
            this.Cursor = -1;

            this.Clear();
        }

        public T Feach()
        {
            return this.Feach(this.Cursor);
        }

        public T Feach(int cursor)
        {
            var list = this.List;

            if (0 <= cursor && cursor < list.Count)
            {
                return list[cursor];
            }
            else
            {
                return default;
            }

        }

        public T Prev()
        {
            this.Cursor = Math.Max(-1, this.Cursor - 1);
            return this.Feach();
        }

        public T Next()
        {
            this.Cursor = Math.Min(this.List.Count - 1, this.Cursor + 1);
            return this.Feach();
        }

        public void Clear()
        {
            this.List.Clear();
            this.Cursor = -1;
        }

        public void RemoveAfter(int cursor)
        {
            var list = this.List;
            var startIndex = cursor + 1;
            var endIndex = list.Count;
            var removeCount = endIndex - startIndex;

            list.RemoveRange(startIndex, removeCount);
        }

        public void Record(T value)
        {
            this.RemoveAfter(this.Cursor);

            this.OnRecord(value);
        }

        protected virtual void OnRecord(T value)
        {
            var list = this.List;
            list.Add(value);
            this.Cursor = list.Count - 1;
        }

    }

}
