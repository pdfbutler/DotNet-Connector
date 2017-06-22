using System;
using System.Dynamic;
using System.Collections.Generic;
public class DynamicDictionary : DynamicObject
{
    // The inner dictionary.
    public Dictionary<string, string> dictionary
        = new Dictionary<string, string>();

    // This property returns the number of elements
    // in the inner dictionary.
    public int Count
    {
        get
        {
            return dictionary.Count;
        }
    }

    // If you try to get a value of a property 
    // not defined in the class, this method is called.
    public override bool TryGetMember(
        GetMemberBinder binder, out object result)
    {
        string name = binder.Name;

        // If the property name is found in a dictionary,
        // set the result parameter to the property value and return true.
        // Otherwise, return false.
        string resultObj;
        if(!dictionary.TryGetValue(name, out resultObj)) {
            throw new KeyNotFoundException("No key with name: " + name);
        }
        result = resultObj;

        return true;
    }

    // If you try to set a value of a property that is
    // not defined in the class, this method is called.
    public override bool TrySetMember(
        SetMemberBinder binder, object value)
    {
        dictionary[binder.Name] = value.ToString();

        // You can always add a value to a dictionary,
        // so this method always returns true.
        return true;
    }
}
