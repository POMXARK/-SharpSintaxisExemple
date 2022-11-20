
using СSharpSintaxisExemple.Delegate;

namespace СSharpSintaxisExemple // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exemples.SimpleDelegate();
            Console.WriteLine();

            Exemples.SimpleDelegateNotSugger();
            Console.WriteLine();

            ExepmpleConnectDelegate.ConnectDelegate();
            Console.WriteLine();

            DelegateParameters.Exemple();
            Console.WriteLine();

            DelegateParameters.AssigningMethodReference();
            Console.WriteLine();

            DelegateList.QueueDelegate();
            Console.WriteLine();

            DelegateList.DoobleDeligate();
            Console.WriteLine();

            DelegateList.DelUseMethod();
            Console.WriteLine();

            DelegateList.MergeDelegate();
            Console.WriteLine();

            DelegateList.ReturnEnd();
            Console.WriteLine();

            DelegateList.CommonDelegate();
            Console.WriteLine();

            DelegateList.DelegateHowArgumentMethod();
            Console.WriteLine();

            DelegateList.ReternDelegateFromMethod();
            Console.WriteLine();
        }
    }
}

