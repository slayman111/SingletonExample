namespace ConsoleApp1
{
    public interface IElement
    {
        IElement Registry<T>(); //регистрация типа сущности
        IElement Drop(object obj); //удаление сущности
        IElement Drop<T>(); //удаление типа сущности
        int CountOfType<T>(); //кол-во сущностей указанного типа
        T GetFirstOfType<T>(); //получение первой сущности указанного типа
        bool Contains(object obj); //проверка наличия сущности
        bool Contains<T>(); //проверка наличия типа сущности
        object GetOrAdd(object obj); //получение или добавление
    }
}