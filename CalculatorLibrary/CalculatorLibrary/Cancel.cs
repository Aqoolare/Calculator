namespace CalculatorLibrary
{
    public class Cancel : Command
    {
        public Cancel(Reciever reciever)
        {
            this.reciever = reciever;
        }
        public override void Execute()
        {
            reciever.CancelOperation();
        }
    }
}
