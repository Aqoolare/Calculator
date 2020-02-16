using System.Numerics;

namespace CalculatorLibrary
{
    public class MMinus : MemoryCommand
    {
        public MMinus(Reciever reciever, Complex valueForMemory)
        {
            this.reciever = reciever;
            this.valueForMemory = valueForMemory;
        }
        public override void Execute()
        {
            reciever.ChangeMemory('-', valueForMemory);
        }
    }
}
