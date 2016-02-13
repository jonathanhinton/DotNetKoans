using Xunit;

namespace DotNetKoans.CSharp
{
    public class AboutNil : Koan
    {
        [Koan(1)]
        public void NilIsNotAnObject()
        {
            Assert.True(!typeof(object).IsAssignableFrom(null)); //not everything is an object
        }

        [Koan(2)]
        public void YouGetNullPointerErrorsWhenCallingMethodsOnNil()
        {
            //What is the Exception that is thrown when you call a method on a null object?
            //Don't be confused by the code below. It is using Anonymous Delegates which we will
            //cover later on. 
            object nothing = null;
            Assert.Throws(typeof(System.NullReferenceException), delegate() { nothing.ToString(); });

            //What's the message of the exception? What substring or pattern could you test
            //against in order to have a good idea of what the string is?
            try
            {
                nothing.ToString();
            }
            catch (System.Exception ex)
            {
                Assert.Contains("Object reference" as string, ex.Message);
            }
        }

        [Koan(3)]
        public void CheckingThatAnObjectIsNull()
        {
            object obj = null;
            Assert.True(obj == null);
        }

        [Koan(4)]
        public void ABetterWayToCheckThatAnObjectIsNull()
        {
            object obj = null;
            Assert.Null(obj);
        }

        [Koan(5)]
        public void AWayNotToCheckThatAnObjectIsNull()
        {
            object obj = null;
            //Assert.True(obj.Equals(null)); this was the initial code. The reason this does ont work is because the object is null and mehtods cannot be called on null. My solution below might not be correct but it works. Null does not mean no memory, it means no behavior.
            Assert.Equal(obj, null);
            // 1. comment the line out. and take notes: cannot call methods on null
            // 2. Assert.Equal(obj, null);
        }
    }
}
