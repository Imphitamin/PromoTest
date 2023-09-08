namespace PromoTest.Project.BusinessLogic.Interfaces.Factories
{
    public interface IFactoryObject
    { }

    public interface IFactoryObject<in TParam1> : IFactoryObject
    {
        void OnCreate(TParam1 parentScrollRect);
    }
    
    public interface IFactoryObject<in TParam1, in TParam2> : IFactoryObject
    {
        void OnCreate(TParam1 param1, TParam2 param2);
    }
}