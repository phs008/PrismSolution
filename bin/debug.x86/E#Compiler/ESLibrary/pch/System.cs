namespace System
{
  // 
  public class Object {
    public Object();
    ~Object();
    public virtual bool Equals(object obj);
    public virtual int GetHashCode();
    public Type GetType();
    public virtual string ToString();
  }
  
  //public sealed class String : IEnumerable<Char>, IEnumerable
  public sealed class String {
    public int Length {get;}
    public char this[int index] {get;}
  }
  

  public abstract class ValueType {
    protected ValueType();
  }
  
  public struct SByte {}
  public struct Byte {}
  public struct Int16 {}
  public struct UInt16 {}
  public struct Int32 {}
  public struct UInt32 {}
  public struct Int64 {}
  public struct UInt64 {}
  public struct Char {}
  public struct Single {}
  public struct Double {}
  public struct Boolean {}
  public struct Decimal {}



  //public abstract class Array : IList, ICollection, IEnumerable
  public abstract class Array 
  {
    public int Length { get; }
    public int Rank   { get; }
    public int GetLength(int dimension);
  }

  public abstract class Delegate
  {
  }
  
  public interface ICloneable
  {
    object Clone();
  }


  public abstract class Enum : ValueType
  {
    protected Enum ();
  }


  //public struct Nullable <T> {
  //  public bool HasValue {get;}
  //  public T Value {get;}
  //}
  public class MemberInfo {
    protected MemberInfo();
  }
  
  public abstract class Type : MemberInfo {
  }

  public struct MyType {
    int x;
    int y;
    int z;
  }
}



// Exception
namespace System {
  public class Exception {
    public Exception();
    public Exception(string message);
    public Exception(string message, Exception innerException);
    public sealed Exception InnerException { get; }
    public virtual string Message { get; }
  }

  public class ApplicationException : Exception {
    public ApplicationException();
    public ApplicationException(string message);
    public ApplicationException(string message, Exception innerException);
  }

  public class SystemException : Exception {
    public SystemException();
    public SystemException(string message);
    public SystemException(string message, Exception innerException);
  }

  public class ArgumentException : SystemException {
    public ArgumentException();
    public ArgumentException(string message);
    public ArgumentException(string message, Exception innerException);
  }

  public class ArithmeticException : SystemException {
    public ArithmeticException();
    public ArithmeticException(string message);
    public ArithmeticException(string message, Exception innerException);
  }

  public class ArrayTypeMismatchException : SystemException {
    public ArrayTypeMismatchException();
    public ArrayTypeMismatchException(string message);
    public ArrayTypeMismatchException(string message, Exception innerException);
  }

  public class DivideByZeroException : SystemException {
    public DivideByZeroException();
    public DivideByZeroException(string message);
    public DivideByZeroException(string message, Exception innerException);
  }

  public class IndexOutOfRangeException : SystemException {
    public IndexOutOfRangeException();
    public IndexOutOfRangeException(string message);
    public IndexOutOfRangeException(string message, Exception innerException);
  }

  public class InvalidCastException : SystemException {
    public InvalidCastException();
    public InvalidCastException(string message);
    public InvalidCastException(string message, Exception innerException);
  }

  public class InvalidOperationException : SystemException {
    public InvalidOperationException();
    public InvalidOperationException(string message);
    public InvalidOperationException(string message, Exception innerException);
  }

  public class NotSupportedException : SystemException {
    public NotSupportedException();
    public NotSupportedException(string message);
    public NotSupportedException(string message, Exception innerException);
  }

  public class NullReferenceException : SystemException {
    public NullReferenceException();
    public NullReferenceException(string message);
    public NullReferenceException(string message, Exception innerException);
  }
  
  public class OutOfMemoryException : SystemException {
    public OutOfMemoryException();
    public OutOfMemoryException(string message);
    public OutOfMemoryException(string message, Exception innerException);
  }

  public class OverflowException : ArithmeticException {
    public OverflowException();
    public OverflowException(string message);
    public OverflowException(string message, Exception innerException);
  }

  public sealed class StackOverflowException : SystemException {
    public StackOverflowException();
    public StackOverflowException(string message);
    public StackOverflowException(string message, Exception innerException);
  }

  public sealed class TypeInitializationException : SystemException {
    public TypeInitializationException();
    public TypeInitializationException(string message);
    public TypeInitializationException(string message, Exception innerException);
  }
}
  
