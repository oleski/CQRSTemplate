namespace Infrastructure.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class CollectionAccessConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Fetch.Select();
            instance.Cascade.All();
            instance.AsBag();
        }
    }
}