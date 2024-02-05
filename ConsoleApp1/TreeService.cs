using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TreeService
    {
        public  List<Node> Nodes = new List<Node>()
        {
            new Node () { Id = 1, Text = "Item 0. 1", ParentId = 0},

            new Node () { Id = 3, Text = "Item 0. 1.3", ParentId = 1},
            new Node () { Id = 4, Text = "Item 0. 1.4", ParentId = 1},
            new Node () { Id = 7, Text = "Item 0. 1.4.7", ParentId = 4},


            new Node () { Id = 2, Text = "Item 0.2", ParentId = 0},
            new Node () { Id = 5, Text = "Item 0.2.5", ParentId = 2},
            new Node () { Id = 6, Text = "Item 0.2.6", ParentId = 2},
        };
        public List<Node> GetChildren(int parentId, List<Node> comments)
        {
            var children = Nodes.Where(x => x.ParentId == parentId);

            foreach (var item in children)
            {
                comments.Add(item);
                GetChildren(item.Id, comments);
            }

            return comments;
        }

        public List<Node> GetParentsWithSelf(int? id, List<Node> comments, List<Node> data)
        {
            var node = data.Single(x => x.Id == id);
            comments.Add(node);
            if (node.ParentId == 0)
                return comments;
            GetParentsWithSelf(node.ParentId, comments, data);

            return comments;

        }


        public List<Node> GetParents(int? id, List<Node> comments, List<Node> data)
        {
            var node = data.Single(x => x.Id == id);
           
            if (node.ParentId == 0)
                return comments;
            var parent = data.Single(x => x.Id == node.ParentId);
            comments.Add(parent);
            GetParents(node.ParentId, comments, data);

            return comments;

        }
        public List<Node> GetChildren2(int parentId, List<Node> comments)
        {
            return Nodes
                .Where(c => c.ParentId == parentId)
                .Select(c => new Node
                {
                    Id = c.Id,
                    Text = c.Text,
                    ParentId = c.ParentId,

                    Children = GetChildren2(c.Id, comments)
                })
                .ToList();
        }
    }

}
