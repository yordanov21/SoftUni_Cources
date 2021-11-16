namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Data : IRepository
    {
        private PriorityQueue<IEntity> queue;
        private Dictionary<int, IEntity> dictionary;

        // other way to represent a tree with dictionary for performance
        private Dictionary<int, List<IEntity>> parents;

        public Data()
        {
            queue = new PriorityQueue<IEntity>();
            dictionary = new Dictionary<int, IEntity>();
            parents = new Dictionary<int, List<IEntity>>();
        }

        public Data(PriorityQueue<IEntity> queue, Dictionary<int, IEntity> dictionary, Dictionary<int, List<IEntity>> parents)
        {
            this.queue = queue;
            this.dictionary = dictionary;
            this.parents = parents;
        }
        public int Size => queue.Size;

        public void Add(IEntity entity)
        {
            queue.Add(entity);
            dictionary.Add(entity.Id, entity);

            if (entity.ParentId != null)
            {
                if (!parents.ContainsKey((int)entity.ParentId))
                {
                    parents.Add((int)entity.ParentId, new List<IEntity>());
                }

                parents[(int)entity.ParentId].Add(entity);
            }


        }

        public IRepository Copy()
        {
            var result = new Data();
            result = this;
            return result;

            // it's work in this way too
            // return new Data(this.queue, this.dictionary, this.parents);
        }

        public IEntity DequeueMostRecent()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            var element = queue.Dequeue();
            dictionary.Remove(element.Id);
            return element;
        }

        public List<IEntity> GetAll()
        {
           
            return new List<IEntity>(queue.GetList); // to use this you should make public property that return list in the ptreority queue!!

            //List<IEntity> result = new List<IEntity>();
            //if (Size > 0)
            //{
            //    var temp = queue;
            //    while(temp.Size>0)
            //    {
            //        result.Add(temp.Dequeue());                
            //    }
            //}
            //return result;
        }

        public List<IEntity> GetAllByType(string type)
        {
            List<IEntity> result = new List<IEntity>();

            if(!(type == "User" || type == "StoreClient" || type == "Invoice"))
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            result = queue.GetList.Where(e => e.GetType().Name == type).ToList();
            return result;
        }

        public IEntity GetById(int id)
        {

            if(!dictionary.ContainsKey(id))
            {
                return null;
            }

            return dictionary[id];
            //var allElements = GetAll();

            //for (int i = 0; i < allElements.Count; i++)
            //{
            //    if(allElements[i].Id == id)
            //    {
            //        return allElements[i];
            //    }
            //}

            //return null;
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            // return queue.GetList.FindAll(x =>x.ParentId == parentId);

            // faster way
            if (!parents.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }

            return parents[parentId];
        }

        public IEntity PeekMostRecent()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }

            return queue.Peek();
        }
    }
}
