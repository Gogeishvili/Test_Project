namespace Test_Project
{
    public class BaseStateMachine<T>
    {
        public BaseState<T> currentState { get; private set; }

        protected BaseStateMachine(T i_main)
        {
            
        }
        public void SwichState(BaseState<T> i_baseState)
        {
            currentState?.Exit();
            currentState = i_baseState;
            currentState?.Enter();
        }
    }
}