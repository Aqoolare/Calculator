using System.Numerics;


namespace CalculatorLibrary
{
    public class MPlus : MemoryCommand
    {
        public MPlus(Reciever reciever, Complex valueForMemory)
        {
            this.reciever = reciever;
            this.valueForMemory = valueForMemory;
        }
        public override void Execute()
        {
            reciever.ChangeMemory('+', valueForMemory);
        }
    }
}
