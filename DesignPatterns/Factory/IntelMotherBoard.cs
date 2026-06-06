namespace API_DesignPattern.DesignPatterns.Factory
{
    public abstract class IntelMotherBoard
    {
        protected abstract MotherBoard GetMotherBoard();

        public string ProcessMotherBoard()
        {
            var motherboard = GetMotherBoard();
            //Console.WriteLine( " Intel Mother board process"
            //    +GetMotherBoard().GetType().Name);

            return " Intel Mother board process"
                + GetMotherBoard().GetType().Name;
        }
    }

    public class BoardFor_Hp : IntelMotherBoard
    {
        protected override MotherBoard GetMotherBoard()
        {
            return new BSeriousBoard();
        }
    }

    public class BoardFor_Dell : IntelMotherBoard
    {
        protected override MotherBoard GetMotherBoard()
        {
            return new ZSeriousBoard();
        }
    }



    public class MotherBoard { }

    public class BSeriousBoard:MotherBoard { }
    public class ZSeriousBoard:MotherBoard{ }
}
