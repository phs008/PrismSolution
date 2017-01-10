using System;
using System.Collections;
using System.Collections.Generic;
using VRCAT.Infrastructure.MonitoredUndo.Changes;

namespace VRCAT.Infrastructure.MonitoredUndo
{
    public class DictionaryAddChange : DictionaryAddRemoveChangeBase
    {
        public DictionaryAddChange(object target, string propertyName, IDictionary collection, object key, object value)
            : base(target, propertyName, collection, key, value)
        {
        }

        protected override void PerformUndo()
        {
            Collection.Remove(Key);
        }

        protected override void PerformRedo()
        {
            Collection.Add(Key, Value);
        }
    }
}