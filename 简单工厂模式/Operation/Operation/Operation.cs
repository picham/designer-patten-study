using System;

namespace Operation
{
   public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;

        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }

        public double NumberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }
        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA + NumberB;
            return result;
        }
    }
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }

    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            result = NumberA * NumberB;
            return result;
        }
    }
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            double result = 0;
            if(NumberB == 0)
            {
                throw new Exception("除数不能为0。");
            }
            result = NumberA / NumberB;
            return result;
        }
    }

    public class OperationFactory
    {
        public static Operation createOperate(string operate)
        {
            Operation oper = null;
            switch(operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }

    class Program
    {
        static void Main(string[] arg)
        {
            try
            {
                Console.Write("请输入数字A：");
                string strNumerA = Console.ReadLine();
                Console.Write("请选择运算符号（+、-、*、/）：");
                string strOperate = Console.ReadLine();
                Console.Write("请输入数字B：");
                string strNumberB = Console.ReadLine();
                string strResult = "";

                Operation oper;
                oper = OperationFactory.createOperate(strOperate);
                oper.NumberA = Convert.ToDouble(strNumerA);
                oper.NumberB = Convert.ToDouble(strNumberB);
                strResult = oper.GetResult().ToString();

                Console.WriteLine("结果是：" + strResult);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("您的输入有错：" + ex.Message);
            }
        }
    }
}
