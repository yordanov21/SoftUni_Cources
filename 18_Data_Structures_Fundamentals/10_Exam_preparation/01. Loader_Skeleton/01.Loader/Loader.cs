namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }
        public int EntitiesCount => entities.Count;

        // O(1)
        public void Add(IEntity entity)
        {
            entities.Add(entity);
        }

        // O(n)
        public void Clear()
        {
            entities.Clear();
        }

        // O(1) O(logn)
        // O(n) 
        public bool Contains(IEntity entity)
        {
            // it can be r=made with for loop and check every emelent in the loop;
            return entities.Contains(entity); // here .Contains depend of evveriden method Equals
        }


        public IEntity Extract(int id)
        {
            IEntity entity = FindById(id);
            if (entity != null)
            {
                entities.Remove(entity);
            }

            return entity;
        }

        public IEntity Find(IEntity entity)
        {
            return FindByEntity(entity);
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(entities);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        public void RemoveSold()
        {
            List<IEntity> withoutSold = new List<IEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status != BaseEntityStatus.Sold)
                {
                    withoutSold.Add(entities[i]);
                }
            }

            entities = withoutSold;
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            int oldIdex = entities.IndexOf(oldEntity);
            CheckValidIndex(oldIdex, "Entity not fould");

            entities[oldIdex] = newEntity;

            ////in this way also work 
            //    IEntity old = FindByEntity(oldEntity);
            //    if(old == null)
            //    {
            //        throw new InvalidOperationException("Entity not found");
            //    }

            //    var idx = entities.IndexOf(oldEntity);

            //    entities[idx] = newEntity;
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            List<IEntity> inBounds = new List<IEntity>();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Status >= lowerBound && entities[i].Status <= upperBound)
                {
                    inBounds.Add(entities[i]);
                }
            }

            return inBounds;
        }

        //O(1)
        public void Swap(IEntity first, IEntity second)
        {
            int firstEntityIndex = entities.IndexOf(first);
            int secondEntityIndex = entities.IndexOf(second);
            CheckValidIndex(firstEntityIndex, "Entity not fould");
            CheckValidIndex(secondEntityIndex, "Entity not fould");

            // swap the entities
            IEntity temp = entities[firstEntityIndex];
            entities[firstEntityIndex] = entities[secondEntityIndex];
            entities[secondEntityIndex] = temp;
        }

        //O(n)
        public IEntity[] ToArray()
        {
            return entities.ToArray();
        }

        //O(n)
        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if(entities[i].Status == oldStatus)
                {
                    entities[i].Status = newStatus;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return entities.GetEnumerator();
        }

        private IEntity FindById(int id)
        {
            IEntity entity = null;
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i].Id == id)
                {
                    entity = entities[i];
                    return entity;
                }
            }

            return entity;
        }

        private IEntity FindByEntity(IEntity entity)
        {
            int index = entities.IndexOf(entity);

            if (index >= 0)
            {
                return entities[index];
            }

            return null;
        }

        private void CheckValidIndex(int index, string message)
        {
            if (index < 0)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
