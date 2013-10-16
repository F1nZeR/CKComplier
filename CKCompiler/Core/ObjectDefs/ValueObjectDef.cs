using System;
using System.Globalization;
using System.Reflection.Emit;

namespace CKCompiler.Core.ObjectDefs
{
    public class ValueObjectDef : ObjectDef
    {
        private readonly object _value;
        private readonly ConstructorBuilder _builder;

        public ValueObjectDef(Type type, object value, ConstructorBuilder builder = null)
            : base(type)
        {
            _value = value;
            _builder = builder;
        }

        public override enmObjectScope Scope
        {
            get { return enmObjectScope.Value; }
        }

        public override void Load()
        {
            if (Type == typeof(int)) EmitInteger((int)_value);
            else if (Type == typeof (float))
            {
                var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";
                EmitFloat(double.Parse(_value.ToString(), NumberStyles.Any, ci));
            }
            else if (Type == typeof(bool))
            {
                var boolean = (bool)_value;
                Generator.Emit(boolean ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0);
            }
            else if (Type == typeof(string))
                Generator.Emit(OpCodes.Ldstr, (string)_value);
            else if (Type == typeof (char))
                EmitInteger(Convert.ToInt16(_value));
            else if (_builder == null)
                Generator.Emit(OpCodes.Ldnull);
            else
                Generator.Emit(OpCodes.Newobj, _builder);
        }


        public override void Remove()
        {
        }

        public override void Free()
        {
        }

        public object GetValue()
        {
            return _value;
        }
    }
}
