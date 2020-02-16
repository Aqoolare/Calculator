using System.Numerics;

namespace CalculatorLibrary
{
    public class MC : MemoryCommand
    {
        public MC(Reciever reciever)
        {
            this.reciever = reciever;;
        }
        public override void Execute()
        {
            reciever.ChangeMemory('0', 0);
        }
    }
}
