# Paps Maybe

## What is it?

Paps Maybe is just another implementation of Maybe Monads in c#.

## For what purpose?

Prevent null on reference types and default() on value types. Maybes helps handle the lack of value in a expressive way.

## How to install it
1. The package is available on the [openupm registry](https://openupm.com/packages/paps.maybe/).
```
openupm add paps.maybe
```

## How to use it

### Anything can be a Maybe

```csharp
void SomeMethod(SomeClass probablyNullObject)
{
    var maybe = probablyNullObject.ToMaybe();

    maybe.Do(value => Debug.Log("If you see this, the value was not null!"));
}
```

### Use its operators

```csharp
Maybe<int> SomeMethod(int myValueIKnowIsInvalid)
{
    return myValueIKnowIsInvalid.AsNothing();
}

Maybe<int> SomeMethod(int myValueImNotSureIsInvalid)
{
    return myValueImNotSureIsInvalid.AsNothingWhen(() => myValueImNotSureIsInvalid < 0);
}

int SomeMethod(Maybe<int> myMaybeValueWhichICanDefault)
{
    return myMaybeValueWhichICanDefault.GetOrDefault(someOtherDefaultValue);
}

void DoSomethingIfHasValue(Maybe<int> maybe)
{
    //DoSomething will not execute if it does not has value
    maybe.Do(() => DoSomething())
        .OrElse(() => DoSomethingElse()); //DoSomethingElse will not execute if it has value
}
```

## License

[MIT License](https://github.com/Sammmte/Paps-Maybe/blob/master/Paps-Maybe/Assets/Maybe/LICENSE.md)