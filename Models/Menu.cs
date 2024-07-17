using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_Anhdhv.Model
{
    internal class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }

        public Menu(int id, string title, int parentId)
        {
            Id = id;
            Title = title;
            ParentId = parentId;
        }

        public override string ToString()
        {
            return $"Menu(Id: {Id}, Title: {Title}, ParentId: {ParentId})";
        }
    }
}
