using Chapter2;
using System;
using System.Collections.Generic;
using WeakReference = Chapter2.WeakReference;
using System.IO;

namespace ConsoleApp.Chapters
{
    class Chapter2Class
    {
        private BoxingAndUnBoxing _boxingAndUnBoxing;
        private CodeDom _codeDom;
        private Conversions _conversions;
        private DisposableAndFinalizer _disposableAndFinalizer;
        private Dynamic _dynamic;
        private EnumClass _enumClass;
        private Explicity _explicity;
        private Gender _gender;
        private Lambda _lambda;
        private Reflections _reflections;
        private StringClass _stringClass;
        private WeakReference _weakReference;
        private Yields _yields;

        public Chapter2Class()
        {
            _boxingAndUnBoxing = new BoxingAndUnBoxing();
            _codeDom = new CodeDom();
            _conversions = new Conversions();
            _disposableAndFinalizer = new DisposableAndFinalizer();
            _dynamic = new Dynamic();
            _explicity = new Explicity();
            _lambda = new Lambda();
            _reflections = new Reflections();
            _stringClass = new StringClass();
            _weakReference = new WeakReference();
            _yields = new Yields();

        }

        public void UsingBoxinAndUnBoxing()
        {
            _boxingAndUnBoxing.Boxing();
            _boxingAndUnBoxing.Unboxing();
        }

        public void UsingCodeDom()
        {
            _codeDom.UsingCodeDom();
        }

        public void UsingConversions()
        {
            Stream stream = Stream.Null;

            _conversions.ConversionsWithHelperClass();
            _conversions.ExplicitConversion();
            _conversions.ImplicitConversion();
            _conversions.UsingAs(stream);
            _conversions.UsingIs(stream);
        }

        public void UsingDisposableAndFinalizer()
        {
            _disposableAndFinalizer.Stream = new FileStream("c:", FileMode.Create);
            _disposableAndFinalizer.Dispose(true);
        }

        public void UsingDynamic()
        {


        }

        public void UsingExplicity()
        {
        }

        public void UsingNullable()
        {
            NullableStruct<ProductStruct> nullable = new NullableStruct<ProductStruct>(new ProductStruct());
            nullable.GetValueOrDefault();
            Console.WriteLine($"The productstruct has value. {nullable.HasValue}");
        }

        public void UsingLambda()
        {
            _lambda.UsingBlockExpression();
            _lambda.UsingFunc();
        }

        public void UsingReflections()
        {
            _reflections.UsingReflection();
        }

        public void UsingStrings()
        {
            _stringClass.UsingDisplayANumber();
            _stringClass.UsingIndexOf();
            _stringClass.UsingRegularExpression();
            _stringClass.UsingStartWithAndEndsWith();
            _stringClass.UsingString();
            _stringClass.UsingStringBuilder();
            _stringClass.UsingStringWriter();
            _stringClass.UsingSubStrings();

        }

        public void UsingWeakReference()
        {
            _weakReference.UsingWeakReference();
        }

        public void UsingYields()
        {
            _yields.CallPerson();
        }

        public void UsingWorkWithEnum()
        {
            var enumclass = new EnumClass();
            enumclass.CompareEnums();
        }

        public void UsingGenericClass()
        {
            var generic = new MyGenericClass<Chapter2Class>();
            generic.MyGenericMethod<string>();
        }

        public void UsingExtensionMethods()
        {
            Product product = new Product();
            product.Price = 123;
            ExtensionMethods.Discount(product);
        }
    }

    public class Card
    {

    }

    public class Deck
    {
        public ICollection<Card> Cards { get; private set; }
    }
}
