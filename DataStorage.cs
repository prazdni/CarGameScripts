public static class DataStorage
{
    public static StorageContext<string> DateTime = new StorageContext<string>(nameof(DateTime));
    public static StorageContext<int> CurrentSlotInActive = new StorageContext<int>(nameof(CurrentSlotInActive));
    public static StorageContext<int> Wood = new StorageContext<int>(nameof(Wood));
    public static StorageContext<int> Diamonds = new StorageContext<int>(nameof(Diamonds));
    public static StorageContext<int> CurrentLocale = new StorageContext<int>(nameof(CurrentLocale));
}