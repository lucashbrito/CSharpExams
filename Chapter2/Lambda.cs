using System;
using System.Linq.Expressions;

namespace Chapter2
{
    public class Lambda
    {
        public void UsingFunc()
        {
            Func<int, int, int> addFunc = (i, i1) => i + i1;

            Console.WriteLine(addFunc(12, 12));

        }

        public void UsingBlockExpression()
        {
            BlockExpression blockExpression = Expression.Block(
                Expression.Call(null, typeof(Console).GetMethod("Write", new Type[] { typeof(string) }), Expression.Constant("Hello")),
                Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("World!"))
                );

            Expression.Lambda<Action>(blockExpression).Compile()();
        }
    }
}
