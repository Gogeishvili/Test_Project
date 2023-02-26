namespace Test_Project
{
    public abstract class BaseMode<T>
    {
        protected T _main;

        public BaseMode(T i_main)
        {
            _main = i_main;
        }

        public abstract void On();
        public abstract void Off();
    }
}