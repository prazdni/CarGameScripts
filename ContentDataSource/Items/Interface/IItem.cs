namespace CarGameScripts.ContentDataSource.Items.Interface
{
    public interface IItem
    {
        int ID { get; }
        ItemInfo Info { get; }
    }
}