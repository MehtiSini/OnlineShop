namespace _01.Framework.Domain
{
    public class EntityBase
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public EntityBase()
        {

        }
    }
}
